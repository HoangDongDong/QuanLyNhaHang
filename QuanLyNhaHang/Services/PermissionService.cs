using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;

namespace QuanLyNhaHang.Services
{
    /// <summary>
    /// Central permission service — loads SGROUPROLE/SREPORTROLE for the current user's group
    /// and enforces access control across the application.
    /// 
    /// Permission bitmask (matches FormUserManagement convention):
    ///   Xem  (View)   = 16
    ///   Sửa  (Edit)   = 32
    ///   Thêm (Add)    = 64
    ///   Xóa  (Delete) = 128
    ///   Mode = 0 → Khóa (locked / no access)
    /// </summary>
    public static class PermissionService
    {
        public const int MODE_VIEW = 16;
        public const int MODE_EDIT = 32;
        public const int MODE_ADD = 64;
        public const int MODE_DELETE = 128;

        // SFUNCTIONID → MODE bitmask
        private static Dictionary<string, int> _funcPermissions = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

        // SREPORTID → MODE
        private static Dictionary<string, int> _reportPermissions = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

        // SFORM.ID → SFORM.SFUNCTIONID mapping (so we can look up permissions by form name)
        private static Dictionary<string, string> _formIdToFunctionId = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        // SFORM.NAME (lowercase) → SFORM.ID 
        private static Dictionary<string, string> _formNameToId = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        // SMENU.NAME → SFORM.SFUNCTIONID (for menu-level permission filtering)
        private static Dictionary<string, string> _menuNameToFunctionId = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        // Indicates whether permissions have been loaded
        public static bool IsLoaded { get; private set; } = false;

        /// <summary>
        /// Load all permissions for the current user's group.
        /// Should be called once after successful login.
        /// </summary>
        public static void LoadPermissionsForCurrentUser()
        {
            _funcPermissions.Clear();
            _reportPermissions.Clear();
            _formIdToFunctionId.Clear();
            _formNameToId.Clear();
            _menuNameToFunctionId.Clear();
            IsLoaded = false;

            // Admin bypasses all — no need to load
            if (Program.IsAdmin)
            {
                IsLoaded = true;
                return;
            }

            string groupId = Program.CurrentUserGroupId;
            if (string.IsNullOrEmpty(groupId))
            {
                IsLoaded = true;
                return;
            }

            string connStr = DbFormService.GetConnectionString();
            if (string.IsNullOrEmpty(connStr)) return;

            try
            {
                using (FbConnection conn = new FbConnection(connStr))
                {
                    conn.Open();

                    // 1. Load SGROUPROLE (function permissions)
                    using (FbCommand cmd = new FbCommand("SELECT SFUNCTIONID, MODE FROM SGROUPROLE WHERE SGROUPUSERID = @g", conn))
                    {
                        cmd.Parameters.AddWithValue("@g", groupId);
                        using (FbDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string funcId = reader["SFUNCTIONID"]?.ToString()?.Trim();
                                int mode = reader["MODE"] != DBNull.Value ? Convert.ToInt32(reader["MODE"]) : 0;
                                if (!string.IsNullOrEmpty(funcId))
                                    _funcPermissions[funcId] = mode;
                            }
                        }
                    }

                    // 2. Load SREPORTROLE (report permissions)
                    try
                    {
                        using (FbCommand cmd = new FbCommand("SELECT SREPORTID, MODE FROM SREPORTROLE WHERE SGROUPUSERID = @g", conn))
                        {
                            cmd.Parameters.AddWithValue("@g", groupId);
                            using (FbDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    string repId = reader["SREPORTID"]?.ToString()?.Trim();
                                    int mode = reader["MODE"] != DBNull.Value ? Convert.ToInt32(reader["MODE"]) : 0;
                                    if (!string.IsNullOrEmpty(repId))
                                        _reportPermissions[repId] = mode;
                                }
                            }
                        }
                    }
                    catch { /* SREPORTROLE table may not exist */ }

                    // 3. Load SFORM → SFUNCTION mapping
                    using (FbCommand cmd = new FbCommand("SELECT ID, NAME, CLASSNAME, SFUNCTIONID FROM SFORM WHERE STATUS = 30", conn))
                    {
                        using (FbDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string formId = reader["ID"]?.ToString()?.Trim();
                                string formName = reader["NAME"]?.ToString()?.Trim();
                                string className = reader["CLASSNAME"]?.ToString()?.Trim();
                                string funcId = reader["SFUNCTIONID"]?.ToString()?.Trim();

                                if (!string.IsNullOrEmpty(formId))
                                {
                                    if (!string.IsNullOrEmpty(funcId))
                                        _formIdToFunctionId[formId] = funcId;

                                    if (!string.IsNullOrEmpty(formName))
                                        _formNameToId[formName] = formId;

                                    if (!string.IsNullOrEmpty(className) && !_formNameToId.ContainsKey(className))
                                        _formNameToId[className] = formId;
                                }
                            }
                        }
                    }

                    // 4. Load SMENU → SFORM mapping for menu-level filtering
                    try
                    {
                        using (FbCommand cmd = new FbCommand(
                            @"SELECT M.NAME, F.SFUNCTIONID 
                              FROM SMENU M 
                              INNER JOIN SFORM F ON M.SFORMID = F.ID 
                              WHERE F.SFUNCTIONID IS NOT NULL AND F.SFUNCTIONID <> ''", conn))
                        {
                            using (FbDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    string menuName = reader["NAME"]?.ToString()?.Trim();
                                    string funcId = reader["SFUNCTIONID"]?.ToString()?.Trim();
                                    if (!string.IsNullOrEmpty(menuName) && !string.IsNullOrEmpty(funcId))
                                        _menuNameToFunctionId[menuName] = funcId;
                                }
                            }
                        }
                    }
                    catch { }
                }

                IsLoaded = true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("PermissionService.LoadPermissions error: " + ex.Message);
                IsLoaded = true; // Mark as loaded to avoid blocking — fail open for safety
            }
        }

        /// <summary>
        /// Get the raw permission mode bitmask for a form by its name or class name.
        /// Returns -1 if no permission record found (meaning unrestricted by default).
        /// Returns 0 if explicitly locked.
        /// </summary>
        public static int GetPermissionMode(string formName)
        {
            if (Program.IsAdmin) return MODE_VIEW | MODE_ADD | MODE_EDIT | MODE_DELETE; // Full access

            if (string.IsNullOrEmpty(formName)) return -1;

            // Try to find SFUNCTIONID for this form
            string funcId = GetFunctionIdForForm(formName);

            if (string.IsNullOrEmpty(funcId)) return -1; // No function mapping → unrestricted

            if (_funcPermissions.TryGetValue(funcId, out int mode))
                return mode;

            return 0; // Has function mapping but no permission record → locked by default
        }

        /// <summary>
        /// Can the current user view/open this form?
        /// </summary>
        public static bool CanView(string formName)
        {
            int mode = GetPermissionMode(formName);
            if (mode == -1) return true; // No restriction configured
            return (mode & MODE_VIEW) == MODE_VIEW;
        }

        /// <summary>
        /// Can the current user add new records in this form?
        /// </summary>
        public static bool CanAdd(string formName)
        {
            int mode = GetPermissionMode(formName);
            if (mode == -1) return true;
            return (mode & MODE_ADD) == MODE_ADD;
        }

        /// <summary>
        /// Can the current user edit records in this form?
        /// </summary>
        public static bool CanEdit(string formName)
        {
            int mode = GetPermissionMode(formName);
            if (mode == -1) return true;
            return (mode & MODE_EDIT) == MODE_EDIT;
        }

        /// <summary>
        /// Can the current user delete records in this form?
        /// </summary>
        public static bool CanDelete(string formName)
        {
            int mode = GetPermissionMode(formName);
            if (mode == -1) return true;
            return (mode & MODE_DELETE) == MODE_DELETE;
        }

        /// <summary>
        /// Check if a menu item should be visible based on permission.
        /// Uses SMENU → SFORM → SFUNCTION mapping.
        /// </summary>
        public static bool CanViewMenu(string menuName)
        {
            if (Program.IsAdmin) return true;
            if (string.IsNullOrEmpty(menuName)) return true;

            // Check if this menu name has a mapped function
            if (_menuNameToFunctionId.TryGetValue(menuName, out string funcId))
            {
                if (_funcPermissions.TryGetValue(funcId, out int mode))
                    return (mode & MODE_VIEW) == MODE_VIEW;
                
                // Has mapping but no permission record → locked
                return false;
            }

            // No mapping → show by default (parent menus, separators, etc.)
            return true;
        }

        /// <summary>
        /// Apply permission-based UI restrictions to a form.
        /// Disables Add/Edit/Delete buttons based on the user's permission mode.
        /// </summary>
        public static void ApplyPermissionsToForm(Form form, string formName)
        {
            if (form == null || Program.IsAdmin) return;

            bool canAdd = CanAdd(formName);
            bool canEdit = CanEdit(formName);
            bool canDelete = CanDelete(formName);

            // Apply to common button patterns in the form
            ApplyToControl(form, "btnThem", canAdd);
            ApplyToControl(form, "btnThemMoi", canAdd);
            ApplyToControl(form, "btnAdd", canAdd);
            ApplyToControl(form, "btnLuuMoi", canAdd);

            ApplyToControl(form, "btnSua", canEdit);
            ApplyToControl(form, "btnEdit", canEdit);
            ApplyToControl(form, "btnCapNhat", canEdit);
            ApplyToControl(form, "btnLuu", canEdit);

            ApplyToControl(form, "btnXoa", canDelete);
            ApplyToControl(form, "btnDelete", canDelete);

            // Apply to ToolStrip buttons
            ApplyPermissionsToToolStrips(form, canAdd, canEdit, canDelete);
        }

        /// <summary>
        /// Apply permissions to all ToolStrips within a form.
        /// Matches common Vietnamese button text patterns.
        /// </summary>
        public static void ApplyPermissionsToToolStrips(Control container, bool canAdd, bool canEdit, bool canDelete)
        {
            if (container == null || Program.IsAdmin) return;

            foreach (Control c in container.Controls)
            {
                if (c is ToolStrip ts)
                {
                    foreach (ToolStripItem item in ts.Items)
                    {
                        if (item is ToolStripButton btn)
                        {
                            string text = btn.Text?.ToLower() ?? "";
                            if (text.Contains("thêm") || text.Contains("add"))
                            {
                                btn.Enabled = canAdd;
                                if (!canAdd) btn.ToolTipText = "Bạn không có quyền thêm mới";
                            }
                            else if (text.Contains("sửa") || text.Contains("edit") || text.Contains("cập nhật"))
                            {
                                btn.Enabled = canEdit;
                                if (!canEdit) btn.ToolTipText = "Bạn không có quyền chỉnh sửa";
                            }
                            else if (text.Contains("xóa") || text.Contains("delete"))
                            {
                                btn.Enabled = canDelete;
                                if (!canDelete) btn.ToolTipText = "Bạn không có quyền xóa";
                            }
                        }
                    }
                }

                // Recurse into child containers
                if (c.HasChildren)
                    ApplyPermissionsToToolStrips(c, canAdd, canEdit, canDelete);
            }
        }

        /// <summary>
        /// Resolve the SFUNCTIONID for a given form name.
        /// </summary>
        private static string GetFunctionIdForForm(string formName)
        {
            if (string.IsNullOrEmpty(formName)) return null;

            // Direct form name → form ID → function ID
            if (_formNameToId.TryGetValue(formName, out string formId))
            {
                if (_formIdToFunctionId.TryGetValue(formId, out string funcId))
                    return funcId;
            }

            // Try as menu name
            if (_menuNameToFunctionId.TryGetValue(formName, out string menuFuncId))
                return menuFuncId;

            return null;
        }

        /// <summary>
        /// Enable/disable a control by name recursively.
        /// </summary>
        private static void ApplyToControl(Control parent, string controlName, bool enabled)
        {
            Control ctrl = FindControlRecursive(parent, controlName);
            if (ctrl != null)
            {
                ctrl.Enabled = enabled;
                if (!enabled && ctrl is Button btn)
                {
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
                    btn.ForeColor = System.Drawing.Color.Gray;
                }
            }
        }

        /// <summary>
        /// Find a control by name recursively within a container.
        /// </summary>
        private static Control FindControlRecursive(Control parent, string name)
        {
            if (parent == null || string.IsNullOrEmpty(name)) return null;

            foreach (Control c in parent.Controls)
            {
                if (string.Equals(c.Name, name, StringComparison.OrdinalIgnoreCase))
                    return c;

                Control found = FindControlRecursive(c, name);
                if (found != null) return found;
            }
            return null;
        }
    }
}
