using System;
using System.Xml;
using System.Xml.Linq;

namespace SystemLackey.Tasks.WindowsScripting
{
    public class Task_WinScript
    {
        public string Name = "";        //Name of the task
        public int Type = 0;            //0=cmd, 1=vbs, 2=ps1
        public int Timeout = 900;       //The timeout for the script
        
        public bool Wow64 = false;      //native processor architecture 
        public bool ASync = false;      //run synchronous
        public bool Hidden = true;

        public string Code = "";        //the actual code of the script
        public string TaskID;

        //Default constructor
        public Task_WinScript()
        {           
            TaskID = Guid.NewGuid().ToString();
        }

        //Constructor parameters:
        // pTimeout = script timeout value
        // pCode = the actual script text
        // pSysWow = run in 32bit mode on a 64 bit OS
        public Task_WinScript(string pName, int pType, string pCode, bool pSysWow, int pTimeout,bool pHidden)
        {
            Name = pName;
            Timeout = pTimeout;
            Code = pCode;
            Type = pType;
            Wow64 = pSysWow;
            TaskID = Guid.NewGuid().ToString();
            Hidden = pHidden;

        }

        //Constructor parameters:
        // pASync = run script asynchronously
        // pCode = the actual script text
        // pSysWow = run in 32bit mode on a 64 bit OS
        public Task_WinScript(string pName, int pType, string pCode, bool pSysWow, bool pASync, bool pHidden)
        {
            Name = pName;
            ASync = pASync;
            Code = pCode;
            Type = pType;
            Wow64 = pSysWow;
            TaskID = Guid.NewGuid().ToString();
            Hidden = pHidden;
        }

        //Constructor parameters: 
        // pTimeout = script timeout
        // pASync = run script asynchronously
        // pCode = the actual script text
        // pSysWow = run in 32bit mode on a 64 bit OS
        public Task_WinScript(string pName, int pType, string pCode, bool pSysWow, bool pASync, int pTimeout, bool pHidden)
        {
            Name = pName;
            Timeout = pTimeout;
            ASync = pASync;
            Code = pCode;
            Type = pType;
            Wow64 = pSysWow;
            TaskID = Guid.NewGuid().ToString();
            Hidden = pHidden;
        }

        public XElement GetXml()
        {
            XElement details = new XElement("Task",
                new XElement("Name",Name),
                new XElement("TaskID",TaskID),
                new XElement("ASync",ASync),
                new XElement("Timeout", Timeout),
                new XElement("Code",Code),
                new XElement("Type",Type),
                new XElement("Wow64",Wow64),
                new XElement("Hidden", Hidden));
            return details;
        }

        public void ImportXml(XElement pElement)
        {
            Name = pElement.Element("Name").Value;
            TaskID = pElement.Element("TaskID").Value;
            ASync = XmlConvert.ToBoolean(pElement.Element("ASync").Value);
            Timeout = XmlConvert.ToInt32(pElement.Element("Timeout").Value);
            Code = pElement.Element("Code").Value;
            Type =  XmlConvert.ToInt32(pElement.Element("Type").Value);
            Wow64 = XmlConvert.ToBoolean(pElement.Element("Wow64").Value);
            Hidden = XmlConvert.ToBoolean(pElement.Element("Hidden").Value);
        }

        //Run a Task_Winscript object
        public void Run()
        {
            string strScriptFile;
            string strArguments;
            string strExtn;
            string strStartFile;
            string strWorkingPath = SystemLackey.IO.IOConfiguration.WorkingPath;

            //make sure the working directory is there
            System.IO.Directory.CreateDirectory(strWorkingPath);

            //Figure out the correct scripting engine to use based on the type and SysWow64 setting i.e.
            //run code as 32bit on 64bit OS
            switch (this.Type)
            {
                //batch script.
                case 0:
                    if (this.Wow64)
                    {
                        strStartFile = Environment.GetFolderPath(Environment.SpecialFolder.SystemX86) + @"\cmd.exe";
                    }

                    else
                    {
                        strStartFile = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\cmd.exe";
                    }
                    strExtn = ".cmd";

                    strScriptFile = strWorkingPath + @"\" + this.TaskID + strExtn;
                    strArguments = "/c " + strScriptFile;
                    break;

                //vbscript
                case 1:
                    strExtn = ".vbs";
                    if (this.Wow64)
                    {
                        strStartFile = Environment.GetFolderPath(Environment.SpecialFolder.SystemX86) + @"\cscript.exe";
                    }

                    else
                    {
                        strStartFile = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\cscript.exe";
                    }
                    strScriptFile = strWorkingPath + @"\" + this.TaskID + strExtn;
                    strArguments = "/nologo " + strScriptFile;
                    break;

                //powershell
                case 2:
                    strExtn = ".ps1";
                    if (this.Wow64)
                    {
                        strStartFile = Environment.GetFolderPath(Environment.SpecialFolder.SystemX86) + @"\WindowsPowerShell\v1.0\powershell.exe";
                    }

                    else
                    {
                        strStartFile = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\WindowsPowerShell\v1.0\powershell.exe";
                    }
                    strScriptFile = strWorkingPath + @"\" + this.TaskID + strExtn;
                    strArguments = "-executionpolicy bypass " + strScriptFile;
                    break;

                //invalid type. Throw exception
                default:
                    System.ArgumentException argEx = new System.ArgumentException("Invalid script type " + this.Type, "SetType");
                    return;
            }

            //Now write the script file to the working directory
            WriteScript(strScriptFile, this.Code);

            //Now run the script
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();

            //Set if the script windows is hidden
            if (this.Hidden)
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
                process.WaitForExit(this.Timeout * 1000);
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
        private bool WriteScript(string pPath, string pCode)
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
