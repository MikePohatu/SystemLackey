//    FormJobBuilder.cs: The JobBuilder Windows forms bit
//    Copyright (C) 2015 Mike Pohatu

//    This program is free software; you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation; version 2 of the License.

//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU General Public License for more details.

//    You should have received a copy of the GNU General Public License along
//    with this program; if not, write to the Free Software Foundation, Inc.,
//    51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Threading;

using SystemLackey.Core.IO;
using SystemLackey.Core.UI;
using SystemLackey.Core.Tasks;
using SystemLackey.Core.Worker;
using SystemLackey.Core.Messaging;
using SystemLackey.Core.Service;
using SystemLackey.Core;

namespace SystemLackey.UI.Forms
{
    public partial class FormJobBuilder : MessagingForm
    {
        private TreeNode rootNode;
        private Panel2Factory factory = new Panel2Factory();
        private Form panel2;
        private int childFormNumber = 0;
        private Logger logger = new Logger();
        private JobPackage jp;

        public JobScheduler JobScheduler { get; set; }

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
            factory.SendMessageEvent += this.ForwardMessage;
        }

        //Forward any logging messages from the task up the chain
        public override void ForwardMessage(object o, MessageEventArgs e)
        {
            logger.Write(o,e);
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
                if (CommonTasks.ConfirmNewJob())
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

            //cleanup old event listeners
            if (rootNode != null)
            {
                Job oldJob = (Job)rootNode.Tag;
                oldJob.SendMessageEvent -= this.ForwardMessage;
            }

            //Create the new job and root node. 
            Job t = new Job();
            
            //subscribe to the jobs logs
            t.SendMessageEvent += this.ForwardMessage;

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

        //Insert a new node into the tree, and create the appropriate step in the job. 
        private void InsertNewTask(ITask pTask,TreeNode pPrevNode)
        {
            if (this.rootNode != null)
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

                //the rootnode is selected. 
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
        }


        //===========================
        //Add -> Task methods
        //===========================
        private void menuItemAddTaskWinScript_Click(object sender, EventArgs e)
        {          
            WindowsScript t = new WindowsScript();
            t.Name = "Windows script";
            logger.Write("Task created: " + t.Name + " - " + t.ID, 1);
            this.InsertNewTask(t, treeJobList.SelectedNode);
        }

        private void menuItemAddTaskPower_Click(object sender, EventArgs e)
        {
            PowerControl t = new PowerControl();
            logger.Write("Task created: " + t.Name + " - " + t.ID, 1);
            this.InsertNewTask(t, treeJobList.SelectedNode);
        }

        private void subJobToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Create the new job. 
            Job t = new Job();
            t.Name = "New sub job";
            logger.Write("Task created: " + t.Name + " - " + t.ID, 1);
            this.InsertNewTask(t, treeJobList.SelectedNode);
        }

        //===========================
        //start the console for diags. 
        private void consoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread jbThread = new Thread(this.LaunchJBConsole);
            jbThread.SetApartmentState(ApartmentState.STA);
            jbThread.IsBackground = true;
            jbThread.Start();          
        }

        private void LaunchJBConsole()
        {
            
            FormJBConsole console = new FormJBConsole(logger);
            console.ParentJobBuilder = this;
            //using (Form1 _form = new Form1())
            //{
            //    Application.Run(_form);
            //}
            Application.Run(console);
            //console.Show();
        }
        

        //run the job as listed. 
        private void runJobToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CommonTasks.ConfirmJobRun())
            {
                if ((rootNode != null) && (rootNode.Tag != null))
                {
                    Object rootTag = rootNode.Tag;
                    Job rootJob = (Job)rootTag;
                    //var scheduler = new JobScheduler();
                    //var js = new JobSchedule();

                    //scheduler.SendMessageEvent += this.ForwardMessage;

                    //js.Job = rootJob;
                    //js.StartTime = DateTime.Now;
                    //scheduler.Add(js);
                    var runner = new JobRunner(rootJob);
                    runner.SendMessageEvent += this.ForwardMessage;
                    Thread runnerThread = new Thread(runner.Run);
                    runnerThread.IsBackground = false;
                    runnerThread.Start(); 
                    //runner.Run();
                    //runner.SendMessageEvent -= this.ForwardMessage;
                    //scheduler.SendMessageEvent += this.ForwardMessage;
                }
            }
        }

        //Export the job
        private void buttonExport_Click(object sender, EventArgs e)
        {
            if ( rootNode != null)
            {
                Job rootJob = (Job)rootNode.Tag;
                CommonTasks.ExportZip(rootJob);
            }

            else { logger.Write("No job to export", 0); }
        }

        //Import a job and populate the tree.
        private void buttonImport_Click(object sender, EventArgs e)
        {
            BuildFromPackage(true);
        }

        //Import a job and populate the tree.
        private void buttonOpen_Click(object sender, EventArgs e)
        {
            BuildFromPackage(false);
        }

        //Open the xml file. If import is true, do an import, i.e. don't bring in the job id. 
        //private void BuildFromXml(bool pImport)
        //{
        //    bool check = true;
        //    if (rootNode != null)
        //    {
        //        check = Common.ConfirmNewJob();
        //    }

        //    if (check)
        //    {

        //        XElement rootJobXml = Common.OpenXML();

        //        if (rootJobXml != null)
        //        {
        //            this.UseWaitCursor = true;
        //            treeJobList.BeginUpdate();

        //            //cleanup old event listeners
        //            if (rootNode != null)
        //            {
        //                Job oldJob = (Job)rootNode.Tag;
        //                oldJob.SendMessageEvent -= this.ForwardMessage;
        //            }

        //            Job rootJob = new Job();
        //            rootJob.SendMessageEvent += this.ForwardMessage;

        //            if (pImport)
        //            { rootJob.ImportXml(rootJobXml); }
        //            else
        //            { rootJob.OpenXml(rootJobXml); }
                    

        //            //create the new node and set it up. 
        //            rootNode = new TreeNode();
        //            rootNode.Tag = rootJob;
        //            rootNode.Name = rootJob.ID;
        //            rootNode.Text = rootJob.Name;

        //            treeJobList.Nodes.Clear();

        //            treeJobList.Nodes.Add(rootNode);

        //            //Close panel2 and Spin up the new form
        //            if (panel2 != null)
        //            { panel2.Close(); }

        //            panel2 = factory.Create(rootNode);
        //            ResetPanel2();

        //            treeJobList.SelectedNode = rootNode;

        //            this.PopulateTree(rootNode);
        //            treeJobList.ExpandAll();
        //            treeJobList.EndUpdate();
        //            this.UseWaitCursor = false;
        //        }
        //    }
        //}

        //Open the zip file. If import is true, do an import, i.e. don't bring in the job id. 
        private void BuildFromPackage(bool pImport)
        {
            bool check = true;
            if (rootNode != null)
            {
                check = CommonTasks.ConfirmNewJob();
            }

            if (check)
            {
                CommonTasks common = new CommonTasks();
                common.SendMessageEvent += this.ForwardMessage;

                if (this.jp != null) { this.jp.Cleanup(); }

                this.jp = common.OpenZip();
                Job rootJob = jp.Root;

                if (rootJob != null)
                {
                    this.UseWaitCursor = true;
                    treeJobList.BeginUpdate();

                    //cleanup old event listeners
                    if (rootNode != null)
                    {
                        Job oldJob = (Job)rootNode.Tag;
                        oldJob.SendMessageEvent -= this.ForwardMessage;
                    }

                    rootJob.SendMessageEvent += this.ForwardMessage;


                    //create the new node and set it up. 
                    rootNode = new TreeNode();
                    rootNode.Tag = rootJob;
                    rootNode.Name = rootJob.ID;
                    rootNode.Text = rootJob.Name;

                    treeJobList.Nodes.Clear();

                    treeJobList.Nodes.Add(rootNode);

                    //Close panel2 and Spin up the new form
                    if (panel2 != null)
                    { panel2.Close(); }

                    panel2 = factory.Create(rootNode);
                    ResetPanel2();

                    treeJobList.SelectedNode = rootNode;

                    this.PopulateTree(rootNode);
                    treeJobList.ExpandAll();
                    treeJobList.EndUpdate();
                    this.UseWaitCursor = false;
                }

                common.SendMessageEvent -= this.ForwardMessage;
            }
        }


        //Populate the tree with the steps for a job. 
        //Recursive method for sub jobs. 
        private void PopulateTree(TreeNode pRootNode)
        {
            Job rootJob;

            if (pRootNode.Tag is Job)
            { 
                rootJob = (Job)pRootNode.Tag; 
            }
            else { 
                Step sTemp = (Step)pRootNode.Tag;
                if ( sTemp.Task is Job )
                { 
                    rootJob = (Job)sTemp.Task; 
                }
                else 
                { 
                    throw new ArgumentException("Invalid node tag when populating tree");
                }
            }

            logger.Write("Populating tree for job: " + rootJob.Name, 0);

            foreach (Step s in rootJob)
            {
                if (s.Task == null) { throw new NullReferenceException("Empty task: " + s.TaskID); }
                TreeNode t = new TreeNode();
                t.Tag = s;
                t.Name = s.Task.ID;
                t.Text = s.Task.Name;

                logger.Write("Inserting node: " + t.Text, 0);

                pRootNode.Nodes.Add(t);

                if (s.Task is Job)
                { PopulateTree(t); }
            }
        }

        //Move a task up
        private void buttonUp_Click(object sender, EventArgs e)
        {
            TreeNode t = treeJobList.SelectedNode;
            TreeNode parentNode = t.Parent;
            Step s = (Step)t.Tag;
            int i = t.Index;

            //try to move the step up directly. Otherwise, we may need to use insert method to
            //move it to the parent job. 
            if (JobEditor.MoveUp(s))
            {
                //We move move this node up
                logger.Write("Step moved up", 0);
                parentNode.Nodes.Remove(t);
                parentNode.Nodes.Insert(i - 1,t);
                treeJobList.SelectedNode = t;
            }

            else
            {
                //We need to do an insert and go up a layer
                if (parentNode != rootNode)
                {
                    logger.Write("Step at top. Doing insert to move up tree", 0);
                    parentNode.Nodes.Remove(t);
                    parentNode.Parent.Nodes.Insert(parentNode.Index, t);
                    treeJobList.SelectedNode = t;

                    Step parentStep = (Step)parentNode.Tag;

                    JobEditor.Remove(s);
                    JobEditor.InsertAbove(s,parentStep);
                }
            }        
        }

        //Move a task down
        private void buttonDown_Click(object sender, EventArgs e)
        {
            TreeNode t = treeJobList.SelectedNode;
            TreeNode parentNode = t.Parent;
            Step s = (Step)t.Tag;
            int i = t.Index;

            //try to move the step down directly. Otherwise, we may need to use insert method to
            //move it to the parent job. 
            if (JobEditor.MoveDown(s))
            {
                //We move this node up
                parentNode.Nodes.Remove(t);
                parentNode.Nodes.Insert(i + 1, t);
                treeJobList.SelectedNode = t;
            }

            else
            {
                //We need to do an insert and go down a layer
                if (parentNode != rootNode)
                {
                    parentNode.Nodes.Remove(t);
                    parentNode.Parent.Nodes.Insert(parentNode.Index + 1, t);
                    treeJobList.SelectedNode = t;

                    Step parentStep = (Step)parentNode.Tag;

                    JobEditor.Remove(s);
                    JobEditor.InsertBelow(s, parentStep);
                }
            }   
        }



        //Drag and drop to move stuff around 
        private void treeJobList_DragDrop(object sender, DragEventArgs e)
        {
            // Ensure that the list item index is contained in the data.
            if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode",false))
            {
                TreeView tree = (TreeView)sender;
                //e.Effect = DragDropEffects.None;

                TreeNode sourceNode = (TreeNode)e.Data.GetData(typeof(TreeNode));

                //Don't allow move to the root node
                if ((sourceNode != rootNode) && (sourceNode != null))
                {
                    treeJobList.BeginUpdate();
                    Step sourceStep = (Step)sourceNode.Tag;

                    Point pt = new Point(e.X, e.Y);
                    pt = tree.PointToClient(pt);

                    TreeNode targetNode = tree.GetNodeAt(pt);

                    if ( targetNode !=  sourceNode )
                    {
                        if ((targetNode != null) && (targetNode != rootNode))
                        {
                            int sourceIndex = sourceNode.Index;
                            int targetIndex = targetNode.Index;

                            Step targetStep = (Step)targetNode.Tag;
                            e.Effect = DragDropEffects.Move;


                            //alter the behaviour depending on whether a sub job or task
                            if (targetStep.Task is Job)
                            {
                                logger.Write("Inserting step " + sourceNode.Text + " to root of job " + targetNode.Text, 0);
                                Job targetJob = (Job)targetStep.Task;
                                sourceNode.Parent.Nodes.Remove(sourceNode);
                                targetNode.Nodes.Insert(0, sourceNode);
                                treeJobList.SelectedNode = sourceNode;

                                JobEditor.Remove(sourceStep);
                                JobEditor.Insert(sourceStep, targetJob);
                            }

                            else if (targetStep.Task is ITask)
                            {
                                //first remove the step from the tree. 
                                JobEditor.Remove(sourceStep);

                                //now alter the behaviour depending on where the user is dropping to and from.
                                //this is complicated, but makes it more intuitive. 
                                
                                //For the Job/linked list, if the source was originally below the target in the view, 
                                //it needs to be inserted above the target in the job linked list. If it was above, it
                                //needs to be inserted below the target. 

                                TreeNode sourceEval = sourceNode;
                                TreeNode targetEval = targetNode;

                                //first get to the same level with the nodes. This makes sure we're not doing unnessecary checking.
                                //Break when the levels are the same.
                                while (true)
                                {
                                    if (sourceEval.Level == targetEval.Level) { break; }
                                    logger.Write("Level mismatch", 0);
                                    if (sourceEval.Level > targetEval.Level) { sourceEval = sourceEval.Parent; }
                                    else { targetEval = targetEval.Parent; }
                                }

                                //now traverse up until to find a common root to compare on. 
                                //this will tell let us figure out who is higher in the view. 
                                while (true)
                                {
                                    if (sourceEval.Parent == targetEval.Parent) { break; }
                                    targetEval = targetEval.Parent;
                                    sourceEval = sourceEval.Parent;
                                }

                                logger.Write("Source: " + sourceEval.Text + " Index: " + sourceEval.Index, 0);
                                logger.Write("Target: " + targetEval.Text + " Index: " + targetEval.Index, 0);

                                //now compare and insert. 
                                int shunt = 0; //if coming from above from another subnode tree, you need to shunt down one.

                                if (sourceEval.Index > targetEval.Index) //coming from below
                                {
                                    logger.Write("Inserting step " + sourceStep.Task.Name + " above " + targetStep.Task.Name, 0);
                                    if (JobEditor.InsertAbove(sourceStep, targetStep)) { logger.Write("Inserted step at root", 0); }

                                }
                                else //coming from above
                                {
                                    logger.Write("Inserting step " + sourceStep.Task.Name + " below " + targetStep.Task.Name, 0);
                                    JobEditor.InsertBelow(sourceStep, targetStep);

                                    //moving to another node tree, apply the shunt
                                    if (sourceNode.Parent != targetNode.Parent) 
                                    {
                                        logger.Write("Setting the shunt", 0);
                                        shunt = 1; 
                                    } 
                                }
                                //now move the tree nodes.
                                sourceNode.Parent.Nodes.Remove(sourceNode);
                                targetNode.Parent.Nodes.Insert(targetIndex + shunt, sourceNode);
                                treeJobList.SelectedNode = sourceNode;
                            }
                        }
                    }
                    treeJobList.EndUpdate();
                }             
            }
        }


        private void treeJobList_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void treeJobList_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void treeJobList_DragOver(object sender, DragEventArgs e)
        {
            // Get the tree.
            TreeView tree = (TreeView)sender;

            // Drag and drop denied by default.
            e.Effect = DragDropEffects.None;

            // Is it a valid format?
            if (e.Data.GetData(typeof(TreeNode)) != null)
            {
                // Get the screen point.
                Point pt = new Point(e.X, e.Y);

                // Convert to a point in the TreeView's coordinate system.
                pt = tree.PointToClient(pt);

                // Is the mouse over a valid node?
                TreeNode targetNode = tree.GetNodeAt(pt);
                if (targetNode != null)                     
                {
                    if (targetNode != rootNode)
                    {
                        e.Effect = DragDropEffects.Move;
                        tree.SelectedNode = targetNode;
                    }
                    else
                    {
                        e.Effect = DragDropEffects.None;
                    }
                    
                }
            }
        }

        //handle key shortcuts
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.S))
            {
                if (panel2 is ITaskForm)
                {
                    ITaskForm taskForm = (ITaskForm)panel2;
                    taskForm.Save();
                }

                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            TreeNode t = treeJobList.SelectedNode;
            this.DeleteNode(t);
        }


        private void DeleteNode(TreeNode t)
        {
            bool confirm = false;

            if (t != rootNode)
            {
                Step s = (Step)t.Tag;

                if (s.Task is Job)
                {
                    if (CommonTasks.ConfirmJobDelete(s))
                    {
                        confirm = true;
                    }
                }
                else
                {
                    if (CommonTasks.ConfirmStepDelete(s))
                    {
                        confirm = true; 
                    }
                }

                if (confirm) 
                {
                    if (panel2 != null) { panel2.Close(); }
                    t.Parent.Nodes.Remove(t);
                    JobEditor.Remove(s);
                    treeJobList.SelectedNode = null;
                }
            }
        }

        private void FormJobBuilder_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.jp != null) { this.jp.Cleanup(); }
        }
    }
}
