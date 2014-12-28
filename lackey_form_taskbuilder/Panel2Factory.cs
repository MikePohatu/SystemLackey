using System;
using System.Windows.Forms;
using SystemLackey.Worker;

namespace SystemLackey.UI.Forms
{
    class Panel2Factory
    {
        public Form Create(TreeNode n)
        {
            Object o = n.Tag;
            //MessageBox.Show(o.ToString(), o.ToString());
            //job form
            if (o is Job)
            { 
                return new FormJobDetails((Job)o,n);
            }
            
            else
            {
                Step s = (Step)o;
                ITask task = s.Task;
                //WinScript form
                if (s.Task is WindowsScript)
                {
                    return new FormWinTaskBuilder((WindowsScript)task, n);
                }

                //Power control form
                else if (s.Task is PowerControl)
                {
                    return new FormPowerControl((PowerControl)task, n);
                }

                //Subjob form
                else if (s.Task is Job)
                {
                    return new FormJobDetails((Job)task, n);
                }

                //Unknown type
                else { return null; }
            }
        }
    }
}
