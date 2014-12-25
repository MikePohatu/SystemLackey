using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SystemLackey.Worker;

namespace SystemLackey.UI.Forms
{
    public partial class Form_JobBuilder : Form
    {
        private TreeNode rootNode;
        private Panel2Factory factory = new Panel2Factory();
        private Form panel2;
        private int childFormNumber = 0;

        public Form_JobBuilder()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //toolStripMain.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void windowsScriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Application.Run(new formWinTaskBuilder());
            panel2 = new Form_WinTaskBuilder();
            ResetPanel2();            
        }

        //From menu:
        // New -> Job
        private void jobToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.rootNode != null)
            {
                string message = "This will create a new root job, discarding any unsaved  changes" + Environment.NewLine + "Continue?";
                if (MessageBox.Show(message, "Confirmation", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    StartNewJob();
                }
            }
            else
            {
                StartNewJob();
            }
        }

        private void StartNewJob()
        {
            treeJobList.BeginUpdate();

            //Create the new job and root node. 
            Task_Job t = new Task_Job();
            t.Name = "New job";

            //create the new node and set it up. 
            rootNode = new TreeNode();
            rootNode.Tag = t;
            rootNode.Name = t.ID;
            rootNode.Text = t.Name;

            treeJobList.Nodes.Clear();

            treeJobList.Nodes.Add(rootNode);

            //Close panel2 and Spin up the new form
            if (panel2 != null)
            { panel2.Close(); }

            panel2 = factory.Create(t, rootNode);
            ResetPanel2();

            treeJobList.SelectedNode = rootNode;

            treeJobList.EndUpdate();
        }



        private void ResetPanel2()
        {
            panel2.MdiParent = this;
            panel2.TopLevel = false;
            panel2.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            panel2.Dock = DockStyle.Fill;
            // Set the Parent Form of the Child window.
            splitMain.Panel2.Controls.Add(panel2);

            // Display the new form.
            panel2.Show();
        }

        private void Event_treeJobList_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e != null)
            {
                if ( e.Node != null )
                {
                    if (e.Node != treeJobList.SelectedNode)
                    {
                        treeJobList.SelectedNode = e.Node;
                        Object o = treeJobList.SelectedNode.Tag;
                        panel2.Close();
                        //MessageBox.Show(o.ToString(), o.ToString());
                        panel2 = factory.Create(o,treeJobList.SelectedNode);
                        ResetPanel2();
                    }
                }               
            }
        }

        private void windowsScriptToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Application.Run(new formWinTaskBuilder());
            panel2 = new Form_WinTaskBuilder();
            ResetPanel2();  
        }


        private void menuItemAddTaskWinScript_Click(object sender, EventArgs e)
        {
            treeJobList.BeginUpdate();

            //Create the new job and root node. 
            Task_WinScript t = new Task_WinScript();
            t.Name = "Windows script";

            //create the new node and set it up. 
            TreeNode node = new TreeNode();
            node.Tag = t;
            node.Name = t.ID;
            node.Text = t.Name;

            rootNode.Nodes.Add(node);

            //Close panel2 and Spin up the new form
            if (panel2 != null)
            { panel2.Close(); }

            panel2 = factory.Create(t, node);
            ResetPanel2();

            treeJobList.SelectedNode = node;

            treeJobList.EndUpdate();
        }
    }
}
