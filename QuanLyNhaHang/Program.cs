using System;
using System.Windows.Forms;

namespace QuanLyNhaHang
{
    public static class Program
    {
        public static string CurrentUser { get; set; } = "admin";
        public static string CurrentUserId { get; set; } = "";
        public static string CurrentUserGroup { get; set; } = "Administrator";
        public static string CurrentUserGroupId { get; set; } = "";
        public static bool IsAdmin { get; set; } = true;
        public static string CurrentDatabase { get; set; } = "DEMO";
        public static string CurrentDatabasePath { get; set; } = @"d:\QuanLyNhaHang\Database\DEMO.FDB";

        /// <summary>
        /// Exact startup flow of original application:
        /// Step 1: FormDatabase (Dữ liệu chương trình)
        /// Step 2: FormLogin (Đăng nhập)
        /// Step 3: FormMain (MDI Main App)
        /// </summary>
        public static string ConfigFilePath => System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "databases.config");

        public static void LoadLastDatabaseFromConfig()
        {
            try
            {
                if (System.IO.File.Exists(ConfigFilePath))
                {
                    string[] lines = System.IO.File.ReadAllLines(ConfigFilePath, System.Text.Encoding.UTF8);
                    foreach (string line in lines)
                    {
                        if (string.IsNullOrWhiteSpace(line)) continue;
                        string[] parts = line.Split('|');
                        if (parts.Length >= 2)
                        {
                            string name = parts[0].Trim();
                            string fullPath = parts[1].Trim();

                            if (System.IO.Directory.Exists(fullPath) || (!fullPath.EndsWith(".fdb", StringComparison.OrdinalIgnoreCase) && !fullPath.EndsWith(".gdb", StringComparison.OrdinalIgnoreCase)))
                            {
                                fullPath = System.IO.Path.Combine(fullPath, name + ".FDB");
                            }

                            if (System.IO.File.Exists(fullPath))
                            {
                                CurrentDatabase = name;
                                CurrentDatabasePath = fullPath;
                                Services.DbFormService.DefaultDbPath = fullPath;
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lỗi nạp CSDL mặc định từ config: " + ex.Message);
            }
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Load last selected database path from config
            try { No1Lib.Sys.EasyReg.Key = Microsoft.Win32.Registry.CurrentUser; } catch { }
            LoadLastDatabaseFromConfig();

            // Step 1: Login Form (Form1) opens directly first
            using (Form1 loginForm = new Form1())
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    CurrentUser = loginForm.LoggedInUser;

                    // Load Global Configs
                    string connStr = Services.DbFormService.GetConnectionString(CurrentDatabasePath);
                    Services.GlobalConfig.LoadAllConfigs(connStr);

                    // Initialize No1Lib Global Database & DbConfig
                    try
                    {
                        No1Lib.Db.Database db = new No1Lib.Db.Database("localhost", "SYSDBA", "masterkey", CurrentDatabasePath);
                        db.ReConnect();
                        No1Lib.Sys.Config.Db = db;
                        No1Lib.Db.DbConfig.Database = db;
                        No1Lib.Db.DbConfig.UserID = CurrentUserId;
                        No1Lib.Db.DbConfig.UserName = CurrentUser;
                        No1Lib.Db.DbConfig.IsAdmin = IsAdmin;
                        DbMapping.SystemConfig.Db = db;
                        try { DbMapping.BaseSystemConfig.Refresh(); } catch { }
                        No1Run.TDONHANG0Ae.EnsureNo1LibInitialized();
                    }
                    catch (Exception exDb)
                    {
                        System.Diagnostics.Debug.WriteLine("Init No1Lib error: " + exDb.Message);
                    }

                    // Load Permissions for current user's group
                    Services.PermissionService.LoadPermissionsForCurrentUser();

                    // Step 2: Launch Main MDI App
                    Services.DynamicCompilerService.CompileGlobalAssembly(Services.DbFormService.LoadAllForms(CurrentDatabasePath));
                    Application.Run(new FormMain());
                }
            }
        }
    }
}
