namespace SystemLackey.UI.Forms
{
    partial class FormPowerControl
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
            this.labelJobID = new System.Windows.Forms.Label();
            this.labelJobGuid = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.textName = new System.Windows.Forms.TextBox();
            this.labelComments = new System.Windows.Forms.Label();
            this.textComments = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.radioReboot = new System.Windows.Forms.RadioButton();
            this.radioShutdown = new System.Windows.Forms.RadioButton();
            this.radioLogoff = new System.Windows.Forms.RadioButton();
            this.numericUpDownWait = new System.Windows.Forms.NumericUpDown();
            this.labelWait = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWait)).BeginInit();
            this.SuspendLayout();
            // 
            // labelJobID
            // 
            this.labelJobID.AutoSize = true;
            this.labelJobID.Location = new System.Drawing.Point(12, 13);
            this.labelJobID.Name = "labelJobID";
            this.labelJobID.Size = new System.Drawing.Size(48, 13);
            this.labelJobID.TabIndex = 0;
            this.labelJobID.Text = "Task ID:";
            // 
            // labelJobGuid
            // 
            this.labelJobGuid.AutoSize = true;
            this.labelJobGuid.Location = new System.Drawing.Point(75, 13);
            this.labelJobGuid.Name = "labelJobGuid";
            this.labelJobGuid.Size = new System.Drawing.Size(18, 13);
            this.labelJobGuid.TabIndex = 1;
            this.labelJobGuid.Text = "ID";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(12, 33);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(38, 13);
            this.labelName.TabIndex = 2;
            this.labelName.Text = "Name:";
            // 
            // textName
            // 
            this.textName.Location = new System.Drawing.Point(78, 29);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(186, 20);
            this.textName.TabIndex = 3;
            // 
            // labelComments
            // 
            this.labelComments.AutoSize = true;
            this.labelComments.Location = new System.Drawing.Point(12, 53);
            this.labelComments.Name = "labelComments";
            this.labelComments.Size = new System.Drawing.Size(56, 13);
            this.labelComments.TabIndex = 4;
            this.labelComments.Text = "Comments";
            // 
            // textComments
            // 
            this.textComments.AcceptsReturn = true;
            this.textComments.Location = new System.Drawing.Point(78, 55);
            this.textComments.Multiline = true;
            this.textComments.Name = "textComments";
            this.textComments.Size = new System.Drawing.Size(186, 195);
            this.textComments.TabIndex = 5;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(285, 227);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 6;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // radioReboot
            // 
            this.radioReboot.AutoSize = true;
            this.radioReboot.Checked = true;
            this.radioReboot.Location = new System.Drawing.Point(282, 29);
            this.radioReboot.Name = "radioReboot";
            this.radioReboot.Size = new System.Drawing.Size(60, 17);
            this.radioReboot.TabIndex = 7;
            this.radioReboot.TabStop = true;
            this.radioReboot.Text = "Reboot";
            this.radioReboot.UseVisualStyleBackColor = true;
            // 
            // radioShutdown
            // 
            this.radioShutdown.AutoSize = true;
            this.radioShutdown.Location = new System.Drawing.Point(282, 51);
            this.radioShutdown.Name = "radioShutdown";
            this.radioShutdown.Size = new System.Drawing.Size(73, 17);
            this.radioShutdown.TabIndex = 8;
            this.radioShutdown.TabStop = true;
            this.radioShutdown.Text = "Shutdown";
            this.radioShutdown.UseVisualStyleBackColor = true;
            // 
            // radioLogoff
            // 
            this.radioLogoff.AutoSize = true;
            this.radioLogoff.Location = new System.Drawing.Point(282, 72);
            this.radioLogoff.Name = "radioLogoff";
            this.radioLogoff.Size = new System.Drawing.Size(55, 17);
            this.radioLogoff.TabIndex = 9;
            this.radioLogoff.TabStop = true;
            this.radioLogoff.Text = "Logoff";
            this.radioLogoff.UseVisualStyleBackColor = true;
            // 
            // numericUpDownWait
            // 
            this.numericUpDownWait.Location = new System.Drawing.Point(282, 119);
            this.numericUpDownWait.Name = "numericUpDownWait";
            this.numericUpDownWait.Size = new System.Drawing.Size(78, 20);
            this.numericUpDownWait.TabIndex = 10;
            this.numericUpDownWait.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelWait
            // 
            this.labelWait.AutoSize = true;
            this.labelWait.Location = new System.Drawing.Point(282, 100);
            this.labelWait.Name = "labelWait";
            this.labelWait.Size = new System.Drawing.Size(78, 13);
            this.labelWait.TabIndex = 11;
            this.labelWait.Text = "Wait (seconds)";
            // 
            // FormPowerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(366, 257);
            this.Controls.Add(this.labelWait);
            this.Controls.Add(this.numericUpDownWait);
            this.Controls.Add(this.radioLogoff);
            this.Controls.Add(this.radioShutdown);
            this.Controls.Add(this.radioReboot);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textComments);
            this.Controls.Add(this.labelComments);
            this.Controls.Add(this.textName);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.labelJobGuid);
            this.Controls.Add(this.labelJobID);
            this.Name = "FormPowerControl";
            this.Text = "Job Details";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWait)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelJobID;
        private System.Windows.Forms.Label labelJobGuid;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textName;
        private System.Windows.Forms.Label labelComments;
        private System.Windows.Forms.TextBox textComments;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.RadioButton radioReboot;
        private System.Windows.Forms.RadioButton radioShutdown;
        private System.Windows.Forms.RadioButton radioLogoff;
        private System.Windows.Forms.NumericUpDown numericUpDownWait;
        private System.Windows.Forms.Label labelWait;
    }
}