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
        int Run();
    }

    public abstract class ScriptTask
    {
        public string strScriptFile;
        public bool bolWow64 = false;
        public bool bolASync = false;
        public string strWinDir;
        public string strCode;
        public int intTimeout = 900000; //The default timeout for the script

        //Constructor parameters:
        // pTimeout = script timeout value
        // pCode = the actual script text
        // pSysWow = run in 32bit mode on a 64 bit OS
        public ScriptTask (int pTimeout, string pCode, bool pSysWow)
        {
            bolWow64 = pSysWow;
            intTimeout = pTimeout;
            strCode = pCode;
        }

        //Constructor parameters:
        // pASync = run script asynchronously
        // pCode = the actual script text
        // pSysWow = run in 32bit mode on a 64 bit OS
        public ScriptTask(bool pASync, string pCode, bool pSysWow)
        {
            bolWow64 = pSysWow;
            bolASync = pASync;
            strCode = pCode;
        }
    }

    public class Ps1Task : ScriptTask,ITask
    {
        public Ps1Task (int pTimeOut, string pCode, bool pSysWow) : base (pTimeOut, pCode, pSysWow)
        { }

        public Ps1Task(bool pASync, string pCode, bool pSysWow) : base (pASync, pCode, pSysWow)
        { }

        public int Run()
        {
            return 0;
        }
    }

    public class VbTask : ScriptTask,ITask
    {
        public VbTask (int pTimeOut, string pCode, bool pSysWow) : base (pTimeOut, pCode, pSysWow)
        { }

        public VbTask (bool pASync, string pCode, bool pSysWow) : base (pASync, pCode, pSysWow)
        { }

        public int Run()
        {
            return 0;
        }
    }

    public class CmdTask : ScriptTask,ITask
    {
        public CmdTask (int pTimeOut, string pCode, bool pSysWow) : base (pTimeOut, pCode, pSysWow)
        { }

        public CmdTask (bool pASync, string pCode, bool pSysWow) : base (pASync, pCode, pSysWow)
        { }
        
        public int Run()
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            //startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;

            //First get the right cmd.exe if running on 64 bit. 
            if (bolWow64)
            {
                startInfo.FileName = strWinDir + @"\syswow64\cmd.exe";
            }
            
            else
            {
                startInfo.FileName = strWinDir + @"\system32\cmd.exe";
            }
            startInfo.Arguments = "/C " + strCode;
            process.StartInfo = startInfo;
            
            process.Start();
            process.WaitForExit(intTimeout);
            int intReturn = process.ExitCode;
            return intReturn;
        }
    }
}
