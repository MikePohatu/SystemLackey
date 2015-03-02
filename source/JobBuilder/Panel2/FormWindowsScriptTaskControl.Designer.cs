namespace SystemLackey.UI.Forms
{
    partial class FormWindowsScriptTaskControl
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
            this.checkASync = new System.Windows.Forms.CheckBox();
            this.numericTimeout = new System.Windows.Forms.NumericUpDown();
            this.labelTimeout = new System.Windows.Forms.Label();
            this.checkSysWow64 = new System.Windows.Forms.CheckBox();
            this.buttonExport = new System.Windows.Forms.Button();
            this.buttonImport = new System.Windows.Forms.Button();
            this.buttonTestRun = new System.Windows.Forms.Button();
            this.checkHidden = new System.Windows.Forms.CheckBox();
            this.textCode = new System.Windows.Forms.TextBox();
            this.tabWinScript = new System.Windows.Forms.TabControl();
            this.tabScriptCode = new System.Windows.Forms.TabPage();
            this.tableScriptMain = new System.Windows.Forms.TableLayoutPanel();
            this.groupScriptMainSettings = new System.Windows.Forms.GroupBox();
            this.buttonSaveMain = new System.Windows.Forms.Button();
            this.labelName = new System.Windows.Forms.Label();
            this.textName = new System.Windows.Forms.TextBox();
            this.radioCmd = new System.Windows.Forms.RadioButton();
            this.radioPs1 = new System.Windows.Forms.RadioButton();
            this.radioVbs = new System.Windows.Forms.RadioButton();
            this.tabScriptAdvanced = new System.Windows.Forms.TabPage();
            this.groupScriptAdvancedSettings = new System.Windows.Forms.GroupBox();
            this.checkTestAllowed = new System.Windows.Forms.CheckBox();
            this.labelTaskIDValue = new System.Windows.Forms.Label();
            this.labelTaskID = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.labelComments = new System.Windows.Forms.Label();
            this.richtextComments = new System.Windows.Forms.RichTextBox();
            this.labelContentPack = new System.Windows.Forms.Label();
            this.linkLabelContentPack = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.numericTimeout)).BeginInit();
            this.tabWinScript.SuspendLayout();
            this.tabScriptCode.SuspendLayout();
            this.tableScriptMain.SuspendLayout();
            this.groupScriptMainSettings.SuspendLayout();
            this.tabScriptAdvanced.SuspendLayout();
            this.groupScriptAdvancedSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkASync
            // 
            this.checkASync.AutoSize = true;
            this.checkASync.Location = new System.Drawing.Point(11, 44);
            this.checkASync.Margin = new System.Windows.Forms.Padding(2);
            this.checkASync.Name = "checkASync";
            this.checkASync.Size = new System.Drawing.Size(95, 17);
            this.checkASync.TabIndex = 4;
            this.checkASync.Text = "ASynchronous";
            this.checkASync.UseVisualStyleBackColor = true;
            // 
            // numericTimeout
            // 
            this.numericTimeout.Location = new System.Drawing.Point(11, 123);
            this.numericTimeout.Margin = new System.Windows.Forms.Padding(2);
            this.numericTimeout.Maximum = new decimal(new int[] {
            86400,
            0,
            0,
            0});
            this.numericTimeout.Name = "numericTimeout";
            this.numericTimeout.Size = new System.Drawing.Size(58, 20);
            this.numericTimeout.TabIndex = 5;
            this.numericTimeout.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericTimeout.Value = new decimal(new int[] {
            900,
            0,
            0,
            0});
            // 
            // labelTimeout
            // 
            this.labelTimeout.AutoSize = true;
            this.labelTimeout.Location = new System.Drawing.Point(8, 102);
            this.labelTimeout.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTimeout.Name = "labelTimeout";
            this.labelTimeout.Size = new System.Drawing.Size(94, 13);
            this.labelTimeout.TabIndex = 6;
            this.labelTimeout.Text = "Timeout (seconds)";
            // 
            // checkSysWow64
            // 
            this.checkSysWow64.AutoSize = true;
            this.checkSysWow64.Location = new System.Drawing.Point(11, 23);
            this.checkSysWow64.Margin = new System.Windows.Forms.Padding(2);
            this.checkSysWow64.Name = "checkSysWow64";
            this.checkSysWow64.Size = new System.Drawing.Size(90, 17);
            this.checkSysWow64.TabIndex = 7;
            this.checkSysWow64.Text = "32bit on 64bit";
            this.checkSysWow64.UseVisualStyleBackColor = true;
            // 
            // buttonExport
            // 
            this.buttonExport.Location = new System.Drawing.Point(95, 203);
            this.buttonExport.Margin = new System.Windows.Forms.Padding(2);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(80, 25);
            this.buttonExport.TabIndex = 8;
            this.buttonExport.Text = "Export";
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // buttonImport
            // 
            this.buttonImport.Location = new System.Drawing.Point(11, 203);
            this.buttonImport.Margin = new System.Windows.Forms.Padding(2);
            this.buttonImport.Name = "buttonImport";
            this.buttonImport.Size = new System.Drawing.Size(80, 25);
            this.buttonImport.TabIndex = 9;
            this.buttonImport.Text = "Import";
            this.buttonImport.UseVisualStyleBackColor = true;
            this.buttonImport.Click += new System.EventHandler(this.buttonImport_Click);
            // 
            // buttonTestRun
            // 
            this.buttonTestRun.Enabled = false;
            this.buttonTestRun.Location = new System.Drawing.Point(4, 163);
            this.buttonTestRun.Margin = new System.Windows.Forms.Padding(2);
            this.buttonTestRun.Name = "buttonTestRun";
            this.buttonTestRun.Size = new System.Drawing.Size(125, 25);
            this.buttonTestRun.TabIndex = 10;
            this.buttonTestRun.Text = "Test Run";
            this.buttonTestRun.UseVisualStyleBackColor = true;
            this.buttonTestRun.Click += new System.EventHandler(this.buttonRun_Click);
            // 
            // checkHidden
            // 
            this.checkHidden.AutoSize = true;
            this.checkHidden.Checked = true;
            this.checkHidden.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkHidden.Location = new System.Drawing.Point(11, 62);
            this.checkHidden.Margin = new System.Windows.Forms.Padding(2);
            this.checkHidden.Name = "checkHidden";
            this.checkHidden.Size = new System.Drawing.Size(60, 17);
            this.checkHidden.TabIndex = 12;
            this.checkHidden.Text = "Hidden";
            this.checkHidden.UseVisualStyleBackColor = true;
            // 
            // textCode
            // 
            this.textCode.AcceptsReturn = true;
            this.textCode.AcceptsTab = true;
            this.textCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textCode.Location = new System.Drawing.Point(4, 4);
            this.textCode.Margin = new System.Windows.Forms.Padding(2);
            this.textCode.Multiline = true;
            this.textCode.Name = "textCode";
            this.textCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textCode.Size = new System.Drawing.Size(590, 432);
            this.textCode.TabIndex = 4;
            this.textCode.Text = "Enter script code here";
            this.textCode.WordWrap = false;
            // 
            // tabWinScript
            // 
            this.tabWinScript.Controls.Add(this.tabScriptCode);
            this.tabWinScript.Controls.Add(this.tabScriptAdvanced);
            this.tabWinScript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabWinScript.Location = new System.Drawing.Point(0, 0);
            this.tabWinScript.Margin = new System.Windows.Forms.Padding(0);
            this.tabWinScript.Name = "tabWinScript";
            this.tabWinScript.SelectedIndex = 0;
            this.tabWinScript.Size = new System.Drawing.Size(810, 464);
            this.tabWinScript.TabIndex = 14;
            // 
            // tabScriptCode
            // 
            this.tabScriptCode.AutoScroll = true;
            this.tabScriptCode.BackColor = System.Drawing.SystemColors.Control;
            this.tabScriptCode.Controls.Add(this.tableScriptMain);
            this.tabScriptCode.Location = new System.Drawing.Point(4, 22);
            this.tabScriptCode.Margin = new System.Windows.Forms.Padding(2);
            this.tabScriptCode.Name = "tabScriptCode";
            this.tabScriptCode.Padding = new System.Windows.Forms.Padding(2);
            this.tabScriptCode.Size = new System.Drawing.Size(802, 438);
            this.tabScriptCode.TabIndex = 0;
            this.tabScriptCode.Text = "Script";
            // 
            // tableScriptMain
            // 
            this.tableScriptMain.BackColor = System.Drawing.SystemColors.Control;
            this.tableScriptMain.ColumnCount = 2;
            this.tableScriptMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableScriptMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableScriptMain.Controls.Add(this.textCode, 0, 0);
            this.tableScriptMain.Controls.Add(this.groupScriptMainSettings, 1, 0);
            this.tableScriptMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableScriptMain.Location = new System.Drawing.Point(2, 2);
            this.tableScriptMain.Margin = new System.Windows.Forms.Padding(2);
            this.tableScriptMain.Name = "tableScriptMain";
            this.tableScriptMain.Padding = new System.Windows.Forms.Padding(2);
            this.tableScriptMain.RowCount = 1;
            this.tableScriptMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableScriptMain.Size = new System.Drawing.Size(798, 434);
            this.tableScriptMain.TabIndex = 6;
            // 
            // groupScriptMainSettings
            // 
            this.groupScriptMainSettings.Controls.Add(this.linkLabelContentPack);
            this.groupScriptMainSettings.Controls.Add(this.labelContentPack);
            this.groupScriptMainSettings.Controls.Add(this.buttonSaveMain);
            this.groupScriptMainSettings.Controls.Add(this.labelName);
            this.groupScriptMainSettings.Controls.Add(this.textName);
            this.groupScriptMainSettings.Controls.Add(this.radioCmd);
            this.groupScriptMainSettings.Controls.Add(this.radioPs1);
            this.groupScriptMainSettings.Controls.Add(this.radioVbs);
            this.groupScriptMainSettings.Location = new System.Drawing.Point(598, 4);
            this.groupScriptMainSettings.Margin = new System.Windows.Forms.Padding(2);
            this.groupScriptMainSettings.Name = "groupScriptMainSettings";
            this.groupScriptMainSettings.Padding = new System.Windows.Forms.Padding(2);
            this.groupScriptMainSettings.Size = new System.Drawing.Size(196, 244);
            this.groupScriptMainSettings.TabIndex = 17;
            this.groupScriptMainSettings.TabStop = false;
            this.groupScriptMainSettings.Text = "Settings";
            // 
            // buttonSaveMain
            // 
            this.buttonSaveMain.Location = new System.Drawing.Point(108, 204);
            this.buttonSaveMain.Name = "buttonSaveMain";
            this.buttonSaveMain.Size = new System.Drawing.Size(80, 25);
            this.buttonSaveMain.TabIndex = 16;
            this.buttonSaveMain.Text = "Save";
            this.buttonSaveMain.UseVisualStyleBackColor = true;
            this.buttonSaveMain.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(4, 19);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(38, 13);
            this.labelName.TabIndex = 6;
            this.labelName.Text = "Name:";
            // 
            // textName
            // 
            this.textName.Location = new System.Drawing.Point(46, 18);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(142, 20);
            this.textName.TabIndex = 7;
            // 
            // radioCmd
            // 
            this.radioCmd.AutoSize = true;
            this.radioCmd.Checked = true;
            this.radioCmd.Location = new System.Drawing.Point(15, 40);
            this.radioCmd.Margin = new System.Windows.Forms.Padding(2);
            this.radioCmd.Name = "radioCmd";
            this.radioCmd.Size = new System.Drawing.Size(53, 17);
            this.radioCmd.TabIndex = 3;
            this.radioCmd.TabStop = true;
            this.radioCmd.Text = "Batch";
            this.radioCmd.UseVisualStyleBackColor = true;
            // 
            // radioPs1
            // 
            this.radioPs1.AutoSize = true;
            this.radioPs1.Location = new System.Drawing.Point(15, 79);
            this.radioPs1.Margin = new System.Windows.Forms.Padding(2);
            this.radioPs1.Name = "radioPs1";
            this.radioPs1.Size = new System.Drawing.Size(76, 17);
            this.radioPs1.TabIndex = 5;
            this.radioPs1.Text = "Powershell";
            this.radioPs1.UseVisualStyleBackColor = true;
            // 
            // radioVbs
            // 
            this.radioVbs.AutoSize = true;
            this.radioVbs.Location = new System.Drawing.Point(15, 60);
            this.radioVbs.Margin = new System.Windows.Forms.Padding(2);
            this.radioVbs.Name = "radioVbs";
            this.radioVbs.Size = new System.Drawing.Size(66, 17);
            this.radioVbs.TabIndex = 4;
            this.radioVbs.Text = "VBScript";
            this.radioVbs.UseVisualStyleBackColor = true;
            // 
            // tabScriptAdvanced
            // 
            this.tabScriptAdvanced.BackColor = System.Drawing.SystemColors.Control;
            this.tabScriptAdvanced.Controls.Add(this.groupScriptAdvancedSettings);
            this.tabScriptAdvanced.Controls.Add(this.labelTaskIDValue);
            this.tabScriptAdvanced.Controls.Add(this.labelTaskID);
            this.tabScriptAdvanced.Controls.Add(this.buttonSave);
            this.tabScriptAdvanced.Controls.Add(this.labelComments);
            this.tabScriptAdvanced.Controls.Add(this.richtextComments);
            this.tabScriptAdvanced.Controls.Add(this.buttonImport);
            this.tabScriptAdvanced.Controls.Add(this.buttonExport);
            this.tabScriptAdvanced.Location = new System.Drawing.Point(4, 22);
            this.tabScriptAdvanced.Margin = new System.Windows.Forms.Padding(2);
            this.tabScriptAdvanced.Name = "tabScriptAdvanced";
            this.tabScriptAdvanced.Padding = new System.Windows.Forms.Padding(2);
            this.tabScriptAdvanced.Size = new System.Drawing.Size(802, 438);
            this.tabScriptAdvanced.TabIndex = 1;
            this.tabScriptAdvanced.Text = "Advanced";
            // 
            // groupScriptAdvancedSettings
            // 
            this.groupScriptAdvancedSettings.Controls.Add(this.checkSysWow64);
            this.groupScriptAdvancedSettings.Controls.Add(this.numericTimeout);
            this.groupScriptAdvancedSettings.Controls.Add(this.checkASync);
            this.groupScriptAdvancedSettings.Controls.Add(this.checkTestAllowed);
            this.groupScriptAdvancedSettings.Controls.Add(this.labelTimeout);
            this.groupScriptAdvancedSettings.Controls.Add(this.checkHidden);
            this.groupScriptAdvancedSettings.Controls.Add(this.buttonTestRun);
            this.groupScriptAdvancedSettings.Location = new System.Drawing.Point(283, 7);
            this.groupScriptAdvancedSettings.Margin = new System.Windows.Forms.Padding(2);
            this.groupScriptAdvancedSettings.Name = "groupScriptAdvancedSettings";
            this.groupScriptAdvancedSettings.Padding = new System.Windows.Forms.Padding(2);
            this.groupScriptAdvancedSettings.Size = new System.Drawing.Size(133, 192);
            this.groupScriptAdvancedSettings.TabIndex = 19;
            this.groupScriptAdvancedSettings.TabStop = false;
            this.groupScriptAdvancedSettings.Text = "Advanced Settings";
            // 
            // checkTestAllowed
            // 
            this.checkTestAllowed.AutoSize = true;
            this.checkTestAllowed.Location = new System.Drawing.Point(11, 83);
            this.checkTestAllowed.Name = "checkTestAllowed";
            this.checkTestAllowed.Size = new System.Drawing.Size(104, 17);
            this.checkTestAllowed.TabIndex = 16;
            this.checkTestAllowed.Text = "Test run allowed";
            this.checkTestAllowed.UseVisualStyleBackColor = true;
            this.checkTestAllowed.CheckedChanged += new System.EventHandler(this.checkTestAllowed_CheckedChanged);
            // 
            // labelTaskIDValue
            // 
            this.labelTaskIDValue.AutoSize = true;
            this.labelTaskIDValue.Location = new System.Drawing.Point(49, 7);
            this.labelTaskIDValue.Name = "labelTaskIDValue";
            this.labelTaskIDValue.Size = new System.Drawing.Size(18, 13);
            this.labelTaskIDValue.TabIndex = 18;
            this.labelTaskIDValue.Text = "ID";
            // 
            // labelTaskID
            // 
            this.labelTaskID.AutoSize = true;
            this.labelTaskID.Location = new System.Drawing.Point(8, 7);
            this.labelTaskID.Name = "labelTaskID";
            this.labelTaskID.Size = new System.Drawing.Size(48, 13);
            this.labelTaskID.TabIndex = 17;
            this.labelTaskID.Text = "Task ID:";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(336, 204);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(80, 25);
            this.buttonSave.TabIndex = 15;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // labelComments
            // 
            this.labelComments.AutoSize = true;
            this.labelComments.Location = new System.Drawing.Point(8, 20);
            this.labelComments.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelComments.Name = "labelComments";
            this.labelComments.Size = new System.Drawing.Size(56, 13);
            this.labelComments.TabIndex = 14;
            this.labelComments.Text = "Comments";
            // 
            // richtextComments
            // 
            this.richtextComments.Location = new System.Drawing.Point(11, 35);
            this.richtextComments.Margin = new System.Windows.Forms.Padding(2);
            this.richtextComments.Name = "richtextComments";
            this.richtextComments.Size = new System.Drawing.Size(269, 165);
            this.richtextComments.TabIndex = 13;
            this.richtextComments.Text = "";
            // 
            // labelContentPack
            // 
            this.labelContentPack.AutoSize = true;
            this.labelContentPack.Location = new System.Drawing.Point(15, 102);
            this.labelContentPack.Name = "labelContentPack";
            this.labelContentPack.Size = new System.Drawing.Size(75, 13);
            this.labelContentPack.TabIndex = 17;
            this.labelContentPack.Text = "Content Pack:";
            // 
            // linkLabelContentPack
            // 
            this.linkLabelContentPack.AutoSize = true;
            this.linkLabelContentPack.Location = new System.Drawing.Point(97, 101);
            this.linkLabelContentPack.Name = "linkLabelContentPack";
            this.linkLabelContentPack.Size = new System.Drawing.Size(36, 13);
            this.linkLabelContentPack.TabIndex = 18;
            this.linkLabelContentPack.TabStop = true;
            this.linkLabelContentPack.Text = "Empty";
            this.linkLabelContentPack.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelContentPack_LinkClicked);
            // 
            // FormWindowsScriptTaskControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 464);
            this.Controls.Add(this.tabWinScript);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(20, 373);
            this.Name = "FormWindowsScriptTaskControl";
            this.Text = "System Lackey : Task Builder";
            this.Load += new System.EventHandler(this.formTaskBuilder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericTimeout)).EndInit();
            this.tabWinScript.ResumeLayout(false);
            this.tabScriptCode.ResumeLayout(false);
            this.tableScriptMain.ResumeLayout(false);
            this.tableScriptMain.PerformLayout();
            this.groupScriptMainSettings.ResumeLayout(false);
            this.groupScriptMainSettings.PerformLayout();
            this.tabScriptAdvanced.ResumeLayout(false);
            this.tabScriptAdvanced.PerformLayout();
            this.groupScriptAdvancedSettings.ResumeLayout(false);
            this.groupScriptAdvancedSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox checkASync;
        private System.Windows.Forms.NumericUpDown numericTimeout;
        private System.Windows.Forms.Label labelTimeout;
        private System.Windows.Forms.CheckBox checkSysWow64;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.Button buttonImport;
        private System.Windows.Forms.Button buttonTestRun;
        private System.Windows.Forms.CheckBox checkHidden;
        private System.Windows.Forms.TextBox textCode;
        private System.Windows.Forms.TabControl tabWinScript;
        private System.Windows.Forms.TabPage tabScriptCode;
        private System.Windows.Forms.TabPage tabScriptAdvanced;
        private System.Windows.Forms.Label labelComments;
        private System.Windows.Forms.RichTextBox richtextComments;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.CheckBox checkTestAllowed;
        private System.Windows.Forms.Button buttonSaveMain;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textName;
        private System.Windows.Forms.RadioButton radioVbs;
        private System.Windows.Forms.RadioButton radioPs1;
        private System.Windows.Forms.RadioButton radioCmd;
        private System.Windows.Forms.Label labelTaskIDValue;
        private System.Windows.Forms.Label labelTaskID;
        private System.Windows.Forms.GroupBox groupScriptMainSettings;
        private System.Windows.Forms.GroupBox groupScriptAdvancedSettings;
        private System.Windows.Forms.TableLayoutPanel tableScriptMain;
        private System.Windows.Forms.LinkLabel linkLabelContentPack;
        private System.Windows.Forms.Label labelContentPack;
    }
}

