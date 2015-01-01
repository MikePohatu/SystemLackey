namespace SystemLackey.UI.Forms
{
    partial class FormJBConsoleOptions
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
            this.checkFilterDebug = new System.Windows.Forms.CheckBox();
            this.checkFilterInfo = new System.Windows.Forms.CheckBox();
            this.checkFilterWarning = new System.Windows.Forms.CheckBox();
            this.checkFilterError = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkFilterDebug
            // 
            this.checkFilterDebug.AutoSize = true;
            this.checkFilterDebug.Location = new System.Drawing.Point(3, 19);
            this.checkFilterDebug.Name = "checkFilterDebug";
            this.checkFilterDebug.Size = new System.Drawing.Size(58, 17);
            this.checkFilterDebug.TabIndex = 0;
            this.checkFilterDebug.Text = "Debug";
            this.checkFilterDebug.UseVisualStyleBackColor = true;
            // 
            // checkFilterInfo
            // 
            this.checkFilterInfo.AutoSize = true;
            this.checkFilterInfo.Checked = true;
            this.checkFilterInfo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkFilterInfo.Location = new System.Drawing.Point(3, 41);
            this.checkFilterInfo.Name = "checkFilterInfo";
            this.checkFilterInfo.Size = new System.Drawing.Size(78, 17);
            this.checkFilterInfo.TabIndex = 1;
            this.checkFilterInfo.Text = "Information";
            this.checkFilterInfo.UseVisualStyleBackColor = true;
            // 
            // checkFilterWarning
            // 
            this.checkFilterWarning.AutoSize = true;
            this.checkFilterWarning.Checked = true;
            this.checkFilterWarning.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkFilterWarning.Location = new System.Drawing.Point(3, 64);
            this.checkFilterWarning.Name = "checkFilterWarning";
            this.checkFilterWarning.Size = new System.Drawing.Size(66, 17);
            this.checkFilterWarning.TabIndex = 2;
            this.checkFilterWarning.Text = "Warning";
            this.checkFilterWarning.UseVisualStyleBackColor = true;
            // 
            // checkFilterError
            // 
            this.checkFilterError.AutoSize = true;
            this.checkFilterError.Checked = true;
            this.checkFilterError.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkFilterError.Location = new System.Drawing.Point(3, 87);
            this.checkFilterError.Name = "checkFilterError";
            this.checkFilterError.Size = new System.Drawing.Size(48, 17);
            this.checkFilterError.TabIndex = 3;
            this.checkFilterError.Text = "Error";
            this.checkFilterError.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkFilterError);
            this.groupBox1.Controls.Add(this.checkFilterWarning);
            this.groupBox1.Controls.Add(this.checkFilterDebug);
            this.groupBox1.Controls.Add(this.checkFilterInfo);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(101, 110);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Logging Filters";
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(128, 97);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 6;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(128, 72);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FormJBConsoleOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(215, 130);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormJBConsoleOptions";
            this.Text = "Options";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox checkFilterDebug;
        private System.Windows.Forms.CheckBox checkFilterInfo;
        private System.Windows.Forms.CheckBox checkFilterWarning;
        private System.Windows.Forms.CheckBox checkFilterError;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
    }
}