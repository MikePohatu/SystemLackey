using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SystemLackey.Worker;
using SystemLackey.UI;
using SystemLackey.UI.Shell;
using SystemLackey.Logging;

namespace SystemLackey.UI.Forms
{
    public partial class FormJobBuilder : Form
    {
        private TreeNode rootNode;
        private Panel2Factory factory = new Panel2Factory();
        private Form panel2;
        private int childFormNumber = 0;
        private Logger logger = new Logger();

        // Properties
        public TreeNode Root
        {
            get { return this.rootNode; }
            set { this.rootNode = value; }
        }
        // /Properties

        public FormJobBuilder()
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
            Job t = new Job();
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

            panel2 = factory.Create(rootNode);
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
                        panel2.Close();
                        //MessageBox.Show(o.ToString(), o.ToString());
                        panel2 = factory.Create(e.Node);
                        ResetPanel2();
                    }
                }               
            }
        }

        //Insert a node into the tree, and create the appropriate step in the job. 
        private void InsertTask(ITask pTask,TreeNode pPrevNode)
        {
            treeJobList.BeginUpdate();
            Step s;
            TreeNode parentNode;
            int index;

            if (pPrevNode != rootNode)
            {
                Step prevStep = (Step)pPrevNode.Tag;

                //if selected node is a job, make the index 0 i.e. top of the sub tree
                if (prevStep.Task is Job)
                {
                    index = 0;
                    parentNode = pPrevNode;
                    s = JobEditor.Insert(pTask, (Job)prevStep.Task);
                }
                //otherwise make the new node below the previous one
                else
                {
                    index = pPrevNode.Index + 1;
                    parentNode = pPrevNode.Parent;
                    s = JobEditor.Insert(pTask, prevStep);
                }                         
            }

            else
            {
                parentNode = rootNode;
                index = 0;
                s = JobEditor.Insert(pTask, (Job)pPrevNode.Tag); 
            }


            //create the new node and set it up. 
            TreeNode node = new TreeNode();

            parentNode.Nodes.Insert(index, node);

            node.Tag = s;
            node.Name = s.Task.ID;
            node.Text = s.Task.Name;

            logger.Write("TreeNode created: " + node.Text + " - " + node.Index.ToString(),0);
            
            //Close panel2 and Spin up the new form
            if (panel2 != null)
            { panel2.Close(); }

            panel2 = factory.Create(node);
            ResetPanel2();
            treeJobList.SelectedNode = node;
            
            //Finished
            treeJobList.EndUpdate();
        }


        //===========================
        //Add -> Task methods
        //===========================
        private void menuItemAddTaskWinScript_Click(object sender, EventArgs e)
        {          
            WindowsScript t = new WindowsScript();
            t.Name = "Windows script";
            logger.Write("Task created: " + t.Name + " - " + t.ID, 1);
            this.InsertTask(t, treeJobList.SelectedNode);
        }

        private void menuItemAddTaskPower_Click(object sender, EventArgs e)
        {
            PowerControl t = new PowerControl();
            logger.Write("Task created: " + t.Name + " - " + t.ID, 1);
            this.InsertTask(t, treeJobList.SelectedNode);
        }

        private void subJobToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Create the new job. 
            Job t = new Job();
            t.Name = "New sub job";
            logger.Write("Task created: " + t.Name + " - " + t.ID, 1);
            this.InsertTask(t, treeJobList.SelectedNode);
        }

        //===========================

        private void consoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormJBConsole console = new FormJBConsole(logger);
            console.ParentJobBuilder = this;
            console.Show();
        }

        private void runJobToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Common.ConfirmJobRun())
            {
                if ((rootNode != null) && (rootNode.Tag != null))
                {
                    Object rootTag = rootNode.Tag;
                    Job rootJob = (Job)rootTag;
                    rootJob.Run();
                }
            }
        }
    }
}
