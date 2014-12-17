namespace lackey_form_taskbuilder
{
    partial class formWinTaskBuilder
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
            this.radioCmd = new System.Windows.Forms.RadioButton();
            this.radioVbs = new System.Windows.Forms.RadioButton();
            this.radioPs1 = new System.Windows.Forms.RadioButton();
            this.checkASync = new System.Windows.Forms.CheckBox();
            this.numericTimeout = new System.Windows.Forms.NumericUpDown();
            this.labelTimeout = new System.Windows.Forms.Label();
            this.checkSysWow64 = new System.Windows.Forms.CheckBox();
            this.buttonExport = new System.Windows.Forms.Button();
            this.buttonImport = new System.Windows.Forms.Button();
            this.buttonRun = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.checkHidden = new System.Windows.Forms.CheckBox();
            this.splitMain = new System.Windows.Forms.SplitContainer();
            this.splitCode = new System.Windows.Forms.SplitContainer();
            this.labelTaskIDValue = new System.Windows.Forms.Label();
            this.labelTaskID = new System.Windows.Forms.Label();
            this.textName = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.textCode = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericTimeout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitCode)).BeginInit();
            this.splitCode.Panel1.SuspendLayout();
            this.splitCode.Panel2.SuspendLayout();
            this.splitCode.SuspendLayout();
            this.SuspendLayout();
            // 
            // radioCmd
            // 
            this.radioCmd.AutoSize = true;
            this.radioCmd.Location = new System.Drawing.Point(16, 10);
            this.radioCmd.Margin = new System.Windows.Forms.Padding(2);
            this.radioCmd.Name = "radioCmd";
            this.radioCmd.Size = new System.Drawing.Size(53, 17);
            this.radioCmd.TabIndex = 0;
            this.radioCmd.TabStop = true;
            this.radioCmd.Text = "Batch";
            this.radioCmd.UseVisualStyleBackColor = true;
            this.radioCmd.CheckedChanged += new System.EventHandler(this.radioCmd_CheckedChanged);
            // 
            // radioVbs
            // 
            this.radioVbs.AutoSize = true;
            this.radioVbs.Location = new System.Drawing.Point(16, 30);
            this.radioVbs.Margin = new System.Windows.Forms.Padding(2);
            this.radioVbs.Name = "radioVbs";
            this.radioVbs.Size = new System.Drawing.Size(66, 17);
            this.radioVbs.TabIndex = 1;
            this.radioVbs.TabStop = true;
            this.radioVbs.Text = "VBScript";
            this.radioVbs.UseVisualStyleBackColor = true;
            this.radioVbs.CheckedChanged += new System.EventHandler(this.radioVbs_CheckedChanged);
            // 
            // radioPs1
            // 
            this.radioPs1.AutoSize = true;
            this.radioPs1.Location = new System.Drawing.Point(16, 50);
            this.radioPs1.Margin = new System.Windows.Forms.Padding(2);
            this.radioPs1.Name = "radioPs1";
            this.radioPs1.Size = new System.Drawing.Size(76, 17);
            this.radioPs1.TabIndex = 2;
            this.radioPs1.TabStop = true;
            this.radioPs1.Text = "Powershell";
            this.radioPs1.UseVisualStyleBackColor = true;
            this.radioPs1.CheckedChanged += new System.EventHandler(this.radioPs1_CheckedChanged);
            // 
            // checkASync
            // 
            this.checkASync.AutoSize = true;
            this.checkASync.Location = new System.Drawing.Point(15, 160);
            this.checkASync.Margin = new System.Windows.Forms.Padding(2);
            this.checkASync.Name = "checkASync";
            this.checkASync.Size = new System.Drawing.Size(95, 17);
            this.checkASync.TabIndex = 4;
            this.checkASync.Text = "ASynchronous";
            this.checkASync.UseVisualStyleBackColor = true;
            // 
            // numericTimeout
            // 
            this.numericTimeout.Location = new System.Drawing.Point(11, 89);
            this.numericTimeout.Margin = new System.Windows.Forms.Padding(2);
            this.numericTimeout.Maximum = new decimal(new int[] {
            86400,
            0,
            0,
            0});
            this.numericTimeout.Name = "numericTimeout";
            this.numericTimeout.Size = new System.Drawing.Size(87, 20);
            this.numericTimeout.TabIndex = 5;
            this.numericTimeout.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericTimeout.UseWaitCursor = true;
            this.numericTimeout.Value = new decimal(new int[] {
            900,
            0,
            0,
            0});
            this.numericTimeout.ValueChanged += new System.EventHandler(this.numericTimeout_ValueChanged);
            // 
            // labelTimeout
            // 
            this.labelTimeout.AutoSize = true;
            this.labelTimeout.Location = new System.Drawing.Point(8, 74);
            this.labelTimeout.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTimeout.Name = "labelTimeout";
            this.labelTimeout.Size = new System.Drawing.Size(94, 13);
            this.labelTimeout.TabIndex = 6;
            this.labelTimeout.Text = "Timeout (seconds)";
            // 
            // checkSysWow64
            // 
            this.checkSysWow64.AutoSize = true;
            this.checkSysWow64.Location = new System.Drawing.Point(15, 140);
            this.checkSysWow64.Margin = new System.Windows.Forms.Padding(2);
            this.checkSysWow64.Name = "checkSysWow64";
            this.checkSysWow64.Size = new System.Drawing.Size(90, 17);
            this.checkSysWow64.TabIndex = 7;
            this.checkSysWow64.Text = "32bit on 64bit";
            this.checkSysWow64.UseVisualStyleBackColor = true;
            this.checkSysWow64.CheckedChanged += new System.EventHandler(this.checkSysWow64_CheckedChanged);
            // 
            // buttonExport
            // 
            this.buttonExport.Location = new System.Drawing.Point(7, 236);
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
            this.buttonImport.Location = new System.Drawing.Point(7, 207);
            this.buttonImport.Margin = new System.Windows.Forms.Padding(2);
            this.buttonImport.Name = "buttonImport";
            this.buttonImport.Size = new System.Drawing.Size(80, 25);
            this.buttonImport.TabIndex = 9;
            this.buttonImport.Text = "Import";
            this.buttonImport.UseVisualStyleBackColor = true;
            this.buttonImport.Click += new System.EventHandler(this.buttonImport_Click);
            // 
            // buttonRun
            // 
            this.buttonRun.Location = new System.Drawing.Point(7, 265);
            this.buttonRun.Margin = new System.Windows.Forms.Padding(2);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(80, 25);
            this.buttonRun.TabIndex = 10;
            this.buttonRun.Text = "Run";
            this.buttonRun.UseVisualStyleBackColor = true;
            this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(7, 316);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(80, 25);
            this.buttonSave.TabIndex = 11;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // checkHidden
            // 
            this.checkHidden.AutoSize = true;
            this.checkHidden.Checked = true;
            this.checkHidden.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkHidden.Location = new System.Drawing.Point(16, 179);
            this.checkHidden.Margin = new System.Windows.Forms.Padding(2);
            this.checkHidden.Name = "checkHidden";
            this.checkHidden.Size = new System.Drawing.Size(60, 17);
            this.checkHidden.TabIndex = 12;
            this.checkHidden.Text = "Hidden";
            this.checkHidden.UseVisualStyleBackColor = true;
            // 
            // splitMain
            // 
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitMain.IsSplitterFixed = true;
            this.splitMain.Location = new System.Drawing.Point(0, 0);
            this.splitMain.Name = "splitMain";
            // 
            // splitMain.Panel1
            // 
            this.splitMain.Panel1.Controls.Add(this.splitCode);
            // 
            // splitMain.Panel2
            // 
            this.splitMain.Panel2.Controls.Add(this.buttonSave);
            this.splitMain.Panel2.Controls.Add(this.checkHidden);
            this.splitMain.Panel2.Controls.Add(this.buttonRun);
            this.splitMain.Panel2.Controls.Add(this.checkSysWow64);
            this.splitMain.Panel2.Controls.Add(this.buttonImport);
            this.splitMain.Panel2.Controls.Add(this.labelTimeout);
            this.splitMain.Panel2.Controls.Add(this.buttonExport);
            this.splitMain.Panel2.Controls.Add(this.numericTimeout);
            this.splitMain.Panel2.Controls.Add(this.radioCmd);
            this.splitMain.Panel2.Controls.Add(this.checkASync);
            this.splitMain.Panel2.Controls.Add(this.radioVbs);
            this.splitMain.Panel2.Controls.Add(this.radioPs1);
            this.splitMain.Panel2.Padding = new System.Windows.Forms.Padding(5);
            this.splitMain.Panel2MinSize = 120;
            this.splitMain.Size = new System.Drawing.Size(810, 423);
            this.splitMain.SplitterDistance = 686;
            this.splitMain.TabIndex = 13;
            // 
            // splitCode
            // 
            this.splitCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitCode.Location = new System.Drawing.Point(0, 0);
            this.splitCode.Name = "splitCode";
            this.splitCode.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitCode.Panel1
            // 
            this.splitCode.Panel1.Controls.Add(this.labelTaskIDValue);
            this.splitCode.Panel1.Controls.Add(this.labelTaskID);
            this.splitCode.Panel1.Controls.Add(this.textName);
            this.splitCode.Panel1.Controls.Add(this.labelName);
            // 
            // splitCode.Panel2
            // 
            this.splitCode.Panel2.Controls.Add(this.textCode);
            this.splitCode.Size = new System.Drawing.Size(686, 423);
            this.splitCode.SplitterDistance = 25;
            this.splitCode.TabIndex = 4;
            // 
            // labelTaskIDValue
            // 
            this.labelTaskIDValue.AutoSize = true;
            this.labelTaskIDValue.Location = new System.Drawing.Point(305, 7);
            this.labelTaskIDValue.Name = "labelTaskIDValue";
            this.labelTaskIDValue.Size = new System.Drawing.Size(18, 13);
            this.labelTaskIDValue.TabIndex = 3;
            this.labelTaskIDValue.Text = "ID";
            // 
            // labelTaskID
            // 
            this.labelTaskID.AutoSize = true;
            this.labelTaskID.Location = new System.Drawing.Point(251, 7);
            this.labelTaskID.Name = "labelTaskID";
            this.labelTaskID.Size = new System.Drawing.Size(48, 13);
            this.labelTaskID.TabIndex = 2;
            this.labelTaskID.Text = "Task ID:";
            this.labelTaskID.Click += new System.EventHandler(this.labelTaskID_Click);
            // 
            // textName
            // 
            this.textName.Location = new System.Drawing.Point(47, 4);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(198, 20);
            this.textName.TabIndex = 1;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(3, 7);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(38, 13);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Name:";
            // 
            // textCode
            // 
            this.textCode.AcceptsReturn = true;
            this.textCode.AcceptsTab = true;
            this.textCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textCode.Location = new System.Drawing.Point(0, 0);
            this.textCode.Margin = new System.Windows.Forms.Padding(2);
            this.textCode.Multiline = true;
            this.textCode.Name = "textCode";
            this.textCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textCode.Size = new System.Drawing.Size(686, 394);
            this.textCode.TabIndex = 4;
            this.textCode.Text = "Enter script code here";
            this.textCode.WordWrap = false;
            // 
            // formWinTaskBuilder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 423);
            this.Controls.Add(this.splitMain);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(16, 385);
            this.Name = "formWinTaskBuilder";
            this.Text = "System Lackey : Task Builder";
            this.Load += new System.EventHandler(this.formTaskBuilder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericTimeout)).EndInit();
            this.splitMain.Panel1.ResumeLayout(false);
            this.splitMain.Panel2.ResumeLayout(false);
            this.splitMain.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            this.splitCode.Panel1.ResumeLayout(false);
            this.splitCode.Panel1.PerformLayout();
            this.splitCode.Panel2.ResumeLayout(false);
            this.splitCode.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitCode)).EndInit();
            this.splitCode.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton radioCmd;
        private System.Windows.Forms.RadioButton radioVbs;
        private System.Windows.Forms.RadioButton radioPs1;
        private System.Windows.Forms.CheckBox checkASync;
        private System.Windows.Forms.NumericUpDown numericTimeout;
        private System.Windows.Forms.Label labelTimeout;
        private System.Windows.Forms.CheckBox checkSysWow64;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.Button buttonImport;
        private System.Windows.Forms.Button buttonRun;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.CheckBox checkHidden;
        private System.Windows.Forms.SplitContainer splitMain;
        private System.Windows.Forms.SplitContainer splitCode;
        private System.Windows.Forms.Label labelTaskIDValue;
        private System.Windows.Forms.Label labelTaskID;
        private System.Windows.Forms.TextBox textName;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textCode;
    }
}

