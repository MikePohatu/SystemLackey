using System;
using System.Diagnostics;
//using System.Text;
//using System.Threading.Tasks;

namespace SystemLackey.Tasks
{

    //Parent class for script tasks e.g. vbscript, powershell, batch.
    //In theory, the only things that will change will be the file extension of
    //the output script file, and the run function
    public abstract class ScriptTask : ITask
    {
        public string strScriptFile;
        public string strStartFile;
        public string strArguments;

        public bool bolWow64 = false;
        public bool bolASync = false;

        public string strCode;
        public string strScriptPath = System.IO.Path.GetTempPath() + "SystemLackey";
        public int intTimeout = 900; //The default timeout for the script
        public string strTaskID = Guid.NewGuid().ToString();

        //Constructor parameters:
        // pTimeout = script timeout value
        // pCode = the actual script text
        // pSysWow = run in 32bit mode on a 64 bit OS
        public ScriptTask (string pCode, bool pSysWow,int pTimeout)
        {
            bolWow64 = pSysWow;
            intTimeout = pTimeout;
            strCode = pCode;

            strScriptFile = strScriptPath + @"\" + strTaskID;
            CheckPath();
            this.Init();
        }

        //Constructor parameters:
        // pASync = run script asynchronously
        // pCode = the actual script text
        // pSysWow = run in 32bit mode on a 64 bit OS
        public ScriptTask(string pCode, bool pSysWow, bool pASync)
        {
            bolWow64 = pSysWow;
            bolASync = pASync;
            strCode = pCode;

            strScriptFile = strScriptPath + @"\" + strTaskID;
            CheckPath();
            this.Init();
        }

        //initialise the object. Sets up the script type
        abstract protected void Init();

        //Write the script file 
        public bool WriteScriptFile()
        {
            bool bolSuccess = true;
            try
            {
                System.IO.File.WriteAllText(strScriptFile, strCode);
            }
            catch
            {
                bolSuccess = false;
            }

            return bolSuccess;
        }


        //Check for the folder for the script 
        public void CheckPath()
        {
            if (!(System.IO.Directory.Exists(strScriptPath)))
            {
                System.IO.Directory.CreateDirectory(strScriptPath);
            }
        }

        //Run the script
        public int Run()
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            //startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;

            startInfo.FileName = strStartFile;
            startInfo.Arguments = strArguments;
            
            process.StartInfo = startInfo;

            //try to run the process script. return the scripts return code or 99999 if it times out.
            try
            {
                process.Start();
                process.WaitForExit(intTimeout * 1000);
                int intReturn = process.ExitCode;
                return intReturn;
            }

            catch
            {
                //timeout reached
                return 99999;
            }
        }


    }

    public class Ps1Task : ScriptTask
    {
        public Ps1Task(string pCode, bool pSysWow, int pTimeOut) : base(pCode, pSysWow, pTimeOut)
        {
        }

        public Ps1Task(string pCode, bool pSysWow, bool pASync) : base(pCode, pSysWow, pASync)
        {
        }

        protected override void Init()
        {
            //Set the file extension
            strScriptFile = strScriptFile + ".ps1";
            strArguments = "-executionpolicy bypass " + strScriptFile;

            //Get the right cmd.exe if running on 64 bit. 
            if (bolWow64)
            {
                strStartFile = Environment.GetFolderPath(Environment.SpecialFolder.Windows) + @"\syswow64\WindowsPowerShell\v1.0\powershell.exe";
            }

            else
            {
                strStartFile = Environment.GetFolderPath(Environment.SpecialFolder.Windows) + @"\system32\WindowsPowerShell\v1.0\powershell.exe";
            }
        }
    }

    public class VbTask : ScriptTask
    {
        public VbTask(string pCode, bool pSysWow, int pTimeOut) : base(pCode, pSysWow, pTimeOut)
        {
        }

        public VbTask(string pCode, bool pSysWow, bool pASync) : base(pCode, pSysWow, pASync)
        {
        }

        protected override void Init()
        {
            //Set the file extension
            strScriptFile = strScriptFile + ".vbs";
            strArguments = "/nologo " + strScriptFile;

            //Get the right cmd.exe if running on 64 bit. 
            if (bolWow64)
            {
                strStartFile = Environment.GetFolderPath(Environment.SpecialFolder.Windows) + @"\syswow64\cscript.exe";
            }

            else
            {
                strStartFile = Environment.GetFolderPath(Environment.SpecialFolder.Windows) + @"\system32\cscript.exe";
            }
        }
    }

    public class CmdTask : ScriptTask
    {
        public CmdTask(string pCode, bool pSysWow, int pTimeOut) : base(pCode, pSysWow, pTimeOut)
        {
        }

        public CmdTask(string pCode, bool pSysWow, bool pASync) : base(pCode, pSysWow, pASync)
        {
        }

        protected override void Init()
        {
            //Set the file extension
            strScriptFile = strScriptFile + ".cmd";
            strArguments = "/c " + strScriptFile;

            //Get the right cmd.exe if running on 64 bit. 
            if (bolWow64)
            {
               strStartFile = Environment.GetFolderPath(Environment.SpecialFolder.Windows) + @"\syswow64\cmd.exe";
            }

            else
            {
                strStartFile =  Environment.GetFolderPath(Environment.SpecialFolder.Windows) + @"\system32\cmd.exe";
            }
        }
    }
}
