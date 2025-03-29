using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Security;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace UnifiedLauncher
{
    public partial class Main_Window : AntdUI.Window
    {
        Process process = new Process();
        //函数========================================================================================
        #region Functions

        //引用==================================================
        //发送系统消息
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool DestroyIcon(IntPtr hIcon);

        //写PATH系统环境变量
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SendMessageTimeout(
        IntPtr hWnd,
        uint Msg,
        UIntPtr wParam,
        string lParam,
        uint fuFlags,
        uint uTimeout,
        out UIntPtr lpdwResult);

        private const uint WM_SETTINGCHANGE = 0x001A;
        private const uint SMTO_ABORTIFHUNG = 0x0002;

        //创建快捷方式
        [ComImport]
        [Guid("00021401-0000-0000-C000-000000000046")]
        private class ShellLink { }

        [ComImport]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [Guid("000214F9-0000-0000-C000-000000000046")]
        private interface IShellLinkW
        {
            void GetPath([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszFile, int cchMaxPath, out IntPtr pfd, int fFlags);
            void GetIDList(out IntPtr ppidl);
            void SetIDList(IntPtr pidl);
            void GetDescription([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszName, int cchMaxName);
            void SetDescription([MarshalAs(UnmanagedType.LPWStr)] string pszName);
            void GetWorkingDirectory([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszDir, int cchMaxPath);
            void SetWorkingDirectory([MarshalAs(UnmanagedType.LPWStr)] string pszDir);
            void GetArguments([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszArgs, int cchMaxArgs);
            void SetArguments([MarshalAs(UnmanagedType.LPWStr)] string pszArgs);
            void GetHotkey(out short pwHotkey);
            void SetHotkey(short wHotkey);
            void GetShowCmd(out int piShowCmd);
            void SetShowCmd(int iShowCmd);
            void GetIconLocation([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszIconPath, int cchIconPath, out int piIcon);
            void SetIconLocation([MarshalAs(UnmanagedType.LPWStr)] string pszIconPath, int iIcon);
            void SetRelativePath([MarshalAs(UnmanagedType.LPWStr)] string pszPathRel, int dwReserved);
            void Resolve(IntPtr hwnd, int fFlags);
            void SetPath([MarshalAs(UnmanagedType.LPWStr)] string pszFile);
        }

        [ComImport]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [Guid("0000010b-0000-0000-C000-000000000046")]
        private interface IPersistFile
        {
            void GetClassID(out Guid pClassID);
            [PreserveSig]
            int IsDirty();
            void Load([MarshalAs(UnmanagedType.LPWStr)] string pszFileName, int dwMode);
            void Save([MarshalAs(UnmanagedType.LPWStr)] string pszFileName, [MarshalAs(UnmanagedType.Bool)] bool fRemember);
            void SaveCompleted([MarshalAs(UnmanagedType.LPWStr)] string pszFileName);
            void GetCurFile([MarshalAs(UnmanagedType.LPWStr)] out string ppszFileName);
        }
        //引用==================================================

        //HTTP读取文件
        public static string HttpReadFile(string url)
        {
            try
            {
                // 设置安全协议类型（支持TLS 1.2/1.1/1.0）
                ServicePointManager.SecurityProtocol =
                    SecurityProtocolType.Tls12 |
                    SecurityProtocolType.Tls11 |
                    SecurityProtocolType.Tls;

                // 创建带自定义验证的HttpClient
                using (var handler = new HttpClientHandler())
                using (var client = new HttpClient(handler))
                {
                    // 忽略SSL证书验证
                    handler.ServerCertificateCustomValidationCallback =
                        (sender, cert, chain, sslPolicyErrors) => true;

                    // 设置超时时间（10秒）
                    client.Timeout = TimeSpan.FromSeconds(10);

                    // 添加浏览器User-Agent
                    client.DefaultRequestHeaders.UserAgent.ParseAdd(
                        "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 " +
                        "(KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36");

                    // 发送GET请求
                    var response = client.GetAsync(url).Result;
                    response.EnsureSuccessStatusCode();

                    // 读取字节内容
                    var bytes = response.Content.ReadAsByteArrayAsync().Result;

                    // 检测编码
                    var encoding = HttpReadFile_DetectEncoding(response, bytes);

                    // 转换为字符串
                    return encoding.GetString(bytes);
                }
            }
            catch
            {
                return string.Empty;
            }
        }

        //HTTPS读文件(检测编码)
        private static Encoding HttpReadFile_DetectEncoding(HttpResponseMessage response, byte[] bytes)
        {
            try
            {
                // 从Content-Type头获取编码
                var contentType = response.Content.Headers.ContentType;
                if (contentType?.CharSet != null)
                {
                    return Encoding.GetEncoding(contentType.CharSet);
                }
            }
            catch
            {
                // 忽略编码解析错误
            }

            // 尝试通过BOM检测编码
            if (bytes.Length >= 3 && bytes[0] == 0xEF && bytes[1] == 0xBB && bytes[2] == 0xBF)
                return Encoding.UTF8;
            if (bytes.Length >= 2 && bytes[0] == 0xFE && bytes[1] == 0xFF)
                return Encoding.BigEndianUnicode;
            if (bytes.Length >= 2 && bytes[0] == 0xFF && bytes[1] == 0xFE)
                return Encoding.Unicode;

            // 默认使用UTF-8
            return Encoding.UTF8;
        }

        //写日志
        public static void Log(string level, string message)
        {
            // 获取当前时间并格式化
            string timestamp = DateTime.Now.ToString("HH:mm:ss");

            // 构造完整日志条目
            string logContent = $"[{timestamp}][{level}]: {message}";

            // 拼接完整文件路径
            string logPath = Path.Combine(Application.StartupPath, "Log.log");

            // 使用追加模式写入文件
            using (StreamWriter sw = new StreamWriter(logPath, true))
            {
                sw.WriteLine(logContent);
            }

        }

        //文件写一行
        public static void FileAddLine(string content, string filePath)
        {
            using (StreamWriter sw = File.AppendText(filePath))
            {
                sw.WriteLine(content);
            }
        }

        //连通性测试
        public static object CheckUrlConnection(string url)
        {
            // 验证URL格式有效性
            try
            {
                var uri = new Uri(url);
            }
            catch (UriFormatException)
            {
                return "unconnect";
            }

            HttpWebRequest request = null;
            Stopwatch sw = new Stopwatch();

            try
            {
                request = (HttpWebRequest)WebRequest.Create(url);
                request.Timeout = 5000;     // 设置5秒超时
                request.Method = "HEAD";     // 使用HEAD方法减少数据量

                sw.Start();
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    sw.Stop();
                    return sw.ElapsedMilliseconds;
                }
            }
            catch (WebException ex)
            {
                sw.Stop();
                /* 服务器响应但返回错误状态（如404）的情况
                   仍视为连接成功，返回延迟时间 */
                if (ex.Response != null)
                {
                    return sw.ElapsedMilliseconds;
                }
                return "unconnect"; // 真正无法连接的情况
            }
            catch (Exception)
            {
                return "unconnect";
            }
            finally
            {
                request?.Abort(); // 确保释放网络资源
            }
        }

        //执行控制台命令
        public string ExecuteCommand(string command)
        {
            try
            {
                var processInfo = new ProcessStartInfo("cmd.exe", "/c " + command)
                {
                    CreateNoWindow = false,          // 不创建新窗口
                    UseShellExecute = false,        // 不使用系统外壳程序执行
                    RedirectStandardError = true,   // 重定向标准错误
                    RedirectStandardOutput = true   // 重定向标准输出
                };

                using (var process = new Process())
                {
                    process.StartInfo = processInfo;
                    process.Start();

                    // 异步读取输出流和错误流
                    string output = process.StandardOutput.ReadToEnd();
                    string error = process.StandardError.ReadToEnd();

                    process.WaitForExit();  // 等待程序执行完成

                    // 组合输出结果
                    string result = string.IsNullOrEmpty(output) ? "" : output;
                    string errorResult = string.IsNullOrEmpty(error) ? "" : "\n[Error]\n" + error;

                    return $"{result}{errorResult} (ExitCode: {process.ExitCode})";
                }
            }
            catch (Exception ex)
            {
                return $"执行命令时发生异常：{ex.Message}";
            }
        }

        //搜索文件内容
        public bool FileSearchText(string filePath, string searchText)
        {
            try
            {
                // 检查搜索文本是否有效
                if (string.IsNullOrEmpty(searchText))
                    return false;

                // 读取文件全部内容
                string fileContent = File.ReadAllText(filePath);

                // 检查内容是否包含目标文本
                return fileContent.Contains(searchText);
            }
            catch (Exception ex) when (ex is FileNotFoundException ||
                                      ex is IOException ||
                                      ex is UnauthorizedAccessException)
            {
                // 处理常见文件异常：文件不存在、无法访问或IO错误
                return false;
            }
        }

        //弹出系统通知
        public static void ShowNotification(string title, string content)
        {
            NotifyIcon notifyIcon = new NotifyIcon();

            // 创建透明图标
            using (Bitmap bmp = new Bitmap(1, 1))
            {
                bmp.SetPixel(0, 0, Color.Transparent);
                IntPtr hIcon = bmp.GetHicon();
                try
                {
                    notifyIcon.Icon = Icon.FromHandle(hIcon);
                }
                finally
                {
                    DestroyIcon(hIcon);
                }
            }

            notifyIcon.Visible = true;

            // 设置通知关闭后的清理操作
            notifyIcon.BalloonTipClosed += (sender, e) =>
            {
                notifyIcon.Visible = false;
                notifyIcon.Dispose();
            };

            // 显示通知（3000ms=3秒显示时间）
            notifyIcon.ShowBalloonTip(3000, title, content, ToolTipIcon.None);
        }

        // 写入配置（常规）
        public static void Legacy_WriteConfig(string filePath, string key, string value)
        {
            Dictionary<string, string> config = new Dictionary<string, string>();

            // 如果文件存在，先读取现有配置
            if (File.Exists(filePath))
            {
                foreach (string line in File.ReadAllLines(filePath))
                {
                    string[] parts = line.Split(new[] { '=' }, 2);
                    if (parts.Length == 2 && !string.IsNullOrWhiteSpace(parts[0]))
                    {
                        config[parts[0].Trim()] = parts[1].Trim();
                    }
                }
            }

            // 添加/更新键值
            config[key] = value;

            // 写入所有配置项
            File.WriteAllLines(filePath,
                config.Select(kvp => $"{kvp.Key}={kvp.Value}"),
                Encoding.UTF8);
        }

        // 读取配置（常规）
        public static string Legacy_ReadConfig(string filePath, string key)
        {
            if (!File.Exists(filePath)) return null;

            foreach (string line in File.ReadAllLines(filePath))
            {
                string[] parts = line.Split(new[] { '=' }, 2);
                if (parts.Length == 2 &&
                    parts[0].Trim().Equals(key, StringComparison.OrdinalIgnoreCase))
                {
                    return parts[1].Trim();
                }
            }
            return null;
        }

        //写注册表项
        //rootKey常用常量
        //Registry.CurrentUser (HKEY_CURRENT_USER)
        //Registry.LocalMachine (HKEY_LOCAL_MACHINE)
        //Registry.ClassesRoot (HKEY_CLASSES_ROOT)

        /*valueKind：支持的类型包括：
        String：字符串值
        DWord：32位整数
        QWord：64位整数
        Binary：二进制数据
        MultiString：字符串数组*/
        public static bool WriteRegistryValue(RegistryKey rootKey, string subKeyPath, string valueName, object value, RegistryValueKind valueKind)
        {
            try
            {
                if (rootKey == null)
                    throw new ArgumentNullException(nameof(rootKey));

                if (string.IsNullOrEmpty(subKeyPath))
                    throw new ArgumentException("子项路径不能为空", nameof(subKeyPath));

                using (RegistryKey subKey = rootKey.CreateSubKey(subKeyPath))
                {
                    if (subKey == null) return false;

                    subKey.SetValue(valueName, value, valueKind);
                    return true;
                }
            }
            catch (UnauthorizedAccessException)
            {
                // 权限不足，可能需要以管理员身份运行
                throw;
            }
            catch (Exception ex)
            {
                // 记录异常或处理其他错误
                Console.WriteLine($"写入注册表失败: {ex.Message}");
                return false;
            }
        }

        //读注册表项
        public static object ReadRegistryValue(RegistryKey rootKey, string subKeyPath, string valueName, object defaultValue = null)
        {
            try
            {
                if (rootKey == null)
                    throw new ArgumentNullException(nameof(rootKey));

                if (string.IsNullOrEmpty(subKeyPath))
                    throw new ArgumentException("子项路径不能为空", nameof(subKeyPath));

                using (RegistryKey subKey = rootKey.OpenSubKey(subKeyPath, false))
                {
                    // 子项不存在时返回默认值
                    if (subKey == null) return defaultValue;

                    // 获取值（值不存在时返回默认值）
                    return subKey.GetValue(valueName, defaultValue);
                }
            }
            catch (UnauthorizedAccessException)
            {
                // 权限不足，可能需要管理员权限
                throw;
            }
            catch (Exception ex)
            {
                // 记录异常或处理其他错误
                Console.WriteLine($"读取注册表失败: {ex.Message}");
                return defaultValue;
            }
        }

        // 写入配置（支持节）
        public static void WriteConfig(string filePath, string section, string key, string value)
        {
            var sections = ParseConfigFile(filePath);

            // 创建或更新节
            if (!sections.ContainsKey(section))
            {
                sections[section] = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            }

            // 更新键值
            sections[section][key.Trim()] = value;

            // 生成配置文件内容
            var lines = new List<string>();

            // 处理默认节（空节名）
            if (sections.TryGetValue("", out var defaultSection) && defaultSection.Count > 0)
            {
                lines.AddRange(defaultSection.Select(kvp => $"{kvp.Key}={kvp.Value}"));
            }

            // 处理带节名的配置（按字母顺序排序）
            foreach (var sec in sections.Keys
                .Where(s => !string.IsNullOrEmpty(s))
                .OrderBy(s => s, StringComparer.OrdinalIgnoreCase))
            {
                // 添加节分隔空行
                if (lines.Count > 0) lines.Add("");

                lines.Add($"[{sec}]");
                lines.AddRange(sections[sec].Select(kvp => $"{kvp.Key}={kvp.Value}"));
            }

            File.WriteAllLines(filePath, lines, Encoding.UTF8);
        }

        // 读取配置（支持节）
        public static string ReadConfig(string filePath, string section, string key)
        {
            if (!File.Exists(filePath)) return null;

            var sections = ParseConfigFile(filePath);

            if (sections.TryGetValue(section, out var sectionData) &&
                sectionData.TryGetValue(key, out var value))
            {
                return value;
            }
            return null;
        }

        // 解析配置文件为节字典(读写配置)
        private static Dictionary<string, Dictionary<string, string>> ParseConfigFile(string filePath)
        {
            var sections = new Dictionary<string, Dictionary<string, string>>(StringComparer.OrdinalIgnoreCase);
            string currentSection = "";

            if (File.Exists(filePath))
            {
                foreach (var line in File.ReadAllLines(filePath))
                {
                    var trimmed = line.Trim();

                    // 处理节头
                    if (trimmed.StartsWith("[") && trimmed.EndsWith("]"))
                    {
                        currentSection = trimmed.Substring(1, trimmed.Length - 2).Trim();
                        if (!sections.ContainsKey(currentSection))
                        {
                            sections[currentSection] = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
                        }
                        continue;
                    }

                    // 处理键值对
                    var parts = line.Split(new[] { '=' }, 2);
                    if (parts.Length == 2 && !string.IsNullOrWhiteSpace(parts[0]))
                    {
                        var k = parts[0].Trim();
                        var v = parts[1].Trim();

                        if (!sections.ContainsKey(currentSection))
                        {
                            sections[currentSection] = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
                        }

                        sections[currentSection][k] = v;
                    }
                }
            }
            return sections;
        }

        //写PATH系统环境变量
        public static void AddPath(string directoryPath, bool systemLevel = true)
        {
            if (string.IsNullOrWhiteSpace(directoryPath))
                throw new ArgumentException("目录路径不能为空");

            RegistryKey registryKey = systemLevel ?
                Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\Session Manager\Environment", true) :
                Registry.CurrentUser.OpenSubKey(@"Environment", true);

            if (registryKey == null)
                throw new NullReferenceException("注册表项未找到");

            try
            {
                string currentPath = registryKey.GetValue("PATH", "", RegistryValueOptions.DoNotExpandEnvironmentNames).ToString();
                string[] paths = currentPath.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                // 检查是否已存在（不区分大小写）
                if (paths.Any(p => p.Trim().Equals(directoryPath.Trim(), StringComparison.OrdinalIgnoreCase)))
                    return;

                // 追加新路径
                string newPath = currentPath.TrimEnd(';') + ";" + directoryPath.Trim();

                // 更新注册表
                registryKey.SetValue("PATH", newPath, RegistryValueKind.ExpandString);

                // 广播环境变量变更通知
                SendMessageTimeout(
                    new IntPtr(0xFFFF), // HWND_BROADCAST
                    WM_SETTINGCHANGE,
                    UIntPtr.Zero,
                    "Environment",
                    SMTO_ABORTIFHUNG,
                    5000,
                    out UIntPtr _);
            }
            finally
            {
                registryKey.Close();
            }
        }

        //创建快捷方式
        public static bool CreateShortcut(string targetPath, string shortcutPath)
        {
            if (!File.Exists(targetPath)) return false;

            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(shortcutPath));

                var shellLink = (IShellLinkW)new ShellLink();
                shellLink.SetPath(targetPath);
                shellLink.SetWorkingDirectory(Path.GetDirectoryName(targetPath));
                shellLink.SetIconLocation(targetPath, 0);  // 使用目标文件自身图标

                var persistFile = (IPersistFile)shellLink;
                persistFile.Save(shortcutPath, false);
                return true;
            }
            catch
            {
                return false;
            }
        }

        // 基本朗读功能封装
        public void Speak(string text)
        {
            var synthesizer = new SpeechSynthesizer();

            // 设置朗读完成自动释放资源
            synthesizer.SpeakCompleted += (s, e) => synthesizer.Dispose();

            // 异步朗读（非阻塞）
            synthesizer.SpeakAsync(text);
        }

        // 带语速控制的增强版（可选）
        public void SpeedSpeak(string text, int rate = 0)
        {
            var synthesizer = new SpeechSynthesizer();
            synthesizer.Rate = rate;  // -10 到 10 的语速

            synthesizer.SpeakCompleted += (s, e) => synthesizer.Dispose();
            synthesizer.SpeakAsync(text);
        }

        //程序自启动
        public static bool SetAutoStart(bool enable,string exePath = null,RegistryKey registryRoot = null,string keyName = null)
        {
            try
            {
                // 设置默认值
                exePath = exePath ?? Application.ExecutablePath;
                registryRoot = registryRoot ?? Registry.CurrentUser;
                keyName = keyName ?? Application.ProductName;

                // 获取注册表Run子项
                using (var runKey = registryRoot.OpenSubKey(
                    @"Software\Microsoft\Windows\CurrentVersion\Run",
                    true)) // 需要写权限
                {
                    if (runKey == null)
                    {
                        throw new Exception("无法打开注册表Run项");
                    }

                    if (enable)
                    {
                        // 设置自启动
                        runKey.SetValue(keyName, exePath);
                    }
                    else
                    {
                        // 移除自启动
                        runKey.DeleteValue(keyName, throwOnMissingValue: false);
                    }
                }
                return true;
            }
            catch (SecurityException ex)
            {
                MessageBox.Show($"需要管理员权限才能修改系统级自启动设置\n{ex.Message}");
                return false;
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show($"访问被拒绝，请以管理员身份运行\n{ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"操作失败: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// 检查当前自启动状态
        /// </summary>
        public static bool IsAutoStartEnabled(RegistryKey registryRoot = null,
                                            string keyName = null)
        {
            try
            {
                registryRoot = registryRoot ?? Registry.CurrentUser;
                keyName = keyName ?? Application.ProductName;

                using (var runKey = registryRoot.OpenSubKey(
                    @"Software\Microsoft\Windows\CurrentVersion\Run"))
                {
                    var value = runKey?.GetValue(keyName);
                    return value != null && value.ToString().Equals(
                        Application.ExecutablePath,
                        StringComparison.OrdinalIgnoreCase);
                }
            }
            catch
            {
                return false;
            }
        }
        #endregion
        //变量========================================================================================
        public static string Title = "Unified Launcher";
        public static string Fork = "Release";
        public static string Version = "1.1.0.0";
        public static string RunPath = Directory.GetCurrentDirectory();
        public static string ConfigPath = RunPath + "\\config.ini";
        public static string ProgramsPath = RunPath + "\\Programs.ini";
        //事件========================================================================================
        public Main_Window()
        {
            InitializeComponent();

            //标题
            pageHeader.Text = $"{Title} {Fork}{Version}";
            label_AboutVersion.Text = $"当前程序分支:{Fork}  版本:{Version}";

            //写Programs.ini
            if (!File.Exists(ProgramsPath))
            {
                WriteConfig(ProgramsPath, "info", "ProgramsNum", "1");
                WriteConfig(ProgramsPath, "1", "Name", "Explorer");
                WriteConfig(ProgramsPath, "1", "Path", "C:\\Windows\\explorer.exe");
                WriteConfig(ProgramsPath, "1", "CmdLine", "");
            }

            //初始化下拉菜单
            select_SelectPrograms.Items.Clear();
            for (int i = 0; i < int.Parse(ReadConfig(ProgramsPath, "info", "ProgramsNum")); i++)
            {
                select_SelectPrograms.Items.Add(ReadConfig(ProgramsPath, $"{i + 1}", "Name"));
            }

            //写config.ini
            if (!File.Exists(ConfigPath))
            {
                WriteConfig(ConfigPath, "config", "SelectProgram", "0");
                WriteConfig(ConfigPath, "config", "CmdLine", "");
                WriteConfig(ConfigPath, "config", "AutoStart", "False");
                WriteConfig(ConfigPath, "config", "AutoLaunch", "False");
            }
            select_SelectPrograms.SelectedIndex = int.Parse(ReadConfig(ConfigPath, "config", "SelectProgram"));


            //初始化设置
            input_CmdLine.Text = ReadConfig(ConfigPath, "config", "CmdLine");
            if (ReadConfig(ConfigPath, "config", "AutoStart") == "True")
            {
                switch_AutoStart.Checked = true;
                SetAutoStart(true);
            }
            else
            {
                switch_AutoStart.Checked = false;
                SetAutoStart(false);
            }

            if (ReadConfig(ConfigPath, "config", "AutoLaunch") == "True")
            {
                switch_StartLaunch.Checked = true;
            }
            else
            {
                switch_StartLaunch.Checked = false;
            }

            //初始化提示气泡
            tooltipComponent.SetTip(switch_StartLaunch, "启动器打开时自动启动上次选择的程序");

            //执行配置
            if (ReadConfig(ConfigPath, "config", "AutoLaunch") == "True")
            {
                button_Launch_Click(null, EventArgs.Empty);
            }

            //初始化
            tabs_Main.SelectedIndex = 0;
        }

        private void button_OpenProgramsEditor_Click(object sender, EventArgs e)
        {
            ProgramsEditor programsEditor = new ProgramsEditor();
            programsEditor.ShowDialog();
        }

        private async void button_About_Bilibili_Click(object sender, EventArgs e)
        {
            try
            {
                AntdUI.Notification.open(new AntdUI.Notification.Config(this, "", "", AntdUI.TType.None, AntdUI.TAlignFrom.TL)
                {
                    Title = "已打开网页！",
                    Text = $"已为您打开网页https://space.bilibili.com/1794899926",
                    Icon = AntdUI.TType.Success,
                    Align = AntdUI.TAlignFrom.TR
                });
                await Task.Delay(1000);
                Process.Start("https://space.bilibili.com/1794899926");

            }
            catch (Exception ex)
            {
                AntdUI.Notification.open(new AntdUI.Notification.Config(this, "", "", AntdUI.TType.None, AntdUI.TAlignFrom.TL)
                {
                    Title = "发生错误！",
                    Text = $"无法打开网页https://space.bilibili.com/1794899926\n错误原因:{ex.Message}",
                    Icon = AntdUI.TType.Error,
                    Align = AntdUI.TAlignFrom.TR
                });
            }


        }

        private async void button_About_Github_Click(object sender, EventArgs e)
        {
            try
            {
                AntdUI.Notification.open(new AntdUI.Notification.Config(this, "", "", AntdUI.TType.None, AntdUI.TAlignFrom.TL)
                {
                    Title = "已打开网页！",
                    Text = $"已为您打开网页https://github.com/bilibilihuazi",
                    Icon = AntdUI.TType.Success,
                    Align = AntdUI.TAlignFrom.TR
                });
                await Task.Delay(1000);
                Process.Start("https://github.com/bilibilihuazi");
            }
            catch (Exception ex)
            {
                AntdUI.Notification.open(new AntdUI.Notification.Config(this, "", "", AntdUI.TType.None, AntdUI.TAlignFrom.TL)
                {
                    Title = "发生错误！",
                    Text = $"无法打开网页https://github.com/bilibilihuazi\n错误原因:{ex.Message}",
                    Icon = AntdUI.TType.Error,
                    Align = AntdUI.TAlignFrom.TR
                });
            }
        }

        private void tabs_Main_SelectedIndexChanged(object sender, AntdUI.IntEventArgs e)
        {
            if (tabs_Main.SelectedIndex == 0) 
            {
                select_SelectPrograms.Items.Clear();
                for (int i = 0; i < int.Parse(ReadConfig(ProgramsPath, "info", "ProgramsNum")); i++) 
                {
                    select_SelectPrograms.Items.Add(ReadConfig(ProgramsPath, $"{i + 1}", "Name"));
                }
            }
        }

        private void select_SelectPrograms_SelectedIndexChanged(object sender, AntdUI.IntEventArgs e)
        {
            WriteConfig(ConfigPath, "config", "SelectProgram", $"{select_SelectPrograms.SelectedIndex}");
            try
            {
                Icon ProgramIcon = Icon.ExtractAssociatedIcon(ReadConfig(ProgramsPath, $"{select_SelectPrograms.SelectedIndex + 1}", "Path"));
                image3D_ProgramIcon.Image = ProgramIcon.ToBitmap();
            }
            catch (Exception ex)
            {
                AntdUI.Notification.open(new AntdUI.Notification.Config(this, "", "", AntdUI.TType.None, AntdUI.TAlignFrom.TR)
                {
                    Title = "发生错误！",
                    Text = $"无法获取应用程序图标，错误原因:{ex.Message}",
                    Icon = AntdUI.TType.Error
                });
            }

            label_ProgramName.Text = $"程序名称：{ReadConfig(ProgramsPath, $"{select_SelectPrograms.SelectedIndex + 1}", "Name")}";
            label_ProgramPath.Text = $"程序路径：{ReadConfig(ProgramsPath, $"{select_SelectPrograms.SelectedIndex + 1}", "Path")}";

            if (ReadConfig(ProgramsPath, $"{select_SelectPrograms.SelectedIndex + 1}", "CmdLine") == "")
            {
                if (ReadConfig(ConfigPath, "config", "CmdLine") == "")
                {
                    label_ProgramCmdLine.Text = $"启动参数：(空) + (空)";
                }
                else
                {
                    label_ProgramCmdLine.Text = $"启动参数：{ReadConfig(ConfigPath, "config", "CmdLine")} + (空)";
                }
            }
            else
            {
                if (ReadConfig(ConfigPath, "config", "CmdLine") == "")
                {
                    label_ProgramCmdLine.Text = $"启动参数：(空) + {ReadConfig(ProgramsPath, $"{select_SelectPrograms.SelectedIndex + 1}", "CmdLine")}";
                }
                else
                {
                    label_ProgramCmdLine.Text = $"启动参数：{ReadConfig(ConfigPath, "config", "CmdLine")} + {ReadConfig(ProgramsPath, $"{select_SelectPrograms.SelectedIndex + 1}", "CmdLine")}";
                }
            }
        }

        private async void button_Launch_Click(object sender, EventArgs e)
        {
            if (select_SelectPrograms.SelectedIndex != -1)
            {
                progress_Launch.Value = 0.3F;
                process.StartInfo.FileName = ReadConfig(ProgramsPath, $"{select_SelectPrograms.SelectedIndex + 1}", "Path");
                process.StartInfo.Arguments = $"{ReadConfig(ProgramsPath, $"{select_SelectPrograms.SelectedIndex + 1}", "CmdLine")} {ReadConfig(ConfigPath, "config", "CmdLine")}";

                if (button_Launch.Text == "启动")
                {
                    try
                    {
                        process.Start();
                        progress_Launch.Value = 0.6F;

                        AntdUI.Notification.open(new AntdUI.Notification.Config(this, "", "", AntdUI.TType.None, AntdUI.TAlignFrom.TR)
                        {
                            Title = "启动成功！",
                            Text = "应用程序已启动！",
                            Icon = AntdUI.TType.Success
                        });
                        progress_Launch.Value = 1F;
                        progress_Launch.State = AntdUI.TType.Success;

                        button_Launch.Text = "结束";
                        button_Launch.Type = AntdUI.TTypeMini.Error;
                        button_Launch.Icon = Properties.Resources.MaterialSymbolsStopCircleOutlineRounded__1_;
                        select_SelectPrograms.Enabled = false;

                        await Task.Run(() => process.WaitForExit());
                        button_Launch.Text = "启动";
                        button_Launch.Type = AntdUI.TTypeMini.Primary;
                        button_Launch.Icon = Properties.Resources.MaterialSymbolsPlayCircleOutlineRounded__1_;
                        select_SelectPrograms.Enabled = true;
                        progress_Launch.Value = 0F;
                        progress_Launch.State = AntdUI.TType.None;

                        AntdUI.Notification.open(new AntdUI.Notification.Config(this, "", "", AntdUI.TType.None, AntdUI.TAlignFrom.TR)
                        {
                            Title = "应用程序已退出",
                            Text = "应用程序进程已终止",
                            Icon = AntdUI.TType.Success
                        });
                    }
                    catch (Exception ex)
                    {
                        AntdUI.Notification.open(new AntdUI.Notification.Config(this, "", "", AntdUI.TType.None, AntdUI.TAlignFrom.TR)
                        {
                            Title = "发生错误！",
                            Text = $"无法启动应用程序（错误原因:{ex.Message}）",
                            Icon = AntdUI.TType.Error
                        });
                        progress_Launch.Value = 1F;
                        progress_Launch.State = AntdUI.TType.Error;
                    }
                }
                else
                {
                    if (!process.HasExited)
                    {
                        try
                        {
                            process.Kill();
                            AntdUI.Notification.open(new AntdUI.Notification.Config(this, "", "", AntdUI.TType.None, AntdUI.TAlignFrom.TR)
                            {
                                Title = "成功结束！",
                                Text = "已结束应用程序进程！",
                                Icon = AntdUI.TType.Success
                            });
                            button_Launch.Text = "启动";
                            button_Launch.Type = AntdUI.TTypeMini.Primary;
                            button_Launch.Icon = Properties.Resources.MaterialSymbolsPlayCircleOutlineRounded__1_;
                            select_SelectPrograms.Enabled = true;

                        }
                        catch (Exception ex)
                        {
                            AntdUI.Notification.open(new AntdUI.Notification.Config(this, "", "", AntdUI.TType.None, AntdUI.TAlignFrom.TR)
                            {
                                Title = "发生错误！",
                                Text = $"无法结束应用程序（错误原因：{ex.Message}）",
                                Icon = AntdUI.TType.Error
                            });
                        }
                    }

                }
                
            }
        }

        private void input_CmdLine_TextChanged(object sender, EventArgs e)
        {
            WriteConfig(ConfigPath, "config", "CmdLine", input_CmdLine.Text);
        }

        private void switch1_CheckedChanged(object sender, AntdUI.BoolEventArgs e)
        {
            if (switch_AutoStart.Checked)
            {
                WriteConfig(ConfigPath, "config", "AutoStart", "True");
                SetAutoStart(true);
            }
            else
            {
                WriteConfig(ConfigPath, "config", "AutoStart", "False");
                SetAutoStart(false);
            }
        }

        private void switch_StartLaunch_CheckedChanged(object sender, AntdUI.BoolEventArgs e)
        {
            if (switch_StartLaunch.Checked)
            {
                WriteConfig(ConfigPath, "config", "AutoLaunch", "True");
            }
            else
            {
                WriteConfig(ConfigPath, "config", "AutoLaunch", "False");
            }
        }

        private void button_UpdateLog_Click(object sender, EventArgs e)
        {
            AntdUI.Modal.open(new AntdUI.Modal.Config(this, "", "")
            {
                Title = "更新日志",
                Content = "Release1.1.0.0更新日志:\n更新:\n    -在\"关于\"界面添加更新日志按钮\n修改:\n    -删除主页上方的\"当前执行:\"标签\n    -修复了启动时的主页默认为设置的问题",
                Icon = AntdUI.TType.Info
            });
        }
    }
}
