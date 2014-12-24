namespace SystemLackey.JobBuilder
{
    partial class Form_WinTaskBuilder
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
            this.checkHidden = new System.Windows.Forms.CheckBox();
            this.labelTaskIDValue = new System.Windows.Forms.Label();
            this.labelTaskID = new System.Windows.Forms.Label();
            this.textName = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.textCode = new System.Windows.Forms.TextBox();
            this.tabWinScript = new System.Windows.Forms.TabControl();
            this.tabScriptCode = new System.Windows.Forms.TabPage();
            this.tabScriptDetails = new System.Windows.Forms.TabPage();
            this.labelComments = new System.Windows.Forms.Label();
            this.richComments = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericTimeout)).BeginInit();
            this.tabWinScript.SuspendLayout();
            this.tabScriptCode.SuspendLayout();
            this.tabScriptDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // radioCmd
            // 
            this.radioCmd.AutoSize = true;
            this.radioCmd.Checked = true;
            this.radioCmd.Location = new System.Drawing.Point(277, 7);
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
            this.radioVbs.Location = new System.Drawing.Point(277, 27);
            this.radioVbs.Margin = new System.Windows.Forms.Padding(2);
            this.radioVbs.Name = "radioVbs";
            this.radioVbs.Size = new System.Drawing.Size(66, 17);
            this.radioVbs.TabIndex = 1;
            this.radioVbs.Text = "VBScript";
            this.radioVbs.UseVisualStyleBackColor = true;
            this.radioVbs.CheckedChanged += new System.EventHandler(this.radioVbs_CheckedChanged);
            // 
            // radioPs1
            // 
            this.radioPs1.AutoSize = true;
            this.radioPs1.Location = new System.Drawing.Point(277, 47);
            this.radioPs1.Margin = new System.Windows.Forms.Padding(2);
            this.radioPs1.Name = "radioPs1";
            this.radioPs1.Size = new System.Drawing.Size(76, 17);
            this.radioPs1.TabIndex = 2;
            this.radioPs1.Text = "Powershell";
            this.radioPs1.UseVisualStyleBackColor = true;
            this.radioPs1.CheckedChanged += new System.EventHandler(this.radioPs1_CheckedChanged);
            // 
            // checkASync
            // 
            this.checkASync.AutoSize = true;
            this.checkASync.Location = new System.Drawing.Point(277, 102);
            this.checkASync.Margin = new System.Windows.Forms.Padding(2);
            this.checkASync.Name = "checkASync";
            this.checkASync.Size = new System.Drawing.Size(95, 17);
            this.checkASync.TabIndex = 4;
            this.checkASync.Text = "ASynchronous";
            this.checkASync.UseVisualStyleBackColor = true;
            // 
            // numericTimeout
            // 
            this.numericTimeout.Location = new System.Drawing.Point(484, 6);
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
            this.labelTimeout.Location = new System.Drawing.Point(387, 7);
            this.labelTimeout.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTimeout.Name = "labelTimeout";
            this.labelTimeout.Size = new System.Drawing.Size(94, 13);
            this.labelTimeout.TabIndex = 6;
            this.labelTimeout.Text = "Timeout (seconds)";
            this.labelTimeout.Click += new System.EventHandler(this.labelTimeout_Click);
            // 
            // checkSysWow64
            // 
            this.checkSysWow64.AutoSize = true;
            this.checkSysWow64.Location = new System.Drawing.Point(277, 82);
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
            this.buttonExport.Location = new System.Drawing.Point(278, 174);
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
            this.buttonImport.Location = new System.Drawing.Point(278, 145);
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
            this.buttonRun.Location = new System.Drawing.Point(462, 174);
            this.buttonRun.Margin = new System.Windows.Forms.Padding(2);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(80, 25);
            this.buttonRun.TabIndex = 10;
            this.buttonRun.Text = "Run";
            this.buttonRun.UseVisualStyleBackColor = true;
            this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);
            // 
            // checkHidden
            // 
            this.checkHidden.AutoSize = true;
            this.checkHidden.Checked = true;
            this.checkHidden.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkHidden.Location = new System.Drawing.Point(278, 121);
            this.checkHidden.Margin = new System.Windows.Forms.Padding(2);
            this.checkHidden.Name = "checkHidden";
            this.checkHidden.Size = new System.Drawing.Size(60, 17);
            this.checkHidden.TabIndex = 12;
            this.checkHidden.Text = "Hidden";
            this.checkHidden.UseVisualStyleBackColor = true;
            // 
            // labelTaskIDValue
            // 
            this.labelTaskIDValue.AutoSize = true;
            this.labelTaskIDValue.Location = new System.Drawing.Point(53, 25);
            this.labelTaskIDValue.Name = "labelTaskIDValue";
            this.labelTaskIDValue.Size = new System.Drawing.Size(18, 13);
            this.labelTaskIDValue.TabIndex = 3;
            this.labelTaskIDValue.Text = "ID";
            // 
            // labelTaskID
            // 
            this.labelTaskID.AutoSize = true;
            this.labelTaskID.Location = new System.Drawing.Point(9, 25);
            this.labelTaskID.Name = "labelTaskID";
            this.labelTaskID.Size = new System.Drawing.Size(48, 13);
            this.labelTaskID.TabIndex = 2;
            this.labelTaskID.Text = "Task ID:";
            this.labelTaskID.Click += new System.EventHandler(this.labelTaskID_Click);
            // 
            // textName
            // 
            this.textName.Location = new System.Drawing.Point(56, 5);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(211, 20);
            this.textName.TabIndex = 1;
            this.textName.TextChanged += new System.EventHandler(this.textName_TextChanged);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(9, 7);
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
            this.textCode.Location = new System.Drawing.Point(2, 2);
            this.textCode.Margin = new System.Windows.Forms.Padding(2);
            this.textCode.Multiline = true;
            this.textCode.Name = "textCode";
            this.textCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textCode.Size = new System.Drawing.Size(798, 434);
            this.textCode.TabIndex = 4;
            this.textCode.Text = "Enter script code here";
            this.textCode.WordWrap = false;
            // 
            // tabWinScript
            // 
            this.tabWinScript.Controls.Add(this.tabScriptCode);
            this.tabWinScript.Controls.Add(this.tabScriptDetails);
            this.tabWinScript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabWinScript.Location = new System.Drawing.Point(0, 0);
            this.tabWinScript.Margin = new System.Windows.Forms.Padding(2);
            this.tabWinScript.Name = "tabWinScript";
            this.tabWinScript.SelectedIndex = 0;
            this.tabWinScript.Size = new System.Drawing.Size(810, 464);
            this.tabWinScript.TabIndex = 14;
            // 
            // tabScriptCode
            // 
            this.tabScriptCode.AutoScroll = true;
            this.tabScriptCode.Controls.Add(this.textCode);
            this.tabScriptCode.Location = new System.Drawing.Point(4, 22);
            this.tabScriptCode.Margin = new System.Windows.Forms.Padding(2);
            this.tabScriptCode.Name = "tabScriptCode";
            this.tabScriptCode.Padding = new System.Windows.Forms.Padding(2);
            this.tabScriptCode.Size = new System.Drawing.Size(802, 438);
            this.tabScriptCode.TabIndex = 0;
            this.tabScriptCode.Text = "Script";
            this.tabScriptCode.UseVisualStyleBackColor = true;
            // 
            // tabScriptDetails
            // 
            this.tabScriptDetails.BackColor = System.Drawing.SystemColors.Control;
            this.tabScriptDetails.Controls.Add(this.labelComments);
            this.tabScriptDetails.Controls.Add(this.richComments);
            this.tabScriptDetails.Controls.Add(this.labelTaskIDValue);
            this.tabScriptDetails.Controls.Add(this.buttonRun);
            this.tabScriptDetails.Controls.Add(this.checkHidden);
            this.tabScriptDetails.Controls.Add(this.buttonImport);
            this.tabScriptDetails.Controls.Add(this.buttonExport);
            this.tabScriptDetails.Controls.Add(this.labelName);
            this.tabScriptDetails.Controls.Add(this.labelTaskID);
            this.tabScriptDetails.Controls.Add(this.checkSysWow64);
            this.tabScriptDetails.Controls.Add(this.textName);
            this.tabScriptDetails.Controls.Add(this.radioVbs);
            this.tabScriptDetails.Controls.Add(this.labelTimeout);
            this.tabScriptDetails.Controls.Add(this.checkASync);
            this.tabScriptDetails.Controls.Add(this.radioPs1);
            this.tabScriptDetails.Controls.Add(this.radioCmd);
            this.tabScriptDetails.Controls.Add(this.numericTimeout);
            this.tabScriptDetails.Location = new System.Drawing.Point(4, 22);
            this.tabScriptDetails.Margin = new System.Windows.Forms.Padding(2);
            this.tabScriptDetails.Name = "tabScriptDetails";
            this.tabScriptDetails.Padding = new System.Windows.Forms.Padding(2);
            this.tabScriptDetails.Size = new System.Drawing.Size(802, 438);
            this.tabScriptDetails.TabIndex = 1;
            this.tabScriptDetails.Text = "Details";
            // 
            // labelComments
            // 
            this.labelComments.AutoSize = true;
            this.labelComments.Location = new System.Drawing.Point(9, 47);
            this.labelComments.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelComments.Name = "labelComments";
            this.labelComments.Size = new System.Drawing.Size(56, 13);
            this.labelComments.TabIndex = 14;
            this.labelComments.Text = "Comments";
            // 
            // richComments
            // 
            this.richComments.Location = new System.Drawing.Point(11, 70);
            this.richComments.Margin = new System.Windows.Forms.Padding(2);
            this.richComments.Name = "richComments";
            this.richComments.Size = new System.Drawing.Size(255, 130);
            this.richComments.TabIndex = 13;
            this.richComments.Text = "";
            // 
            // formWinTaskBuilder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 464);
            this.Controls.Add(this.tabWinScript);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(20, 379);
            this.Name = "formWinTaskBuilder";
            this.Text = "System Lackey : Task Builder";
            this.Load += new System.EventHandler(this.formTaskBuilder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericTimeout)).EndInit();
            this.tabWinScript.ResumeLayout(false);
            this.tabScriptCode.ResumeLayout(false);
            this.tabScriptCode.PerformLayout();
            this.tabScriptDetails.ResumeLayout(false);
            this.tabScriptDetails.PerformLayout();
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
        private System.Windows.Forms.CheckBox checkHidden;
        private System.Windows.Forms.Label labelTaskIDValue;
        private System.Windows.Forms.Label labelTaskID;
        private System.Windows.Forms.TextBox textName;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textCode;
        private System.Windows.Forms.TabControl tabWinScript;
        private System.Windows.Forms.TabPage tabScriptCode;
        private System.Windows.Forms.TabPage tabScriptDetails;
        private System.Windows.Forms.Label labelComments;
        private System.Windows.Forms.RichTextBox richComments;
    }
}

