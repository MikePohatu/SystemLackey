namespace SystemLackey.UI.Forms
{
    partial class Form_JobDetails
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
            this.SuspendLayout();
            // 
            // labelJobID
            // 
            this.labelJobID.AutoSize = true;
            this.labelJobID.Location = new System.Drawing.Point(12, 13);
            this.labelJobID.Name = "labelJobID";
            this.labelJobID.Size = new System.Drawing.Size(41, 13);
            this.labelJobID.TabIndex = 0;
            this.labelJobID.Text = "Job ID:";
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
            this.textName.Size = new System.Drawing.Size(340, 20);
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
            this.textComments.Size = new System.Drawing.Size(340, 195);
            this.textComments.TabIndex = 5;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(342, 257);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 6;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // Form_JobDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(430, 293);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textComments);
            this.Controls.Add(this.labelComments);
            this.Controls.Add(this.textName);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.labelJobGuid);
            this.Controls.Add(this.labelJobID);
            this.Name = "Form_JobDetails";
            this.Text = "Job Details";
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
    }
}