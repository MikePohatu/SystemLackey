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
            this.checkHidden = new System.Windows.Forms.CheckBox();
            this.labelTaskIDValue = new System.Windows.Forms.Label();
            this.labelTaskID = new System.Windows.Forms.Label();
            this.textName = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.textCode = new System.Windows.Forms.TextBox();
            this.tabWinScript = new System.Windows.Forms.TabControl();
            this.tabScriptCode = new System.Windows.Forms.TabPage();
            this.tabScriptDetails = new System.Windows.Forms.TabPage();
            this.richComments = new System.Windows.Forms.RichTextBox();
            this.labelComments = new System.Windows.Forms.Label();
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
            this.radioCmd.Location = new System.Drawing.Point(415, 11);
            this.radioCmd.Name = "radioCmd";
            this.radioCmd.Size = new System.Drawing.Size(76, 24);
            this.radioCmd.TabIndex = 0;
            this.radioCmd.TabStop = true;
            this.radioCmd.Text = "Batch";
            this.radioCmd.UseVisualStyleBackColor = true;
            this.radioCmd.CheckedChanged += new System.EventHandler(this.radioCmd_CheckedChanged);
            // 
            // radioVbs
            // 
            this.radioVbs.AutoSize = true;
            this.radioVbs.Location = new System.Drawing.Point(415, 42);
            this.radioVbs.Name = "radioVbs";
            this.radioVbs.Size = new System.Drawing.Size(97, 24);
            this.radioVbs.TabIndex = 1;
            this.radioVbs.Text = "VBScript";
            this.radioVbs.UseVisualStyleBackColor = true;
            this.radioVbs.CheckedChanged += new System.EventHandler(this.radioVbs_CheckedChanged);
            // 
            // radioPs1
            // 
            this.radioPs1.AutoSize = true;
            this.radioPs1.Location = new System.Drawing.Point(415, 73);
            this.radioPs1.Name = "radioPs1";
            this.radioPs1.Size = new System.Drawing.Size(110, 24);
            this.radioPs1.TabIndex = 2;
            this.radioPs1.Text = "Powershell";
            this.radioPs1.UseVisualStyleBackColor = true;
            this.radioPs1.CheckedChanged += new System.EventHandler(this.radioPs1_CheckedChanged);
            // 
            // checkASync
            // 
            this.checkASync.AutoSize = true;
            this.checkASync.Location = new System.Drawing.Point(415, 157);
            this.checkASync.Name = "checkASync";
            this.checkASync.Size = new System.Drawing.Size(139, 24);
            this.checkASync.TabIndex = 4;
            this.checkASync.Text = "ASynchronous";
            this.checkASync.UseVisualStyleBackColor = true;
            // 
            // numericTimeout
            // 
            this.numericTimeout.Location = new System.Drawing.Point(726, 9);
            this.numericTimeout.Maximum = new decimal(new int[] {
            86400,
            0,
            0,
            0});
            this.numericTimeout.Name = "numericTimeout";
            this.numericTimeout.Size = new System.Drawing.Size(87, 26);
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
            this.labelTimeout.Location = new System.Drawing.Point(580, 11);
            this.labelTimeout.Name = "labelTimeout";
            this.labelTimeout.Size = new System.Drawing.Size(140, 20);
            this.labelTimeout.TabIndex = 6;
            this.labelTimeout.Text = "Timeout (seconds)";
            this.labelTimeout.Click += new System.EventHandler(this.labelTimeout_Click);
            // 
            // checkSysWow64
            // 
            this.checkSysWow64.AutoSize = true;
            this.checkSysWow64.Location = new System.Drawing.Point(415, 126);
            this.checkSysWow64.Name = "checkSysWow64";
            this.checkSysWow64.Size = new System.Drawing.Size(131, 24);
            this.checkSysWow64.TabIndex = 7;
            this.checkSysWow64.Text = "32bit on 64bit";
            this.checkSysWow64.UseVisualStyleBackColor = true;
            this.checkSysWow64.CheckedChanged += new System.EventHandler(this.checkSysWow64_CheckedChanged);
            // 
            // buttonExport
            // 
            this.buttonExport.Location = new System.Drawing.Point(417, 268);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(120, 38);
            this.buttonExport.TabIndex = 8;
            this.buttonExport.Text = "Export";
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // buttonImport
            // 
            this.buttonImport.Location = new System.Drawing.Point(417, 223);
            this.buttonImport.Name = "buttonImport";
            this.buttonImport.Size = new System.Drawing.Size(120, 38);
            this.buttonImport.TabIndex = 9;
            this.buttonImport.Text = "Import";
            this.buttonImport.UseVisualStyleBackColor = true;
            this.buttonImport.Click += new System.EventHandler(this.buttonImport_Click);
            // 
            // buttonRun
            // 
            this.buttonRun.Location = new System.Drawing.Point(693, 268);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(120, 38);
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
            this.checkHidden.Location = new System.Drawing.Point(417, 186);
            this.checkHidden.Name = "checkHidden";
            this.checkHidden.Size = new System.Drawing.Size(86, 24);
            this.checkHidden.TabIndex = 12;
            this.checkHidden.Text = "Hidden";
            this.checkHidden.UseVisualStyleBackColor = true;
            // 
            // labelTaskIDValue
            // 
            this.labelTaskIDValue.AutoSize = true;
            this.labelTaskIDValue.Location = new System.Drawing.Point(80, 39);
            this.labelTaskIDValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTaskIDValue.Name = "labelTaskIDValue";
            this.labelTaskIDValue.Size = new System.Drawing.Size(26, 20);
            this.labelTaskIDValue.TabIndex = 3;
            this.labelTaskIDValue.Text = "ID";
            // 
            // labelTaskID
            // 
            this.labelTaskID.AutoSize = true;
            this.labelTaskID.Location = new System.Drawing.Point(13, 39);
            this.labelTaskID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTaskID.Name = "labelTaskID";
            this.labelTaskID.Size = new System.Drawing.Size(68, 20);
            this.labelTaskID.TabIndex = 2;
            this.labelTaskID.Text = "Task ID:";
            this.labelTaskID.Click += new System.EventHandler(this.labelTaskID_Click);
            // 
            // textName
            // 
            this.textName.Location = new System.Drawing.Point(84, 8);
            this.textName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(314, 26);
            this.textName.TabIndex = 1;
            this.textName.TextChanged += new System.EventHandler(this.textName_TextChanged);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(13, 11);
            this.labelName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(55, 20);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Name:";
            // 
            // textCode
            // 
            this.textCode.AcceptsReturn = true;
            this.textCode.AcceptsTab = true;
            this.textCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textCode.Location = new System.Drawing.Point(3, 3);
            this.textCode.Multiline = true;
            this.textCode.Name = "textCode";
            this.textCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textCode.Size = new System.Drawing.Size(410, 373);
            this.textCode.TabIndex = 4;
            this.textCode.Text = "Enter script code here";
            this.textCode.WordWrap = false;
            this.textCode.TextChanged += new System.EventHandler(this.textCode_TextChanged_1);
            // 
            // tabWinScript
            // 
            this.tabWinScript.Controls.Add(this.tabScriptCode);
            this.tabWinScript.Controls.Add(this.tabScriptDetails);
            this.tabWinScript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabWinScript.Location = new System.Drawing.Point(0, 0);
            this.tabWinScript.Name = "tabWinScript";
            this.tabWinScript.SelectedIndex = 0;
            this.tabWinScript.Size = new System.Drawing.Size(1215, 714);
            this.tabWinScript.TabIndex = 14;
            // 
            // tabScriptCode
            // 
            this.tabScriptCode.AutoScroll = true;
            this.tabScriptCode.Controls.Add(this.textCode);
            this.tabScriptCode.Location = new System.Drawing.Point(4, 29);
            this.tabScriptCode.Name = "tabScriptCode";
            this.tabScriptCode.Padding = new System.Windows.Forms.Padding(3);
            this.tabScriptCode.Size = new System.Drawing.Size(416, 379);
            this.tabScriptCode.TabIndex = 0;
            this.tabScriptCode.Text = "Script";
            this.tabScriptCode.UseVisualStyleBackColor = true;
            // 
            // tabScriptDetails
            // 
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
            this.tabScriptDetails.Location = new System.Drawing.Point(4, 29);
            this.tabScriptDetails.Name = "tabScriptDetails";
            this.tabScriptDetails.Padding = new System.Windows.Forms.Padding(3);
            this.tabScriptDetails.Size = new System.Drawing.Size(1207, 681);
            this.tabScriptDetails.TabIndex = 1;
            this.tabScriptDetails.Text = "Details";
            this.tabScriptDetails.UseVisualStyleBackColor = true;
            // 
            // richComments
            // 
            this.richComments.Location = new System.Drawing.Point(17, 108);
            this.richComments.Name = "richComments";
            this.richComments.Size = new System.Drawing.Size(381, 198);
            this.richComments.TabIndex = 13;
            this.richComments.Text = "";
            // 
            // labelComments
            // 
            this.labelComments.AutoSize = true;
            this.labelComments.Location = new System.Drawing.Point(13, 73);
            this.labelComments.Name = "labelComments";
            this.labelComments.Size = new System.Drawing.Size(86, 20);
            this.labelComments.TabIndex = 14;
            this.labelComments.Text = "Comments";
            // 
            // formWinTaskBuilder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1215, 714);
            this.Controls.Add(this.tabWinScript);
            this.MinimumSize = new System.Drawing.Size(22, 562);
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

