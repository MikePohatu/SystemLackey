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
    public partial class FormJobDetails : Form
    {
        private Job job = new Job(); 
        private TreeNode node;
        
        public FormJobDetails(Job pJob, TreeNode pNode)
        {         
            InitializeComponent();
            job = pJob;
            node = pNode;
            UpdateForm();
        }

        //save the job
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (Common.ConfirmJobSave())
            {
                job.Comments = textComments.Text;
                job.Name = textName.Text;
                job.ID = labelJobGuid.Text;
                UpdateNode();
            }
            
        }

        public void UpdateForm()
        {
            textComments.Text = job.Comments;
            textName.Text = job.Name;
            labelJobGuid.Text = job.ID;
            UpdateNode();
        }

        private void UpdateNode()
        {
            if (node != null) { node.Text = job.Name; }
        }
    }
}
