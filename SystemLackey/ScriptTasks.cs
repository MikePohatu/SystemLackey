using System;
using System.Diagnostics;
//using System.Text;
//using System.Threading.Tasks;

namespace SystemLackey.Tasks
{
    //Class for script tasks e.g. vbscript, powershell, batch.
    //In theory, the only things that will change will be the file extension of
    //the output script file, and the run function details
    public class Task_WinScript : ITask
    {
        private string strArguments;
        private string strExtn;
        private string strStartFile;

        public int Type;
        public int Timeout = 900; //The default timeout for the script
        public string ScriptFile;

        public bool Wow64 = false;
        public bool ASync = false;

        public string Code; //the actual code of the script
        public string strScriptPath = System.IO.Path.GetTempPath() + "SystemLackey";

        public string strTaskID = Guid.NewGuid().ToString();

        //Constructor parameters:
        // pTimeout = script timeout value
        // pCode = the actual script text
        // pSysWow = run in 32bit mode on a 64 bit OS
        public Task_WinScript(int pType, string pCode, bool pSysWow, int pTimeout)
        {
            System.IO.Directory.CreateDirectory(strScriptPath);
            Timeout = pTimeout;
            Code = pCode;
            SetType(pType,pSysWow);
        }

        //Constructor parameters:
        // pASync = run script asynchronously
        // pCode = the actual script text
        // pSysWow = run in 32bit mode on a 64 bit OS
        public Task_WinScript(int pType, string pCode, bool pSysWow, bool pASync)
        {
            System.IO.Directory.CreateDirectory(strScriptPath);
            ASync = pASync;
            Code = pCode;
            SetType(pType,pSysWow);
        }


        //Script type
        //0=cmd
        //1=vbs
        //2=ps1
        public void SetType(int pType,bool pSysWow)
        {
            switch (pType)
            {
                //batch script.
                case 0:
                    if (pSysWow)
                    {
                        strStartFile = Environment.GetFolderPath(Environment.SpecialFolder.SystemX86) + @"\cmd.exe";
                    }

                    else
                    {
                        strStartFile = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\cmd.exe";
                    }
                    strExtn = ".cmd";
                    
                    ScriptFile = strScriptPath + @"\" + strTaskID + strExtn;
                    strArguments = "/c " + ScriptFile;
                    break;

                //vbscript
                case 1:
                    strExtn = ".vbs";
                    if (pSysWow)
                    {
                        strStartFile = Environment.GetFolderPath(Environment.SpecialFolder.SystemX86) + @"\cscript.exe";
                    }

                    else
                    {
                        strStartFile = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\cscript.exe";
                    }
                    ScriptFile = strScriptPath + @"\" + strTaskID + strExtn;
                    strArguments = "/nologo " + ScriptFile;
                    break;

                //powershell
                case 2:
                    strExtn = ".ps1";
                    if (pSysWow)
                    {
                        strStartFile = Environment.GetFolderPath(Environment.SpecialFolder.SystemX86) + @"\WindowsPowerShell\v1.0\powershell.exe";
                    }

                    else
                    {
                        strStartFile = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\WindowsPowerShell\v1.0\powershell.exe";
                    }
                    ScriptFile = strScriptPath + @"\" + strTaskID + strExtn;
                    strArguments = "-executionpolicy bypass " + ScriptFile;
                    break;
                
                //invalid type. Throw exception
                default:
                    System.ArgumentException argEx = new System.ArgumentException("Invalid script type " + pType, "SetType");
                    break;
            }

            
        }


        //Write the script file 
        public bool WriteScriptFile()
        {
            bool bolSuccess = true;
            try
            {
                System.IO.File.WriteAllText(ScriptFile, Code);
            }
            catch
            {
                bolSuccess = false;
            }

            return bolSuccess;
        }


        //Run the script
        public int Run()
        {
            this.WriteScriptFile();
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
                process.WaitForExit(Timeout * 1000);
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
}
