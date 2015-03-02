//    FormWindowsScriptTaskControl.cs: Windows form to configure a WindowsScript task object
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
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

using SystemLackey.Core.Tasks;
using SystemLackey.Core.IO;

namespace SystemLackey.UI.Forms
{
    public partial class FormWindowsScriptTaskControl : MessagingForm, ITaskForm
    {
        private WindowsScript task;
        private TreeNode node;

        public FormWindowsScriptTaskControl()
        {
            InitializeComponent();
            task = new WindowsScript();
            UpdateForm();
        }

        public FormWindowsScriptTaskControl(WindowsScript t,TreeNode n)
        {
            InitializeComponent();
            task = t;
            node = n;
            UpdateForm();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            this.Save();            
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            this.Save();
            SaveFileDialog saveBox = new SaveFileDialog();

            saveBox.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
            saveBox.FilterIndex = 1;
            //saveBox.FileName = 
            //saveBox.RestoreDirectory = true;

            if (saveBox.ShowDialog() == DialogResult.OK)
            {
                System.IO.FileStream stream = (System.IO.FileStream)saveBox.OpenFile();
                XmlHandler xmlHandler = new XmlHandler();
                xmlHandler.Write(stream, task.GetXml());
                stream.Close();

            }
        }

        private void buttonImport_Click(object sender, EventArgs e)
        {

            OpenFileDialog openBox = new OpenFileDialog();

            openBox.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
            openBox.FilterIndex = 1;
            //saveBox.FileName = 
            //saveBox.RestoreDirectory = true;

            if (openBox.ShowDialog() == DialogResult.OK)
            {
                System.IO.FileStream stream = (System.IO.FileStream)openBox.OpenFile();
                XmlHandler xmlHandler = new XmlHandler();
                
                task.ImportXml(xmlHandler.Read(stream));
                stream.Close();
            }
            //now update the view
            UpdateForm();
        }

        //set the timeout
        private void numericTimeout_ValueChanged(object sender, EventArgs e)
        {
            task.Timeout = (int)numericTimeout.Value;
        }

        private void formTaskBuilder_Load(object sender, EventArgs e)
        {

        }

        public void Save()
        {
            if (CommonTasks.ConfirmTaskSave())
            {
                string codeString = "";
                string[] lines = textCode.Lines;

                // Loop through the array and send the contents to a string 
                for (int counter = 0; counter < lines.Length; counter++)
                {
                    codeString = codeString + lines[counter] + System.Environment.NewLine;
                }

                task.Name = textName.Text;
                task.Code = codeString;
                task.Hidden = checkHidden.Checked;
                task.Wow64 = checkSysWow64.Checked;
                task.ASync = checkASync.Checked;
                task.Timeout = (int)numericTimeout.Value;
                task.Comments = richtextComments.Text;


                if (radioCmd.Checked)
                {
                    task.Type = 0;
                }

                else if (radioVbs.Checked)
                {
                    task.Type = 1;
                }

                else if (radioPs1.Checked)
                {
                    task.Type = 2;
                }

                CommonTasks.UpdateNode(node, task.Name);
            }
        }

        //Update the form with the values of the current task. 
        private void UpdateForm()
        {
            int count = 0;
            string line;
            string codeText = "";

            //task.Code = codeString;
            StringReader reader = new StringReader(task.Code);

            do
            {
                line = reader.ReadLine();
                if (line != null)
                {
                    codeText = codeText + line + Environment.NewLine;
                    count++;
                } 
                
                else
                {
                    break;
                }
                
            } while (true);

            textCode.Text = codeText;
            checkHidden.Checked = task.Hidden;
            checkSysWow64.Checked = task.Wow64;
            checkASync.Checked = task.ASync;
            numericTimeout.Value = task.Timeout;
            labelTaskIDValue.Text = task.ID;
            textName.Text = task.Name;
            richtextComments.Text = task.Comments;

            if (this.task.ContentPack != null) { linkLabelContentPack.Text = "Edit"; }
            else { linkLabelContentPack.Text = "Empty"; }

            CommonTasks.UpdateNode(node, task.Name);

            switch (task.Type)
            {
                case 0:
                    radioCmd.Checked = true;
                    break;
                case 1:
                    radioVbs.Checked = true;
                    break;
                case 2:
                    radioPs1.Checked = true;
                    break;
                //invalid type. Throw exception
                default:
                    System.ArgumentException argEx = new System.ArgumentException("Invalid script type " + task.Type, "SetType");
                    return;
            }
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to run this task?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Save();
                task.Run();
            }
        }

        private void checkTestAllowed_CheckedChanged(object sender, EventArgs e)
        {
            if (checkTestAllowed.Checked)
            { 
                buttonTestRun.Enabled = true;
                //buttonRun.Visible = true;
            }

            else
            { 
                buttonTestRun.Enabled = false;
                //buttonRun.Visible = false;
            }
        }

        private void linkLabelContentPack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ContentPack cp;
            if (this.task.ContentPack == null) { cp = new ContentPack(this.task); }
            else { cp = this.task.ContentPack; }

            Process.Start(cp.StartEdit());
            if (MessageBox.Show("Edit files and folders as required and click OK when done.", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            { 
                cp.FinishedEdit();
                this.task.ContentPack = cp;
            }
            else
            { 
                cp.CancelEdit();
                if (this.task.ContentPack == null) { cp.Cleanup(); }
            }

            UpdateForm();
        }
    }
}
