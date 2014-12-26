﻿using System;
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
            if (o is Task_Job)
            { 
                return new Form_JobDetails((Task_Job)o,n);
            }
            
            //WinScript form
            else if (o is Task_WinScript)
            {
                return new Form_WinTaskBuilder((Task_WinScript)o, n);
            }

            else { return null; }
        }
    }
}