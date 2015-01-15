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
