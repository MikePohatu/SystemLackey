
using System;
using System.Windows.Forms;

namespace SystemLackey.UI.Forms
{
    class Common
    {
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

        public static void UpdateNode(TreeNode pNode, string pText)
        {
            if (pNode != null) { pNode.Text = pText; }
        }
          
    }
}
