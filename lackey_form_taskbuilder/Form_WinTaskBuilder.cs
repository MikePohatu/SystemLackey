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

using SystemLackey.IO;
using SystemLackey.Worker;

namespace lackey_form_taskbuilder
{
    public partial class formWinTaskBuilder : Form
    {
        public Task_WinScript task;
 
        public formWinTaskBuilder()
        {
            InitializeComponent();
            task = new Task_WinScript();
            UpdateForm();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {

        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            UpdateTask();
            SaveFileDialog saveBox = new SaveFileDialog();

            saveBox.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
            saveBox.FilterIndex = 1;
            //saveBox.FileName = 
            //saveBox.RestoreDirectory = true;

            if (saveBox.ShowDialog() == DialogResult.OK)
            {
                System.IO.FileStream stream = (System.IO.FileStream)saveBox.OpenFile();
                SystemLackey.IO.XmlHandler xmlHandler = new SystemLackey.IO.XmlHandler();
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
                SystemLackey.IO.XmlHandler xmlHandler = new SystemLackey.IO.XmlHandler();
                
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


        //=============================================================
        // Radio buttons for script type
        //=============================================================

        private void radioCmd_CheckedChanged(object sender, EventArgs e)
        {
            if (radioCmd.Checked)
            {
                task.Type = 0;
            }
        }

        private void radioPs1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioPs1.Checked)
            {
                task.Type = 2;
            }
        }

        private void radioVbs_CheckedChanged(object sender, EventArgs e)
        {
            if (radioVbs.Checked)
            {
                task.Type = 1;
            }
        }

        //=============================================================

        private void formTaskBuilder_Load(object sender, EventArgs e)
        {

        }

        private void checkSysWow64_CheckedChanged(object sender, EventArgs e)
        {
            task.Wow64 = checkSysWow64.Checked;
        }

        private void textCode_TextChanged(object sender, EventArgs e)
        {

        }

        private void UpdateTask()
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
            task.Comments = richComments.Text;


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
            richComments.Text = task.Comments;

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

        private void buttonTest_Click(object sender, EventArgs e)
        {

        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to run this task?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                UpdateTask();
                task.Run();
            }
            
        }

        private void labelTaskID_Click(object sender, EventArgs e)
        {

        }

        private void textCode_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textName_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelTimeout_Click(object sender, EventArgs e)
        {

        }
    }
}
