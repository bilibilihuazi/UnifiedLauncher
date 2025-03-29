namespace UnifiedLauncher
{
    partial class Main_Window
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            AntdUI.Tabs.StyleCard styleCard1 = new AntdUI.Tabs.StyleCard();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main_Window));
            this.pageHeader = new AntdUI.PageHeader();
            this.tabs_Main = new AntdUI.Tabs();
            this.Home = new AntdUI.TabPage();
            this.label_Progress = new AntdUI.Label();
            this.progress_Launch = new AntdUI.Progress();
            this.label_ProgramCmdLine = new AntdUI.Label();
            this.select_SelectPrograms = new AntdUI.Select();
            this.label_ProgramPath = new AntdUI.Label();
            this.label_ProgramName = new AntdUI.Label();
            this.image3D_ProgramIcon = new AntdUI.Image3D();
            this.button_Launch = new AntdUI.Button();
            this.Settings = new AntdUI.TabPage();
            this.switch_StartLaunch = new AntdUI.Switch();
            this.label_StartLaunch = new AntdUI.Label();
            this.switch_AutoStart = new AntdUI.Switch();
            this.label_AutoStart = new AntdUI.Label();
            this.input_CmdLine = new AntdUI.Input();
            this.label_Settings_CmdLine = new AntdUI.Label();
            this.button_Settings_OpenProgramsEditor = new AntdUI.Button();
            this.About = new AntdUI.TabPage();
            this.label_AboutVersion = new AntdUI.Label();
            this.button_About_Github = new AntdUI.Button();
            this.button_About_Bilibili = new AntdUI.Button();
            this.label_About_Info3 = new AntdUI.Label();
            this.label_About_Info2 = new AntdUI.Label();
            this.label_About_Info1 = new AntdUI.Label();
            this.image3D_About_Icon = new AntdUI.Image3D();
            this.tooltipComponent = new AntdUI.TooltipComponent();
            this.tabs_Main.SuspendLayout();
            this.Home.SuspendLayout();
            this.Settings.SuspendLayout();
            this.About.SuspendLayout();
            this.SuspendLayout();
            // 
            // pageHeader
            // 
            this.pageHeader.HandCursor = System.Windows.Forms.Cursors.Default;
            this.pageHeader.Location = new System.Drawing.Point(0, 0);
            this.pageHeader.MaximizeBox = false;
            this.pageHeader.Name = "pageHeader";
            this.pageHeader.ShowButton = true;
            this.pageHeader.ShowIcon = true;
            this.pageHeader.Size = new System.Drawing.Size(600, 30);
            this.pageHeader.TabIndex = 0;
            this.pageHeader.Text = "Main_Window";
            // 
            // tabs_Main
            // 
            this.tabs_Main.Centered = true;
            this.tabs_Main.Controls.Add(this.Home);
            this.tabs_Main.Controls.Add(this.Settings);
            this.tabs_Main.Controls.Add(this.About);
            this.tabs_Main.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabs_Main.Gap = 12;
            this.tabs_Main.HandCursor = System.Windows.Forms.Cursors.Default;
            this.tabs_Main.IconRatio = 1F;
            this.tabs_Main.Location = new System.Drawing.Point(0, 30);
            this.tabs_Main.Name = "tabs_Main";
            this.tabs_Main.Pages.Add(this.Home);
            this.tabs_Main.Pages.Add(this.Settings);
            this.tabs_Main.Pages.Add(this.About);
            this.tabs_Main.Size = new System.Drawing.Size(600, 270);
            this.tabs_Main.Style = styleCard1;
            this.tabs_Main.TabIndex = 1;
            this.tabs_Main.Text = "tabs";
            this.tabs_Main.Type = AntdUI.TabType.Card;
            this.tabs_Main.SelectedIndexChanged += new AntdUI.IntEventHandler(this.tabs_Main_SelectedIndexChanged);
            // 
            // Home
            // 
            this.Home.Controls.Add(this.label_Progress);
            this.Home.Controls.Add(this.progress_Launch);
            this.Home.Controls.Add(this.label_ProgramCmdLine);
            this.Home.Controls.Add(this.select_SelectPrograms);
            this.Home.Controls.Add(this.label_ProgramPath);
            this.Home.Controls.Add(this.label_ProgramName);
            this.Home.Controls.Add(this.image3D_ProgramIcon);
            this.Home.Controls.Add(this.button_Launch);
            this.Home.Icon = global::UnifiedLauncher.Properties.Resources.CibLaravelNova;
            this.Home.Location = new System.Drawing.Point(3, 33);
            this.Home.Name = "Home";
            this.Home.Size = new System.Drawing.Size(594, 234);
            this.Home.TabIndex = 0;
            this.Home.Text = "主页";
            // 
            // label_Progress
            // 
            this.label_Progress.Location = new System.Drawing.Point(9, 134);
            this.label_Progress.Name = "label_Progress";
            this.label_Progress.Size = new System.Drawing.Size(75, 23);
            this.label_Progress.TabIndex = 10;
            this.label_Progress.Text = "当前执行:";
            // 
            // progress_Launch
            // 
            this.progress_Launch.ContainerControl = this;
            this.progress_Launch.HandCursor = System.Windows.Forms.Cursors.Default;
            this.progress_Launch.Location = new System.Drawing.Point(9, 156);
            this.progress_Launch.Name = "progress_Launch";
            this.progress_Launch.Size = new System.Drawing.Size(576, 23);
            this.progress_Launch.TabIndex = 9;
            this.progress_Launch.Text = "";
            // 
            // label_ProgramCmdLine
            // 
            this.label_ProgramCmdLine.ForeColor = System.Drawing.Color.Black;
            this.label_ProgramCmdLine.HandCursor = System.Windows.Forms.Cursors.Default;
            this.label_ProgramCmdLine.Location = new System.Drawing.Point(92, 61);
            this.label_ProgramCmdLine.Name = "label_ProgramCmdLine";
            this.label_ProgramCmdLine.Shadow = 10;
            this.label_ProgramCmdLine.ShadowColor = System.Drawing.Color.Black;
            this.label_ProgramCmdLine.Size = new System.Drawing.Size(484, 23);
            this.label_ProgramCmdLine.TabIndex = 8;
            this.label_ProgramCmdLine.Text = "启动参数：";
            // 
            // select_SelectPrograms
            // 
            this.select_SelectPrograms.HandCursor = System.Windows.Forms.Cursors.Default;
            this.select_SelectPrograms.List = true;
            this.select_SelectPrograms.Location = new System.Drawing.Point(9, 185);
            this.select_SelectPrograms.MaxCount = 10;
            this.select_SelectPrograms.Name = "select_SelectPrograms";
            this.select_SelectPrograms.Placement = AntdUI.TAlignFrom.TR;
            this.select_SelectPrograms.Size = new System.Drawing.Size(397, 46);
            this.select_SelectPrograms.TabIndex = 7;
            this.select_SelectPrograms.Text = "select1";
            this.select_SelectPrograms.SelectedIndexChanged += new AntdUI.IntEventHandler(this.select_SelectPrograms_SelectedIndexChanged);
            // 
            // label_ProgramPath
            // 
            this.label_ProgramPath.ForeColor = System.Drawing.Color.Black;
            this.label_ProgramPath.HandCursor = System.Windows.Forms.Cursors.Default;
            this.label_ProgramPath.Location = new System.Drawing.Point(92, 32);
            this.label_ProgramPath.Name = "label_ProgramPath";
            this.label_ProgramPath.Shadow = 10;
            this.label_ProgramPath.ShadowColor = System.Drawing.Color.Black;
            this.label_ProgramPath.Size = new System.Drawing.Size(484, 23);
            this.label_ProgramPath.TabIndex = 4;
            this.label_ProgramPath.Text = "程序路径：";
            // 
            // label_ProgramName
            // 
            this.label_ProgramName.ForeColor = System.Drawing.Color.Black;
            this.label_ProgramName.HandCursor = System.Windows.Forms.Cursors.Default;
            this.label_ProgramName.Location = new System.Drawing.Point(92, 3);
            this.label_ProgramName.Name = "label_ProgramName";
            this.label_ProgramName.Shadow = 10;
            this.label_ProgramName.ShadowColor = System.Drawing.Color.Black;
            this.label_ProgramName.Size = new System.Drawing.Size(484, 23);
            this.label_ProgramName.TabIndex = 3;
            this.label_ProgramName.Text = "程序名称：";
            // 
            // image3D_ProgramIcon
            // 
            this.image3D_ProgramIcon.HandCursor = System.Windows.Forms.Cursors.Default;
            this.image3D_ProgramIcon.Image = global::UnifiedLauncher.Properties.Resources.CibLaravelNova;
            this.image3D_ProgramIcon.ImageFit = AntdUI.TFit.Fill;
            this.image3D_ProgramIcon.Location = new System.Drawing.Point(0, 3);
            this.image3D_ProgramIcon.Name = "image3D_ProgramIcon";
            this.image3D_ProgramIcon.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.image3D_ProgramIcon.Size = new System.Drawing.Size(86, 86);
            this.image3D_ProgramIcon.TabIndex = 2;
            this.image3D_ProgramIcon.Text = "Icon";
            // 
            // button_Launch
            // 
            this.button_Launch.HandCursor = System.Windows.Forms.Cursors.Default;
            this.button_Launch.Icon = global::UnifiedLauncher.Properties.Resources.MaterialSymbolsPlayCircleOutlineRounded__1_;
            this.button_Launch.IconRatio = 1F;
            this.button_Launch.ImeMode = System.Windows.Forms.ImeMode.On;
            this.button_Launch.Location = new System.Drawing.Point(412, 185);
            this.button_Launch.Name = "button_Launch";
            this.button_Launch.Size = new System.Drawing.Size(173, 46);
            this.button_Launch.TabIndex = 0;
            this.button_Launch.Text = "启动";
            this.button_Launch.Type = AntdUI.TTypeMini.Primary;
            this.button_Launch.Click += new System.EventHandler(this.button_Launch_Click);
            // 
            // Settings
            // 
            this.Settings.Controls.Add(this.switch_StartLaunch);
            this.Settings.Controls.Add(this.label_StartLaunch);
            this.Settings.Controls.Add(this.switch_AutoStart);
            this.Settings.Controls.Add(this.label_AutoStart);
            this.Settings.Controls.Add(this.input_CmdLine);
            this.Settings.Controls.Add(this.label_Settings_CmdLine);
            this.Settings.Controls.Add(this.button_Settings_OpenProgramsEditor);
            this.Settings.Icon = global::UnifiedLauncher.Properties.Resources.CiSettings;
            this.Settings.Location = new System.Drawing.Point(-594, -234);
            this.Settings.Name = "Settings";
            this.Settings.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Settings.Size = new System.Drawing.Size(594, 234);
            this.Settings.TabIndex = 1;
            this.Settings.Text = "设置";
            // 
            // switch_StartLaunch
            // 
            this.switch_StartLaunch.HandCursor = System.Windows.Forms.Cursors.Default;
            this.switch_StartLaunch.Location = new System.Drawing.Point(116, 126);
            this.switch_StartLaunch.Name = "switch_StartLaunch";
            this.switch_StartLaunch.Size = new System.Drawing.Size(56, 30);
            this.switch_StartLaunch.TabIndex = 5;
            this.switch_StartLaunch.CheckedChanged += new AntdUI.BoolEventHandler(this.switch_StartLaunch_CheckedChanged);
            // 
            // label_StartLaunch
            // 
            this.label_StartLaunch.HandCursor = System.Windows.Forms.Cursors.Default;
            this.label_StartLaunch.Location = new System.Drawing.Point(9, 126);
            this.label_StartLaunch.Name = "label_StartLaunch";
            this.label_StartLaunch.Size = new System.Drawing.Size(115, 30);
            this.label_StartLaunch.TabIndex = 6;
            this.label_StartLaunch.Text = "启时自动启动程序:";
            // 
            // switch_AutoStart
            // 
            this.switch_AutoStart.HandCursor = System.Windows.Forms.Cursors.Default;
            this.switch_AutoStart.Location = new System.Drawing.Point(68, 90);
            this.switch_AutoStart.Name = "switch_AutoStart";
            this.switch_AutoStart.Size = new System.Drawing.Size(56, 30);
            this.switch_AutoStart.TabIndex = 3;
            this.switch_AutoStart.CheckedChanged += new AntdUI.BoolEventHandler(this.switch1_CheckedChanged);
            // 
            // label_AutoStart
            // 
            this.label_AutoStart.HandCursor = System.Windows.Forms.Cursors.Default;
            this.label_AutoStart.Location = new System.Drawing.Point(9, 90);
            this.label_AutoStart.Name = "label_AutoStart";
            this.label_AutoStart.Size = new System.Drawing.Size(64, 30);
            this.label_AutoStart.TabIndex = 4;
            this.label_AutoStart.Text = "开机自启:";
            // 
            // input_CmdLine
            // 
            this.input_CmdLine.HandCursor = System.Windows.Forms.Cursors.Default;
            this.input_CmdLine.Location = new System.Drawing.Point(87, 54);
            this.input_CmdLine.Name = "input_CmdLine";
            this.input_CmdLine.Size = new System.Drawing.Size(246, 30);
            this.input_CmdLine.TabIndex = 2;
            this.input_CmdLine.TextChanged += new System.EventHandler(this.input_CmdLine_TextChanged);
            // 
            // label_Settings_CmdLine
            // 
            this.label_Settings_CmdLine.Location = new System.Drawing.Point(9, 54);
            this.label_Settings_CmdLine.Name = "label_Settings_CmdLine";
            this.label_Settings_CmdLine.Size = new System.Drawing.Size(88, 30);
            this.label_Settings_CmdLine.TabIndex = 1;
            this.label_Settings_CmdLine.Text = "全局启动参数:";
            // 
            // button_Settings_OpenProgramsEditor
            // 
            this.button_Settings_OpenProgramsEditor.HandCursor = System.Windows.Forms.Cursors.Default;
            this.button_Settings_OpenProgramsEditor.Location = new System.Drawing.Point(9, 7);
            this.button_Settings_OpenProgramsEditor.Name = "button_Settings_OpenProgramsEditor";
            this.button_Settings_OpenProgramsEditor.Size = new System.Drawing.Size(126, 41);
            this.button_Settings_OpenProgramsEditor.TabIndex = 0;
            this.button_Settings_OpenProgramsEditor.Text = "编辑程序列表";
            this.button_Settings_OpenProgramsEditor.Type = AntdUI.TTypeMini.Primary;
            this.button_Settings_OpenProgramsEditor.Click += new System.EventHandler(this.button_OpenProgramsEditor_Click);
            // 
            // About
            // 
            this.About.Controls.Add(this.label_AboutVersion);
            this.About.Controls.Add(this.button_About_Github);
            this.About.Controls.Add(this.button_About_Bilibili);
            this.About.Controls.Add(this.label_About_Info3);
            this.About.Controls.Add(this.label_About_Info2);
            this.About.Controls.Add(this.label_About_Info1);
            this.About.Controls.Add(this.image3D_About_Icon);
            this.About.Icon = global::UnifiedLauncher.Properties.Resources.IxAbout;
            this.About.Location = new System.Drawing.Point(-594, -234);
            this.About.Name = "About";
            this.About.Size = new System.Drawing.Size(594, 234);
            this.About.TabIndex = 2;
            this.About.Text = "关于";
            // 
            // label_AboutVersion
            // 
            this.label_AboutVersion.HandCursor = System.Windows.Forms.Cursors.Default;
            this.label_AboutVersion.Location = new System.Drawing.Point(9, 202);
            this.label_AboutVersion.Name = "label_AboutVersion";
            this.label_AboutVersion.Size = new System.Drawing.Size(510, 23);
            this.label_AboutVersion.TabIndex = 6;
            this.label_AboutVersion.Text = "当前程序分支:{Fork}  版本:{Version}";
            // 
            // button_About_Github
            // 
            this.button_About_Github.DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(47)))));
            this.button_About_Github.ForeColor = System.Drawing.Color.White;
            this.button_About_Github.HandCursor = System.Windows.Forms.Cursors.Default;
            this.button_About_Github.Icon = global::UnifiedLauncher.Properties.Resources.Github;
            this.button_About_Github.IconRatio = 1F;
            this.button_About_Github.Location = new System.Drawing.Point(157, 90);
            this.button_About_Github.Name = "button_About_Github";
            this.button_About_Github.Size = new System.Drawing.Size(142, 40);
            this.button_About_Github.TabIndex = 5;
            this.button_About_Github.Text = "Github主页";
            this.button_About_Github.Click += new System.EventHandler(this.button_About_Github_Click);
            // 
            // button_About_Bilibili
            // 
            this.button_About_Bilibili.HandCursor = System.Windows.Forms.Cursors.Default;
            this.button_About_Bilibili.Icon = global::UnifiedLauncher.Properties.Resources.RiBilibiliFill;
            this.button_About_Bilibili.IconRatio = 1F;
            this.button_About_Bilibili.Location = new System.Drawing.Point(9, 90);
            this.button_About_Bilibili.Name = "button_About_Bilibili";
            this.button_About_Bilibili.Size = new System.Drawing.Size(142, 40);
            this.button_About_Bilibili.TabIndex = 4;
            this.button_About_Bilibili.Text = "Bilibili主页";
            this.button_About_Bilibili.Type = AntdUI.TTypeMini.Primary;
            this.button_About_Bilibili.Click += new System.EventHandler(this.button_About_Bilibili_Click);
            // 
            // label_About_Info3
            // 
            this.label_About_Info3.HandCursor = System.Windows.Forms.Cursors.Default;
            this.label_About_Info3.Location = new System.Drawing.Point(75, 61);
            this.label_About_Info3.Name = "label_About_Info3";
            this.label_About_Info3.Size = new System.Drawing.Size(510, 23);
            this.label_About_Info3.TabIndex = 3;
            this.label_About_Info3.Text = "此软件使用.NET Framework 4.8框架开发  使用AntdUI库";
            // 
            // label_About_Info2
            // 
            this.label_About_Info2.HandCursor = System.Windows.Forms.Cursors.Default;
            this.label_About_Info2.Location = new System.Drawing.Point(75, 32);
            this.label_About_Info2.Name = "label_About_Info2";
            this.label_About_Info2.Size = new System.Drawing.Size(510, 23);
            this.label_About_Info2.TabIndex = 2;
            this.label_About_Info2.Text = "HuaZi-华子 版权所有 © 2024~2025 盗版必究";
            // 
            // label_About_Info1
            // 
            this.label_About_Info1.HandCursor = System.Windows.Forms.Cursors.Default;
            this.label_About_Info1.Location = new System.Drawing.Point(75, 3);
            this.label_About_Info1.Name = "label_About_Info1";
            this.label_About_Info1.Size = new System.Drawing.Size(510, 23);
            this.label_About_Info1.TabIndex = 1;
            this.label_About_Info1.Text = "Unified Launcher(统一启动器)";
            // 
            // image3D_About_Icon
            // 
            this.image3D_About_Icon.HandCursor = System.Windows.Forms.Cursors.Default;
            this.image3D_About_Icon.Image = global::UnifiedLauncher.Properties.Resources.CibLaravelNova;
            this.image3D_About_Icon.ImageFit = AntdUI.TFit.Fill;
            this.image3D_About_Icon.Location = new System.Drawing.Point(9, 3);
            this.image3D_About_Icon.Name = "image3D_About_Icon";
            this.image3D_About_Icon.Size = new System.Drawing.Size(60, 60);
            this.image3D_About_Icon.TabIndex = 0;
            this.image3D_About_Icon.Text = "image3D1";
            // 
            // Main_Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 300);
            this.Controls.Add(this.tabs_Main);
            this.Controls.Add(this.pageHeader);
            this.EnableHitTest = false;
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Mode = AntdUI.TAMode.Light;
            this.Name = "Main_Window";
            this.Resizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main_Window";
            this.tabs_Main.ResumeLayout(false);
            this.Home.ResumeLayout(false);
            this.Settings.ResumeLayout(false);
            this.About.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private AntdUI.PageHeader pageHeader;
        private AntdUI.Tabs tabs_Main;
        private AntdUI.TabPage Home;
        private AntdUI.TabPage Settings;
        private AntdUI.TabPage About;
        private AntdUI.Button button_Launch;
        private AntdUI.Label label_ProgramPath;
        private AntdUI.Label label_ProgramName;
        private AntdUI.Image3D image3D_ProgramIcon;
        private AntdUI.Image3D image3D_About_Icon;
        private AntdUI.Button button_Settings_OpenProgramsEditor;
        private AntdUI.Button button_About_Bilibili;
        private AntdUI.Label label_About_Info3;
        private AntdUI.Label label_About_Info2;
        private AntdUI.Label label_About_Info1;
        private AntdUI.Button button_About_Github;
        private AntdUI.Select select_SelectPrograms;
        private AntdUI.Label label_ProgramCmdLine;
        private AntdUI.Label label_Settings_CmdLine;
        private AntdUI.Input input_CmdLine;
        private AntdUI.Label label_AboutVersion;
        private AntdUI.Label label_AutoStart;
        private AntdUI.Switch switch_AutoStart;
        private AntdUI.Switch switch_StartLaunch;
        private AntdUI.Label label_StartLaunch;
        private AntdUI.TooltipComponent tooltipComponent;
        private AntdUI.Label label_Progress;
        private AntdUI.Progress progress_Launch;
    }
}

