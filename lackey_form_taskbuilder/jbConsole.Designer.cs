namespace SystemLackey.UI.Forms
{
    partial class jbConsole
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
            this.textOutput = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.loggingLevelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loggingLevelToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.informationToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.warningToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.errorToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.debugToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textOutput
            // 
            this.textOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textOutput.Location = new System.Drawing.Point(0, 24);
            this.textOutput.Multiline = true;
            this.textOutput.Name = "textOutput";
            this.textOutput.ReadOnly = true;
            this.textOutput.Size = new System.Drawing.Size(491, 238);
            this.textOutput.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loggingLevelToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(491, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // loggingLevelToolStripMenuItem
            // 
            this.loggingLevelToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loggingLevelToolStripMenuItem1});
            this.loggingLevelToolStripMenuItem.Name = "loggingLevelToolStripMenuItem";
            this.loggingLevelToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.loggingLevelToolStripMenuItem.Text = "Options";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showXMLToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // showXMLToolStripMenuItem
            // 
            this.showXMLToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allToolStripMenuItem,
            this.selectedToolStripMenuItem});
            this.showXMLToolStripMenuItem.Name = "showXMLToolStripMenuItem";
            this.showXMLToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.showXMLToolStripMenuItem.Text = "Show XML";
            // 
            // selectedToolStripMenuItem
            // 
            this.selectedToolStripMenuItem.Name = "selectedToolStripMenuItem";
            this.selectedToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.selectedToolStripMenuItem.Text = "Selected";
            // 
            // allToolStripMenuItem
            // 
            this.allToolStripMenuItem.Name = "allToolStripMenuItem";
            this.allToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.allToolStripMenuItem.Text = "All";
            this.allToolStripMenuItem.Click += new System.EventHandler(this.allToolStripMenuItem_Click);
            // 
            // loggingLevelToolStripMenuItem1
            // 
            this.loggingLevelToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.debugToolStripMenuItem1,
            this.informationToolStripMenuItem1,
            this.warningToolStripMenuItem1,
            this.errorToolStripMenuItem1});
            this.loggingLevelToolStripMenuItem1.Name = "loggingLevelToolStripMenuItem1";
            this.loggingLevelToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.loggingLevelToolStripMenuItem1.Text = "Logging Level";
            // 
            // informationToolStripMenuItem1
            // 
            this.informationToolStripMenuItem1.Name = "informationToolStripMenuItem1";
            this.informationToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.informationToolStripMenuItem1.Text = "1. Information";
            this.informationToolStripMenuItem1.Click += new System.EventHandler(this.informationToolStripMenuItem_Click);
            // 
            // warningToolStripMenuItem1
            // 
            this.warningToolStripMenuItem1.Name = "warningToolStripMenuItem1";
            this.warningToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.warningToolStripMenuItem1.Text = "2. Warning";
            this.warningToolStripMenuItem1.Click += new System.EventHandler(this.warningToolStripMenuItem_Click);
            // 
            // errorToolStripMenuItem1
            // 
            this.errorToolStripMenuItem1.Name = "errorToolStripMenuItem1";
            this.errorToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.errorToolStripMenuItem1.Text = "3. Error";
            this.errorToolStripMenuItem1.Click += new System.EventHandler(this.errorToolStripMenuItem_Click);
            // 
            // debugToolStripMenuItem1
            // 
            this.debugToolStripMenuItem1.Name = "debugToolStripMenuItem1";
            this.debugToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.debugToolStripMenuItem1.Text = "0. Debug";
            this.debugToolStripMenuItem1.Click += new System.EventHandler(this.debugToolStripMenuItem_Click);
            // 
            // jbConsole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 262);
            this.Controls.Add(this.textOutput);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "jbConsole";
            this.Text = "Console";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textOutput;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem loggingLevelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loggingLevelToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem debugToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem informationToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem warningToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem errorToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showXMLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectedToolStripMenuItem;
    }
}