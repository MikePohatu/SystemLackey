using System;
using System.Windows.Forms;
using SystemLackey.Worker;

namespace SystemLackey.JobBuilder
{
    class Form_Factory
    {
        public Form Create(Object o)
        {
            MessageBox.Show(o.ToString(), o.ToString());
            //job form
            if (o is Task_Job)
            {             
                return new Form_JobDetails((Task_Job)o); 
            }
            
            //WinScript form
            else if (o is Task_WinScript)
            { return new Form_WinTaskBuilder((Task_WinScript)o); }

            else { return null; }
        }
    }
}
