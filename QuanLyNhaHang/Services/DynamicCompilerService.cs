using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.CSharp;

namespace QuanLyNhaHang.Services
{
    public static class DynamicCompilerService
    {
        public static Assembly GlobalAssembly { get; private set; }
        public static string GlobalCompileError { get; private set; }

        public static void CompileGlobalAssembly(List<FormModel> allModels)
        {
            if (allModels == null || allModels.Count == 0) return;

            StringBuilder allSources = new StringBuilder();
            HashSet<string> globalUsings = new HashSet<string>();
            globalUsings.Add("using System;");
            globalUsings.Add("using System.Windows.Forms;");
            globalUsings.Add("using System.Drawing;");
            globalUsings.Add("using System.Data;");
            globalUsings.Add("using System.Collections.Generic;");
            globalUsings.Add("using Timer = System.Windows.Forms.Timer;");

            StringBuilder classSources = new StringBuilder();

            foreach (var model in allModels)
            {
                string code = model.Code ?? model.ClientCode ?? "";
                if (string.IsNullOrWhiteSpace(code) && string.IsNullOrWhiteSpace(model.AeLayout)) continue;

                // 1. Extract and remove usings from raw code so they don't break the global namespace compilation
                if (!string.IsNullOrWhiteSpace(code))
                {
                    var usingMatches = Regex.Matches(code, @"^\s*using\s+[\w\.]+(?:\s*=\s*[\w\.]+)?\s*;\s*$", RegexOptions.Multiline);
                    foreach (Match m in usingMatches)
                    {
                        globalUsings.Add(m.Value.Trim());
                    }
                    code = Regex.Replace(code, @"^\s*using\s+[\w\.]+(?:\s*=\s*[\w\.]+)?\s*;\s*$", "", RegexOptions.Multiline);
                }

                // 2. Parse AELAYOUT for control declarations
                Dictionary<string, string> controlDeclarations = new Dictionary<string, string>();
                if (!string.IsNullOrWhiteSpace(model.AeLayout))
                {
                    var matches = Regex.Matches(model.AeLayout, @"<Object[^>]*type=""([^""]+)""[^>]*name=""([^""]+)""");
                    foreach (Match m in matches)
                    {
                        string fullType = m.Groups[1].Value;
                        string name = m.Groups[2].Value;
                        string typeOnly = fullType.Split(',')[0].Trim();

                        if (typeOnly == "No1Lib.Sys.No1Button") typeOnly = "System.Windows.Forms.Button";
                        else if (typeOnly == "No1Lib.Sys.No1Label") typeOnly = "System.Windows.Forms.Label";
                        else if (typeOnly == "No1Lib.Sys.No1TextBox") typeOnly = "System.Windows.Forms.TextBox";
                        else if (typeOnly == "No1Lib.Sys.No1DataGrid") typeOnly = "System.Windows.Forms.DataGridView";

                        if (!controlDeclarations.ContainsKey(name))
                        {
                            controlDeclarations[name] = typeOnly;
                        }
                    }
                }

                string ns = ExtractNamespace(code) ?? "No1Run";
                string className = (!string.IsNullOrEmpty(model.ClassName) ? model.ClassName : ExtractClassName(code));
                if (string.IsNullOrEmpty(className)) continue;

                classSources.AppendLine(string.Format("namespace {0} {{", ns));
                classSources.AppendLine(string.Format("    public partial class {0} : UserControl {{", className));
                
                foreach (var kvp in controlDeclarations)
                {
                    string fieldName = kvp.Key.Replace(" ", "_").Replace("-", "_");
                    if (Regex.IsMatch(fieldName, @"^[a-zA-Z_]\w*$"))
                    {
                        classSources.AppendLine(string.Format("        public {0} {1};", kvp.Value, fieldName));
                    }
                }
                classSources.AppendLine("    }");
                classSources.AppendLine("}");
                
                code = Regex.Replace(code, @"(?<!\bpartial\s+)\bclass\s+" + className + @"\b", "partial class " + className); classSources.AppendLine(code);
            }

            // Write all usings at the top
            foreach (string u in globalUsings)
            {
                allSources.AppendLine(u);
            }
            // Append missing stubs
            string allSourcesString = classSources.ToString();
            
            // Generate DynamicRowWrapper
            allSources.AppendLine(@"
namespace No1Run {
    public class DynamicRowWrapper : System.Dynamic.DynamicObject
    {
        public System.Data.DataRow Row { get; set; }
        public string ID { get; set; }
        public DynamicRowWrapper(params object[] args)
        {
            if (args != null && args.Length > 0)
            {
                if (args[0] is System.Data.DataRow r) Row = r;
                else if (args[0] is string s) ID = s;
                else if (args[0] != null) ID = args[0].ToString();
            }
        }
        public DynamicRowWrapper() {}
        public object this[string indexer]
        {
            get {
                if (Row != null && Row.Table.Columns.Contains(indexer)) return Row[indexer];
                return null;
            }
            set {
                if (Row != null && Row.Table.Columns.Contains(indexer)) Row[indexer] = value;
            }
        }
        public override bool TryGetMember(System.Dynamic.GetMemberBinder binder, out object result)
        {
            if (Row != null && Row.Table.Columns.Contains(binder.Name))
            {
                result = Row[binder.Name];
                return true;
            }
            result = null;
            return true;
        }
        public override bool TrySetMember(System.Dynamic.SetMemberBinder binder, object value)
        {
            if (Row != null && Row.Table.Columns.Contains(binder.Name))
            {
                Row[binder.Name] = value;
                return true;
            }
            return true;
        }
    }
");

            // Extract *Row types from code and generate wrappers
            MatchCollection rowMatches = Regex.Matches(allSourcesString, @"\b([A-Za-z0-9_]+Row)\b");
            HashSet<string> rowTypes = new HashSet<string>();
            foreach (Match m in rowMatches) rowTypes.Add(m.Groups[1].Value);
            foreach (string rt in rowTypes)
            {
                allSources.AppendLine($"    public class {rt} : DynamicRowWrapper {{ public {rt}(params object[] args) : base(args) {{}} public {rt}() {{}} }}");
            }

            // Append static missing enums/classes
            allSources.AppendLine(@"
    public enum ChonBanMode { None }
    public enum ChuyenGopBanMode { None }
    public enum LoaiDo { None }
    public enum LoaiLuuVet { None }
    public enum HoaDonMode { None }
    public enum GiaMatHang { None }
    public enum TrangThaiBan { None }
    public class MergeCell { }
    public class ControlType { }
    public delegate void SelectBanTuTabRequestHandler(string db, string dk, bool empty);
    public delegate void OnKhuVucControlCreatedHandler(object sender);
    public class TableLocker { }

    public enum LoaiMatHang { None }
    public enum CachTinhGiaGio { None }
    public class LuuVetInfo { }
    public class TSObject { }
    public class TDONHANGInfo { }
}");

            // Append class definitions
            allSources.Append(allSourcesString);

            // Compile everything!
            using (CSharpCodeProvider compiler = new CSharpCodeProvider())
            {
                CompilerParameters parameters = new CompilerParameters();
                parameters.GenerateInMemory = true;
                parameters.GenerateExecutable = false;
                parameters.CompilerOptions = "/platform:x86";

                parameters.ReferencedAssemblies.Add("System.dll");
                parameters.ReferencedAssemblies.Add("System.Data.dll");
                parameters.ReferencedAssemblies.Add("System.Drawing.dll");
                parameters.ReferencedAssemblies.Add("System.Windows.Forms.dll");
                parameters.ReferencedAssemblies.Add("System.Xml.dll");
                parameters.ReferencedAssemblies.Add("System.Core.dll");

                string exeDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                if (Directory.Exists(exeDir))
                {
                    foreach (string dllPath in Directory.GetFiles(exeDir, "*.dll"))
                    {
                        try {
                            AssemblyName.GetAssemblyName(dllPath);
                            if (!parameters.ReferencedAssemblies.Contains(dllPath)) parameters.ReferencedAssemblies.Add(dllPath);
                        } catch { }
                    }
                }
                string projectLibsDir = Path.GetFullPath(Path.Combine(exeDir, @"..\..\Libs"));
                if (Directory.Exists(projectLibsDir))
                {
                    foreach (string dllPath in Directory.GetFiles(projectLibsDir, "*.dll"))
                    {
                        try {
                            AssemblyName.GetAssemblyName(dllPath);
                            if (!parameters.ReferencedAssemblies.Contains(dllPath)) parameters.ReferencedAssemblies.Add(dllPath);
                        } catch { }
                    }
                }

                parameters.ReferencedAssemblies.Add(Assembly.GetExecutingAssembly().Location);

                CompilerResults results = compiler.CompileAssemblyFromSource(parameters, allSources.ToString());

                if (results.Errors.HasErrors)
                {
                    StringBuilder errors = new StringBuilder();
                    foreach (CompilerError error in results.Errors)
                    {
                        errors.AppendLine(string.Format("Line {0}: {1}", error.Line, error.ErrorText));
                    }
                    GlobalCompileError = errors.ToString(); System.IO.File.WriteAllText(@"d:\QuanLyNhaHang\scratch\allSources_fail.cs", allSources.ToString());
                    System.Diagnostics.Debug.WriteLine("GLOBAL COMPILE ERROR:\n" + GlobalCompileError);
                }
                else
                {
                    GlobalAssembly = results.CompiledAssembly;
                    GlobalCompileError = null;
                }
            }
        }

        public static object CompileAndAttachLogic(Form form, FormModel model)
        {
            if (!string.IsNullOrEmpty(GlobalCompileError))
            {
                ShowCompileError(form, GlobalCompileError);
                return null;
            }

            if (GlobalAssembly == null) return null;

            string code = model.Code ?? model.ClientCode ?? "";
            string ns = ExtractNamespace(code) ?? "No1Run";
            string className = (!string.IsNullOrEmpty(model.ClassName) ? model.ClassName : ExtractClassName(code));
            if (string.IsNullOrEmpty(className)) return null;

            Type targetType = GlobalAssembly.GetType(string.Format("{0}.{1}", ns, className));
            if (targetType != null)
            {
                object instance = Activator.CreateInstance(targetType);
                
                foreach (Control ctrl in GetAllControls(form))
                {
                    if (string.IsNullOrEmpty(ctrl.Name)) continue;
                    string fieldName = ctrl.Name.Replace(" ", "_").Replace("-", "_");
                    FieldInfo field = targetType.GetField(fieldName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                    if (field != null && field.FieldType.IsAssignableFrom(ctrl.GetType()))
                    {
                        field.SetValue(instance, ctrl);
                    }
                }

                AutoHookEvents(instance, form, targetType);

                // Manually trigger custom bootstrap pseudo-events
                foreach (MethodInfo method in targetType.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
                {
                    if (method.Name.EndsWith("_OnInit") || method.Name.EndsWith("_OnAddedToTab") || method.Name.EndsWith("_Load"))
                    {
                        try
                        {
                            if (method.GetParameters().Length == 2) method.Invoke(instance, new object[] { instance, EventArgs.Empty });
                            else if (method.GetParameters().Length == 1) method.Invoke(instance, new object[] { EventArgs.Empty });
                            else method.Invoke(instance, null);
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Debug.WriteLine($"Bootstrap event error ({method.Name}): {ex.Message}");
                        }
                    }
                }

                MethodInfo loadMethod = targetType.GetMethod("Load", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { typeof(object), typeof(EventArgs) }, null)
                                     ?? targetType.GetMethod("OnLoad", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { typeof(EventArgs) }, null)
                                     ?? targetType.GetMethod("Init", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance, null, Type.EmptyTypes, null);

                if (loadMethod != null)
                {
                    if (loadMethod.GetParameters().Length == 2) loadMethod.Invoke(instance, new object[] { instance, EventArgs.Empty });
                    else if (loadMethod.GetParameters().Length == 1) loadMethod.Invoke(instance, new object[] { EventArgs.Empty });
                    else loadMethod.Invoke(instance, null);
                }

                return instance;
            }
            return null;
        }

        private static IEnumerable<Control> GetAllControls(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                yield return c;
                foreach (Control child in GetAllControls(c))
                {
                    yield return child;
                }
            }
        }

        public static Control FindControlRecursive(Control parent, string name)
        {
            if (parent.Name == name) return parent;
            foreach (Control c in parent.Controls)
            {
                Control found = FindControlRecursive(c, name);
                if (found != null) return found;
            }
            return null;
        }

        private static string ExtractNamespace(string code)
        {
            var match = Regex.Match(code, @"namespace\s+([\w\.]+)");
            return match.Success ? match.Groups[1].Value : null;
        }

        private static string ExtractClassName(string code)
        {
            var match = Regex.Match(code, @"class\s+(\w+)");
            return match.Success ? match.Groups[1].Value : null;
        }

        private static void AutoHookEvents(object instance, Control form, Type targetType)
        {
            MethodInfo[] methods = targetType.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (MethodInfo method in methods)
            {
                string name = method.Name;
                if (name.Contains("_"))
                {
                    string[] parts = name.Split(new char[] { '_' }, 2);
                    string controlName = parts[0];
                    string eventName = parts[1];
                    
                    Control ctrl = FindControlRecursive(form, controlName);
                    if (ctrl != null)
                    {
                        EventInfo ev = ctrl.GetType().GetEvent(eventName, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
                        if (ev != null)
                        {
                            try
                            {
                                Delegate del = Delegate.CreateDelegate(ev.EventHandlerType, instance, method);
                                ev.AddEventHandler(ctrl, del);
                            }
                            catch { }
                        }
                    }
                }
            }
        }

        private static void ShowCompileError(Form form, string message)
        {
            RichTextBox txtError = new RichTextBox
            {
                Text = "Lỗi biên dịch logic C#:\n" + message,
                Dock = DockStyle.Top,
                BackColor = System.Drawing.Color.LightPink,
                ForeColor = System.Drawing.Color.DarkRed,
                Height = 300,
                ReadOnly = true
            };
            form.Controls.Add(txtError);
            txtError.BringToFront();
        }
    }
}
