﻿using System;
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

namespace lackey_form_taskbuilder
{
    public partial class formTaskBuilder : Form
    {
        public formTaskBuilder()
        {
            InitializeComponent();
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
                //if ((myStream = saveFileDialog1.OpenFile()) != null)
                //{
                    // Code to write the stream goes here.
                 //   myStream.Close();
                //}

                SystemLackey.IO.XmlHandler xmlHandler = new SystemLackey.IO.XmlHandler();
                handler.Write(, task.GetXml());
            
            }
        }

        private void numericTimeout_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
