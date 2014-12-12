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

    public abstract class ScriptTask
    {
        public abstract string strScriptFile;
        public  bool bolWow64 = false;
        public abstract string strWinDir;
        public string strCode;
    }

    class Ps1Task : ScriptTask,ITask
    {
        public Int16 Run()
        {
            return 0;
        }
    }

    class VbTask : ScriptTask,ITask
    {
        public Int16 Run()
        {
            return 0;
        }
    }

    class CmdTask : ScriptTask,ITask
    {

        public Int16 Run()
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;

            //First get the right cmd.exe if running on 64 bit. 
            if (bolWow64)
            {
                startInfo.FileName = strWinDir + @"\syswow64\cmd.exe";
            }
            
            else
            {
                startInfo.FileName = strWinDir + @"\system32\cmd.exe";
            }
            startInfo.Arguments = "/C " + strScriptFile;
            process.StartInfo = startInfo;
            process.WaitForExit(3600000);
            process.Start();
            return 0;
        }
    }
}
