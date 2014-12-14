using System;
using System.Diagnostics;
using SystemLackey.Tasks.WindowsScripting;
//using System.Text;
//using System.Threading.Tasks;

namespace SystemLackey.Tasks
{
    //Class for script tasks e.g. vbscript, powershell, batch.
    //In theory, the only things that will change will be the file extension of
    //the output script file, and the run function details
    public class Task_WinTaskWorker
    {
        public string strWorkingPath = SystemLackey.IO.IOConfiguration.WorkingPath;

        //Constructor parameters:
        // pTimeout = script timeout value
        // pCode = the actual script text
        // pSysWow = run in 32bit mode on a 64 bit OS
        public Task_WinTaskWorker()
        {
            System.IO.Directory.CreateDirectory(strWorkingPath);
        }

        //Run a Task_Winscript object
        public void Run(Task_WinScript pTask)
        {
            string strScriptFile;
            string strArguments;
            string strExtn;
            string strStartFile;

            //Figure out the correct scripting engine to use based on the type and SysWow64 setting i.e.
            //run code as 32bit on 64bit OS
            switch (pTask.Type)
            {
                //batch script.
                case 0:
                    if (pTask.Wow64)
                    {
                        strStartFile = Environment.GetFolderPath(Environment.SpecialFolder.SystemX86) + @"\cmd.exe";
                    }

                    else
                    {
                        strStartFile = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\cmd.exe";
                    }
                    strExtn = ".cmd";

                    strScriptFile = strWorkingPath + @"\" + pTask.TaskID + strExtn;
                    strArguments = "/c " + strScriptFile;
                    break;

                //vbscript
                case 1:
                    strExtn = ".vbs";
                    if (pTask.Wow64)
                    {
                        strStartFile = Environment.GetFolderPath(Environment.SpecialFolder.SystemX86) + @"\cscript.exe";
                    }

                    else
                    {
                        strStartFile = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\cscript.exe";
                    }
                    strScriptFile = strWorkingPath + @"\" + pTask.TaskID + strExtn;
                    strArguments = "/nologo " + strScriptFile;
                    break;

                //powershell
                case 2:
                    strExtn = ".ps1";
                    if (pTask.Wow64)
                    {
                        strStartFile = Environment.GetFolderPath(Environment.SpecialFolder.SystemX86) + @"\WindowsPowerShell\v1.0\powershell.exe";
                    }

                    else
                    {
                        strStartFile = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\WindowsPowerShell\v1.0\powershell.exe";
                    }
                    strScriptFile = strWorkingPath + @"\" + pTask.TaskID + strExtn;
                    strArguments = "-executionpolicy bypass " + strScriptFile;
                    break;
                
                //invalid type. Throw exception
                default:
                    System.ArgumentException argEx = new System.ArgumentException("Invalid script type " + pTask.Type, "SetType");
                    return;
            }

            //Now write the script file to the working directory
            WriteWinScriptFile(strScriptFile,pTask.Code);
            
            //Now run the script
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            
            //Set if the script windows is hidden
            if (pTask.Hidden)
            {
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            }

            startInfo.FileName = strStartFile;
            startInfo.Arguments = strArguments;

            process.StartInfo = startInfo;

            //try to run the process script. return the scripts return code or 99999 if it times out.
            try
            {
                process.Start();
                process.WaitForExit(pTask.Timeout * 1000);
                int intReturn = process.ExitCode;
                //return intReturn;
            }

            catch
            {
                //timeout reached
                //return 99999;
            }
        }


        //Write a script file 
        public bool WriteWinScriptFile(string pPath, string pCode)
        {
            bool bolSuccess = true;
            try
            {
                System.IO.File.WriteAllText(pPath, pCode);
            }
            catch
            {
                bolSuccess = false;
            }

            return bolSuccess;
        }
    }
}
