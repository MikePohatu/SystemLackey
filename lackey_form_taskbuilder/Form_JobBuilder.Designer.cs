namespace lackey_form_taskbuilder
{
    partial class formTaskBuilder
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
            this.textCode = new System.Windows.Forms.TextBox();
            this.checkASync = new System.Windows.Forms.CheckBox();
            this.numericTimeout = new System.Windows.Forms.NumericUpDown();
            this.labelTimeout = new System.Windows.Forms.Label();
            this.checkSysWow64 = new System.Windows.Forms.CheckBox();
            this.buttonExport = new System.Windows.Forms.Button();
            this.buttonImport = new System.Windows.Forms.Button();
            this.buttonRun = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.checkHidden = new System.Windows.Forms.CheckBox();
            this.buttonTEST = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericTimeout)).BeginInit();
            this.SuspendLayout();
            // 
            // radioCmd
            // 
            this.radioCmd.AutoSize = true;
            this.radioCmd.Location = new System.Drawing.Point(1060, 18);
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
            this.radioVbs.Location = new System.Drawing.Point(1060, 49);
            this.radioVbs.Name = "radioVbs";
            this.radioVbs.Size = new System.Drawing.Size(97, 24);
            this.radioVbs.TabIndex = 1;
            this.radioVbs.TabStop = true;
            this.radioVbs.Text = "VBScript";
            this.radioVbs.UseVisualStyleBackColor = true;
            this.radioVbs.CheckedChanged += new System.EventHandler(this.radioVbs_CheckedChanged);
            // 
            // radioPs1
            // 
            this.radioPs1.AutoSize = true;
            this.radioPs1.Location = new System.Drawing.Point(1060, 80);
            this.radioPs1.Name = "radioPs1";
            this.radioPs1.Size = new System.Drawing.Size(110, 24);
            this.radioPs1.TabIndex = 2;
            this.radioPs1.TabStop = true;
            this.radioPs1.Text = "Powershell";
            this.radioPs1.UseVisualStyleBackColor = true;
            this.radioPs1.CheckedChanged += new System.EventHandler(this.radioPs1_CheckedChanged);
            // 
            // textCode
            // 
            this.textCode.AcceptsReturn = true;
            this.textCode.AcceptsTab = true;
            this.textCode.Location = new System.Drawing.Point(12, 18);
            this.textCode.Multiline = true;
            this.textCode.Name = "textCode";
            this.textCode.Size = new System.Drawing.Size(1021, 606);
            this.textCode.TabIndex = 3;
            // 
            // checkASync
            // 
            this.checkASync.AutoSize = true;
            this.checkASync.Location = new System.Drawing.Point(1059, 249);
            this.checkASync.Name = "checkASync";
            this.checkASync.Size = new System.Drawing.Size(139, 24);
            this.checkASync.TabIndex = 4;
            this.checkASync.Text = "ASynchronous";
            this.checkASync.UseVisualStyleBackColor = true;
            // 
            // numericTimeout
            // 
            this.numericTimeout.Location = new System.Drawing.Point(1060, 148);
            this.numericTimeout.Maximum = new decimal(new int[] {
            86400,
            0,
            0,
            0});
            this.numericTimeout.Name = "numericTimeout";
            this.numericTimeout.Size = new System.Drawing.Size(130, 26);
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
            this.labelTimeout.Location = new System.Drawing.Point(1056, 125);
            this.labelTimeout.Name = "labelTimeout";
            this.labelTimeout.Size = new System.Drawing.Size(66, 20);
            this.labelTimeout.TabIndex = 6;
            this.labelTimeout.Text = "Timeout";
            // 
            // checkSysWow64
            // 
            this.checkSysWow64.AutoSize = true;
            this.checkSysWow64.Location = new System.Drawing.Point(1059, 219);
            this.checkSysWow64.Name = "checkSysWow64";
            this.checkSysWow64.Size = new System.Drawing.Size(131, 24);
            this.checkSysWow64.TabIndex = 7;
            this.checkSysWow64.Text = "32bit on 64bit";
            this.checkSysWow64.UseVisualStyleBackColor = true;
            this.checkSysWow64.CheckedChanged += new System.EventHandler(this.checkSysWow64_CheckedChanged);
            // 
            // buttonExport
            // 
            this.buttonExport.Location = new System.Drawing.Point(1060, 395);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(110, 29);
            this.buttonExport.TabIndex = 8;
            this.buttonExport.Text = "Export";
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // buttonImport
            // 
            this.buttonImport.Location = new System.Drawing.Point(1060, 354);
            this.buttonImport.Name = "buttonImport";
            this.buttonImport.Size = new System.Drawing.Size(110, 29);
            this.buttonImport.TabIndex = 9;
            this.buttonImport.Text = "Import";
            this.buttonImport.UseVisualStyleBackColor = true;
            this.buttonImport.Click += new System.EventHandler(this.buttonImport_Click);
            // 
            // buttonRun
            // 
            this.buttonRun.Location = new System.Drawing.Point(1060, 594);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(110, 29);
            this.buttonRun.TabIndex = 10;
            this.buttonRun.Text = "Run";
            this.buttonRun.UseVisualStyleBackColor = true;
            this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(1060, 514);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(110, 29);
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
            this.checkHidden.Location = new System.Drawing.Point(1060, 279);
            this.checkHidden.Name = "checkHidden";
            this.checkHidden.Size = new System.Drawing.Size(86, 24);
            this.checkHidden.TabIndex = 12;
            this.checkHidden.Text = "Hidden";
            this.checkHidden.UseVisualStyleBackColor = true;
            // 
            // buttonTEST
            // 
            this.buttonTEST.Location = new System.Drawing.Point(1059, 446);
            this.buttonTEST.Name = "buttonTEST";
            this.buttonTEST.Size = new System.Drawing.Size(75, 23);
            this.buttonTEST.TabIndex = 13;
            this.buttonTEST.Text = "TEST";
            this.buttonTEST.UseVisualStyleBackColor = true;
            this.buttonTEST.Click += new System.EventHandler(this.buttonTest_Click);
            // 
            // formTaskBuilder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1204, 635);
            this.Controls.Add(this.buttonTEST);
            this.Controls.Add(this.checkHidden);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonRun);
            this.Controls.Add(this.buttonImport);
            this.Controls.Add(this.buttonExport);
            this.Controls.Add(this.checkSysWow64);
            this.Controls.Add(this.labelTimeout);
            this.Controls.Add(this.numericTimeout);
            this.Controls.Add(this.checkASync);
            this.Controls.Add(this.textCode);
            this.Controls.Add(this.radioPs1);
            this.Controls.Add(this.radioVbs);
            this.Controls.Add(this.radioCmd);
            this.Name = "formTaskBuilder";
            this.Text = "System Lackey : Task Builder";
            this.Load += new System.EventHandler(this.formTaskBuilder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericTimeout)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioCmd;
        private System.Windows.Forms.RadioButton radioVbs;
        private System.Windows.Forms.RadioButton radioPs1;
        private System.Windows.Forms.TextBox textCode;
        private System.Windows.Forms.CheckBox checkASync;
        private System.Windows.Forms.NumericUpDown numericTimeout;
        private System.Windows.Forms.Label labelTimeout;
        private System.Windows.Forms.CheckBox checkSysWow64;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.Button buttonImport;
        private System.Windows.Forms.Button buttonRun;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.CheckBox checkHidden;
        private System.Windows.Forms.Button buttonTEST;
    }
}

