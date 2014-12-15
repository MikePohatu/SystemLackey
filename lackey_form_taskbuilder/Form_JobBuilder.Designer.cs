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
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.buttonExport = new System.Windows.Forms.Button();
            this.buttonImport = new System.Windows.Forms.Button();
            this.buttonRun = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericTimeout)).BeginInit();
            this.SuspendLayout();
            // 
            // radioCmd
            // 
            this.radioCmd.AutoSize = true;
            this.radioCmd.Location = new System.Drawing.Point(707, 12);
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
            this.radioVbs.Location = new System.Drawing.Point(707, 32);
            this.radioVbs.Margin = new System.Windows.Forms.Padding(2);
            this.radioVbs.Name = "radioVbs";
            this.radioVbs.Size = new System.Drawing.Size(66, 17);
            this.radioVbs.TabIndex = 1;
            this.radioVbs.TabStop = true;
            this.radioVbs.Text = "VBScript";
            this.radioVbs.UseVisualStyleBackColor = true;
            // 
            // radioPs1
            // 
            this.radioPs1.AutoSize = true;
            this.radioPs1.Location = new System.Drawing.Point(707, 52);
            this.radioPs1.Margin = new System.Windows.Forms.Padding(2);
            this.radioPs1.Name = "radioPs1";
            this.radioPs1.Size = new System.Drawing.Size(76, 17);
            this.radioPs1.TabIndex = 2;
            this.radioPs1.TabStop = true;
            this.radioPs1.Text = "Powershell";
            this.radioPs1.UseVisualStyleBackColor = true;
            // 
            // textCode
            // 
            this.textCode.Location = new System.Drawing.Point(8, 12);
            this.textCode.Margin = new System.Windows.Forms.Padding(2);
            this.textCode.Multiline = true;
            this.textCode.Name = "textCode";
            this.textCode.Size = new System.Drawing.Size(682, 395);
            this.textCode.TabIndex = 3;
            // 
            // checkASync
            // 
            this.checkASync.AutoSize = true;
            this.checkASync.Location = new System.Drawing.Point(707, 140);
            this.checkASync.Margin = new System.Windows.Forms.Padding(2);
            this.checkASync.Name = "checkASync";
            this.checkASync.Size = new System.Drawing.Size(95, 17);
            this.checkASync.TabIndex = 4;
            this.checkASync.Text = "ASynchronous";
            this.checkASync.UseVisualStyleBackColor = true;
            // 
            // numericTimeout
            // 
            this.numericTimeout.Location = new System.Drawing.Point(707, 96);
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
            this.labelTimeout.Location = new System.Drawing.Point(704, 81);
            this.labelTimeout.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTimeout.Name = "labelTimeout";
            this.labelTimeout.Size = new System.Drawing.Size(45, 13);
            this.labelTimeout.TabIndex = 6;
            this.labelTimeout.Text = "Timeout";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(707, 161);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(90, 17);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "32bit on 64bit";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // buttonExport
            // 
            this.buttonExport.Location = new System.Drawing.Point(707, 257);
            this.buttonExport.Margin = new System.Windows.Forms.Padding(2);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(73, 19);
            this.buttonExport.TabIndex = 8;
            this.buttonExport.Text = "Export";
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // buttonImport
            // 
            this.buttonImport.Location = new System.Drawing.Point(707, 230);
            this.buttonImport.Margin = new System.Windows.Forms.Padding(2);
            this.buttonImport.Name = "buttonImport";
            this.buttonImport.Size = new System.Drawing.Size(73, 19);
            this.buttonImport.TabIndex = 9;
            this.buttonImport.Text = "Import";
            this.buttonImport.UseVisualStyleBackColor = true;
            this.buttonImport.Click += new System.EventHandler(this.buttonImport_Click);
            // 
            // buttonRun
            // 
            this.buttonRun.Location = new System.Drawing.Point(707, 386);
            this.buttonRun.Margin = new System.Windows.Forms.Padding(2);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(73, 19);
            this.buttonRun.TabIndex = 10;
            this.buttonRun.Text = "Run";
            this.buttonRun.UseVisualStyleBackColor = true;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(707, 334);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(73, 19);
            this.buttonSave.TabIndex = 11;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // formTaskBuilder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 413);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonRun);
            this.Controls.Add(this.buttonImport);
            this.Controls.Add(this.buttonExport);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.labelTimeout);
            this.Controls.Add(this.numericTimeout);
            this.Controls.Add(this.checkASync);
            this.Controls.Add(this.textCode);
            this.Controls.Add(this.radioPs1);
            this.Controls.Add(this.radioVbs);
            this.Controls.Add(this.radioCmd);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "formTaskBuilder";
            this.Text = "System Lackey : Task Builder";
            this.Load += new System.EventHandler(this.Form1_Load);
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
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.Button buttonImport;
        private System.Windows.Forms.Button buttonRun;
        private System.Windows.Forms.Button buttonSave;
    }
}

