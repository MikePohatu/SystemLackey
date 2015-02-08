//    FormJobDetails.cs: Windows form to configure settings for a Job object
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
using SystemLackey.Tasks;

namespace SystemLackey.UI.Forms
{
    public partial class FormJobDetails : MessagingForm, ITaskForm
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
            Save();            
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

        public void Save()
        {
            if (Common.ConfirmJobSave())
            {
                job.Comments = textComments.Text;
                job.Name = textName.Text;
                job.ID = labelJobGuid.Text;
                UpdateNode();
            }
        }
    }
}
