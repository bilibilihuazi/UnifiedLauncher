namespace UnifiedLauncher
{
    partial class ProgramsEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProgramsEditor));
            this.listBox = new System.Windows.Forms.ListBox();
            this.label_Name = new AntdUI.Label();
            this.input_Name = new AntdUI.Input();
            this.input_Path = new AntdUI.Input();
            this.label_Path = new AntdUI.Label();
            this.button_Path_Browser = new AntdUI.Button();
            this.button_Remove = new AntdUI.Button();
            this.button_Create = new AntdUI.Button();
            this.pageHeader1 = new AntdUI.PageHeader();
            this.alert1 = new AntdUI.Alert();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.input_CommandLine = new AntdUI.Input();
            this.label_CommandLine = new AntdUI.Label();
            this.SuspendLayout();
            // 
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.ItemHeight = 17;
            this.listBox.Location = new System.Drawing.Point(12, 36);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(184, 191);
            this.listBox.TabIndex = 1;
            this.listBox.SelectedIndexChanged += new System.EventHandler(this.listBox_SelectedIndexChanged);
            // 
            // label_Name
            // 
            this.label_Name.HandCursor = System.Windows.Forms.Cursors.Default;
            this.label_Name.Location = new System.Drawing.Point(202, 77);
            this.label_Name.Name = "label_Name";
            this.label_Name.Size = new System.Drawing.Size(42, 30);
            this.label_Name.TabIndex = 2;
            this.label_Name.Text = "名称：";
            // 
            // input_Name
            // 
            this.input_Name.Enabled = false;
            this.input_Name.HandCursor = System.Windows.Forms.Cursors.Default;
            this.input_Name.Location = new System.Drawing.Point(235, 77);
            this.input_Name.Name = "input_Name";
            this.input_Name.Size = new System.Drawing.Size(353, 30);
            this.input_Name.TabIndex = 3;
            this.input_Name.Text = "请选择左侧项目~";
            this.input_Name.TextChanged += new System.EventHandler(this.input_Name_TextChanged);
            this.input_Name.Leave += new System.EventHandler(this.input_Name_Leave);
            // 
            // input_Path
            // 
            this.input_Path.Enabled = false;
            this.input_Path.HandCursor = System.Windows.Forms.Cursors.Default;
            this.input_Path.JoinRight = true;
            this.input_Path.Location = new System.Drawing.Point(261, 113);
            this.input_Path.Name = "input_Path";
            this.input_Path.Size = new System.Drawing.Size(253, 30);
            this.input_Path.TabIndex = 5;
            this.input_Path.Text = "请选择左侧项目~";
            this.input_Path.TextChanged += new System.EventHandler(this.input_Path_TextChanged);
            // 
            // label_Path
            // 
            this.label_Path.HandCursor = System.Windows.Forms.Cursors.Default;
            this.label_Path.Location = new System.Drawing.Point(202, 113);
            this.label_Path.Name = "label_Path";
            this.label_Path.Size = new System.Drawing.Size(67, 30);
            this.label_Path.TabIndex = 4;
            this.label_Path.Text = "程序路径：";
            // 
            // button_Path_Browser
            // 
            this.button_Path_Browser.Enabled = false;
            this.button_Path_Browser.HandCursor = System.Windows.Forms.Cursors.Default;
            this.button_Path_Browser.JoinLeft = true;
            this.button_Path_Browser.Location = new System.Drawing.Point(516, 113);
            this.button_Path_Browser.Name = "button_Path_Browser";
            this.button_Path_Browser.Size = new System.Drawing.Size(72, 30);
            this.button_Path_Browser.TabIndex = 6;
            this.button_Path_Browser.Text = "浏览...";
            this.button_Path_Browser.Click += new System.EventHandler(this.button_Path_Browser_Click);
            // 
            // button_Remove
            // 
            this.button_Remove.HandCursor = System.Windows.Forms.Cursors.Default;
            this.button_Remove.Icon = global::UnifiedLauncher.Properties.Resources.MingcuteMinusCircleFill;
            this.button_Remove.Location = new System.Drawing.Point(328, 36);
            this.button_Remove.Name = "button_Remove";
            this.button_Remove.Size = new System.Drawing.Size(120, 35);
            this.button_Remove.TabIndex = 8;
            this.button_Remove.Text = "移除";
            this.button_Remove.Type = AntdUI.TTypeMini.Error;
            this.button_Remove.Click += new System.EventHandler(this.button_Remove_Click);
            // 
            // button_Create
            // 
            this.button_Create.HandCursor = System.Windows.Forms.Cursors.Default;
            this.button_Create.Icon = global::UnifiedLauncher.Properties.Resources.MaterialSymbolsAddCircleRounded;
            this.button_Create.Location = new System.Drawing.Point(202, 36);
            this.button_Create.Name = "button_Create";
            this.button_Create.Size = new System.Drawing.Size(120, 35);
            this.button_Create.TabIndex = 7;
            this.button_Create.Text = "添加";
            this.button_Create.Type = AntdUI.TTypeMini.Success;
            this.button_Create.Click += new System.EventHandler(this.button_Create_Click);
            // 
            // pageHeader1
            // 
            this.pageHeader1.Location = new System.Drawing.Point(0, 0);
            this.pageHeader1.MaximizeBox = false;
            this.pageHeader1.MinimizeBox = false;
            this.pageHeader1.Name = "pageHeader1";
            this.pageHeader1.ShowButton = true;
            this.pageHeader1.ShowIcon = true;
            this.pageHeader1.Size = new System.Drawing.Size(600, 30);
            this.pageHeader1.TabIndex = 0;
            this.pageHeader1.Text = "ProgramsEditor";
            // 
            // alert1
            // 
            this.alert1.Icon = AntdUI.TType.Info;
            this.alert1.Location = new System.Drawing.Point(202, 204);
            this.alert1.Name = "alert1";
            this.alert1.Size = new System.Drawing.Size(386, 23);
            this.alert1.TabIndex = 9;
            this.alert1.Text = "提示：所做更改立即生效！";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "可执行程序|*.exe";
            this.openFileDialog1.Title = "请选择一个可执行文件";
            // 
            // input_CommandLine
            // 
            this.input_CommandLine.Enabled = false;
            this.input_CommandLine.HandCursor = System.Windows.Forms.Cursors.Default;
            this.input_CommandLine.Location = new System.Drawing.Point(248, 149);
            this.input_CommandLine.Name = "input_CommandLine";
            this.input_CommandLine.Size = new System.Drawing.Size(340, 30);
            this.input_CommandLine.TabIndex = 11;
            this.input_CommandLine.Text = "请选择左侧项目~";
            this.input_CommandLine.TextChanged += new System.EventHandler(this.input_CommandLine_TextChanged);
            // 
            // label_CommandLine
            // 
            this.label_CommandLine.HandCursor = System.Windows.Forms.Cursors.Default;
            this.label_CommandLine.Location = new System.Drawing.Point(202, 149);
            this.label_CommandLine.Name = "label_CommandLine";
            this.label_CommandLine.Size = new System.Drawing.Size(57, 30);
            this.label_CommandLine.TabIndex = 10;
            this.label_CommandLine.Text = "命令行：";
            // 
            // ProgramsEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 242);
            this.Controls.Add(this.input_CommandLine);
            this.Controls.Add(this.label_CommandLine);
            this.Controls.Add(this.alert1);
            this.Controls.Add(this.button_Remove);
            this.Controls.Add(this.button_Create);
            this.Controls.Add(this.button_Path_Browser);
            this.Controls.Add(this.input_Path);
            this.Controls.Add(this.label_Path);
            this.Controls.Add(this.input_Name);
            this.Controls.Add(this.label_Name);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.pageHeader1);
            this.EnableHitTest = false;
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "ProgramsEditor";
            this.Resizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProgramsEditor";
            this.ResumeLayout(false);

        }

        #endregion

        private AntdUI.PageHeader pageHeader1;
        private System.Windows.Forms.ListBox listBox;
        private AntdUI.Label label_Name;
        private AntdUI.Input input_Name;
        private AntdUI.Input input_Path;
        private AntdUI.Label label_Path;
        private AntdUI.Button button_Path_Browser;
        private AntdUI.Button button_Create;
        private AntdUI.Button button_Remove;
        private AntdUI.Alert alert1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private AntdUI.Input input_CommandLine;
        private AntdUI.Label label_CommandLine;
    }
}