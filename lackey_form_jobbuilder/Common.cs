
using System;
using System.Windows.Forms;
using System.Xml.Linq;

using SystemLackey.Logging;
using SystemLackey.Worker;

namespace SystemLackey.UI.Forms
{
    class Common
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
                SystemLackey.IO.XmlHandler xmlHandler = new SystemLackey.IO.XmlHandler();

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
                SystemLackey.IO.XmlHandler xmlHandler = new SystemLackey.IO.XmlHandler();
                xmlHandler.Write(stream, pElement);
                stream.Close();
                return true;
            }
            else
            { return false; }
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
