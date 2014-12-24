using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SystemLackey.Worker;

namespace lackey_form_taskbuilder
{
    public partial class Form_JobDetails : Form
    {
        private Task_Job job = new Task_Job();  
        
        public Form_JobDetails(Task_Job pJob)
        {
            
            InitializeComponent();
            job = pJob;
            UpdateForm();
            
        }

        private void labelName_Click(object sender, EventArgs e)
        {

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            job.Comments = textComments.Text;
            job.Name = textName.Text;
            job.ID = labelJobGuid.Text;
        }

        private void textName_TextChanged(object sender, EventArgs e)
        {

        }

        private void UpdateForm()
        {
            textComments.Text = job.Comments;
            textName.Text = job.Name;
            labelJobGuid.Text = job.ID;
        }
    }
}
