using System;
using System.Windows.Forms;
using SystemLackey.Worker;

namespace SystemLackey.UI.Forms
{
    class Panel2Factory
    {
        public Form Create(Object o, TreeNode n)
        {
            //MessageBox.Show(o.ToString(), o.ToString());
            //job form
            if (o is Job)
            { 
                return new FormJobDetails((Job)o,n);
            }
            
            //WinScript form
            else if (o is WindowsScript)
            {
                return new FormWinTaskBuilder((WindowsScript)o, n);
            }

            //Power control form
            else if (o is PowerControl)
            {
                return new FormPowerControl((PowerControl)o, n);
            }
            else { return null; }
        }
    }
}
