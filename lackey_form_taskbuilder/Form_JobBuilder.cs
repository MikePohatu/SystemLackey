using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SystemLackey.IO;
using SystemLackey.Tasks;
using SystemLackey.Tasks.WindowsScripting;

namespace lackey_form_taskbuilder
{
    public partial class formTaskBuilder : Form
    {
        public Task_WinScript task;
 
        public formTaskBuilder()
        {
            InitializeComponent();
            task = new Task_WinScript();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void radioCmd_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
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

        private void numericTimeout_ValueChanged(object sender, EventArgs e)
        {

        }

        private void buttonSave_Click_1(object sender, EventArgs e)
        {

        }
    }
}
