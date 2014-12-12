using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemLackey.Tasks
{
    interface ITask
    {
        public Int16 Run();

    }

    class Ps1Task : ITask
    {
        public Int16 Run()
        {
            return 0;
        }
    }

    class VbTask : ITask
    {
        public Int16 Run()
        {
            return 0;
        }
    }

    class CmdTask : ITask
    {
        public Int16 Run()
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C copy /b Image1.jpg + Archive.rar Image2.jpg";
            process.StartInfo = startInfo;
            process.Start();
            return 0;
        }
    }
}
