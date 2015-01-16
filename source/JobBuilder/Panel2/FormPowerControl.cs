//    FormPowerControl.cs: Windows form to configure a power control task object
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
using SystemLackey.Worker;

namespace SystemLackey.UI.Forms
{
    public partial class FormPowerControl : Form, ITaskForm
    {
        private PowerControl task;
        private TreeNode node;

        public FormPowerControl(PowerControl t, TreeNode n)
        {
            InitializeComponent();
            task = t;
            node = n;
            UpdateForm();
        }

        //save the powercontrol
        private void buttonSave_Click(object sender, EventArgs e)
        {
            this.Save();
        }

        public void UpdateForm()
        {
            textComments.Text = task.Comments;
            textName.Text = task.Name;
            labelJobGuid.Text = task.ID;

            numericUpDownWait.Value = task.Wait;

            if (task.PowerOption == 'r')
            {
                radioReboot.Checked = true;                
            }

            else if (task.PowerOption == 's')
            {
                radioShutdown.Checked = true;
            }

            else if (task.PowerOption == 'l')
            {
                radioLogoff.Checked = true;
            }

            Common.UpdateNode(node, task.Name);
        }

        public void Save()
        {
            if (Common.ConfirmTaskSave())
            {
                task.Comments = textComments.Text;
                task.Name = textName.Text;
                task.ID = labelJobGuid.Text;
                task.Wait = (int)numericUpDownWait.Value;

                if (radioReboot.Checked)
                {
                    task.PowerOption = 'r';
                }

                else if (radioShutdown.Checked)
                {
                    task.PowerOption = 's';
                }

                else if (radioLogoff.Checked)
                {
                    task.PowerOption = 'l';
                }

                Common.UpdateNode(node,task.Name);
            }
        }
    }
}
