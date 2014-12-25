using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SystemLackey.Worker;

namespace SystemLackey.JobBuilder
{
    public partial class Form_JobDetails : Form
    {
        private Task_Job job = new Task_Job(); 
        private TreeNode node;
        
        public Form_JobDetails(Task_Job pJob, TreeNode pNode)
        {         
            InitializeComponent();
            job = pJob;
            node = pNode;
            UpdateForm();
        }

        //save the job
        private void buttonSave_Click(object sender, EventArgs e)
        {
            job.Comments = textComments.Text;
            job.Name = textName.Text;
            job.ID = labelJobGuid.Text;
            UpdateNode();
        }

        public void UpdateForm()
        {
            textComments.Text = job.Comments;
            textName.Text = job.Name;
            labelJobGuid.Text = job.ID;
            UpdateNode();
            
            //this.MdiParent.
        }

        private void UpdateNode()
        {
            if (node != null) { node.Text = job.Name; }
        }
    }
}
