﻿//    CommonTasks.cs:    this class is used to provide common prompts for forms
//                  e.g. confirmation prompts, rather than having to redo it 
//                  for every form
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
using System.Windows.Forms;
using System.Xml.Linq;

using SystemLackey.Core;
using SystemLackey.Core.Messaging;
using SystemLackey.Core.Tasks;
using SystemLackey.Core.IO;

namespace SystemLackey.UI.Forms
{
    class CommonTasks : MessageForwarder
    {
        public static XElement OpenXML()
        {
            OpenFileDialog openBox = new OpenFileDialog();

            openBox.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
            openBox.FilterIndex = 1;
            //openBox.DereferenceLinks = false;

            if (openBox.ShowDialog() == DialogResult.OK)
            {
                System.IO.FileStream stream = (System.IO.FileStream)openBox.OpenFile();
                XmlHandler xmlHandler = new XmlHandler();

                XElement Xml = xmlHandler.Read(stream);
                stream.Close();
                return Xml;
            }
            else
            { return null; }
        }

        public static bool SaveXML(XElement pElement)
        {
            SaveFileDialog saveBox = new SaveFileDialog();

            saveBox.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
            saveBox.FilterIndex = 1;

            if (saveBox.ShowDialog() == DialogResult.OK)
            {
                System.IO.FileStream stream = (System.IO.FileStream)saveBox.OpenFile();
                XmlHandler xmlHandler = new XmlHandler();
                xmlHandler.Write(stream, pElement);
                stream.Close();
                return true;
            }
            else
            { return false; }
        }


        //Zip file save/export functions
        public static bool SaveZip(Job pJob)
        {
            return WriteZip(pJob, false);
        }

        public static bool ExportZip(Job pJob)
        {
            return WriteZip(pJob, true);
        }

        //main zip file write function
        //** export vs save functionality to be added
        private static bool WriteZip(Job pJob, bool pExport)
        {
            SaveFileDialog saveBox = new SaveFileDialog();

            saveBox.Filter = "Zip files (*.zip)|*.zip|All files (*.*)|*.*";
            saveBox.FilterIndex = 1;

            if (saveBox.ShowDialog() == DialogResult.OK)
            {
                JobPackage jp;

                string zipPath;
                using (System.IO.FileStream stream = (System.IO.FileStream)saveBox.OpenFile())
                {
                    zipPath = stream.Name;                   
                }

                jp = new JobPackage(pJob);

                jp.SendMessageEvent += pJob.ReceiveMessage;
                jp.Save(zipPath);
                jp.SendMessageEvent -= pJob.ReceiveMessage;
                return true;
            }
            else
            { return false; }
        }

        public JobPackage OpenZip()
        {
            return ReadZip(false);
        }

        public JobPackage ImportZip()
        {
            return ReadZip(true);
        }

        private JobPackage ReadZip(bool pImport)
        {
            OpenFileDialog openBox = new OpenFileDialog();

            openBox.Filter = "Zip files (*.zip)|*.zip|All files (*.*)|*.*";
            openBox.FilterIndex = 1;
            //openBox.DereferenceLinks = false;

            if (openBox.ShowDialog() == DialogResult.OK)
            {
                JobPackage jp;

                string zipPath;
                using (System.IO.FileStream stream = (System.IO.FileStream)openBox.OpenFile())
                {
                    zipPath = stream.Name;
                }

                jp = new JobPackage(zipPath);

                jp.SendMessageEvent += this.ForwardMessage;
                Job newJob = jp.Open();
                jp.SendMessageEvent -= this.ForwardMessage;

                return jp;

            }
            else
            { return null; }
        }

        public static bool ConfirmTaskSave()
        {
            if (MessageBox.Show("Are you sure you want to save this task?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            { return true; }
            else
            { return false; }
        }

        public static bool ConfirmJobSave()
        {
            if (MessageBox.Show("Are you sure you want to save this job?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            { return true; }
            else
            { return false; }
        }

        public static bool ConfirmNewJob()
        { 
            string message = "This will create a new root job, discarding any unsaved  changes" + Environment.NewLine + "Continue?";
            if (MessageBox.Show(message, "Confirmation", MessageBoxButtons.OKCancel) == DialogResult.OK)
            { return true; }
            else
            { return false; }

        }
        public static bool ConfirmJobRun()
        {
            if (MessageBox.Show("Are you sure you want to run this job?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            { return true; }
            else
            { return false; }
        }

        public static bool ConfirmStepDelete(Step pStep)
        {
            if (MessageBox.Show("Are you sure you want to delete the step " + pStep.Task.Name +"?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            { return true; }
            else
            { return false; }
        }

        public static bool ConfirmJobDelete(Step pStep)
        {
            if (MessageBox.Show("Are you sure you want to delete the step " + pStep.Task.Name + " and all sub steps?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            { return true; }
            else
            { return false; }
        }

        public static void UpdateNode(TreeNode pNode, string pText)
        {
            if (pNode != null) { pNode.Text = pText; }
        }
          
    }
}
