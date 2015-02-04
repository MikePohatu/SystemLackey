//    WindowsScript.cs: Windows scriting task class
//    Copyright (C) 2015 Mike Pohatu

//    This program is free software; you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation; version 2 of the License.

//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU General Public License for more details.

//    You should have received a copy of the GNU General Public License along
//    with this program; if not, write to the Free Software Foundation, Inc.,
//    51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.

using System;
using System.Xml;
using System.Xml.Linq;
using SystemLackey.Messaging;

namespace SystemLackey.Worker
{
    public class WindowsScript : MessageSender, ITask, IMessageSender
    {
        private string name = "";        //Name of the task
        private int type = 0;            //0=cmd, 1=vbs, 2=ps1
        private int timeout = 900;       //The timeout for the script

        private bool wow64 = false;      //native processor architecture 
        private bool async = false;      //run synchronous
        private bool hidden = true;

        private string code = "";        //the actual code of the script
        private string taskid;
        private string comments = "";

        //Default constructor
        public WindowsScript()
        {           
            taskid = Guid.NewGuid().ToString();
        }

        //Constructor parameters:
        // pTimeout = script timeout value
        // pCode = the actual script text
        // pSysWow = run in 32bit mode on a 64 bit OS
        public WindowsScript(string pName, int pType, string pCode, bool pSysWow, int pTimeout,bool pHidden)
        {
            name = pName;
            timeout = pTimeout;
            code = pCode;
            type = pType;
            wow64 = pSysWow;
            taskid = Guid.NewGuid().ToString();
            hidden = pHidden;

        }

        //Constructor parameters:
        // pASync = run script asynchronously
        // pCode = the actual script text
        // pSysWow = run in 32bit mode on a 64 bit OS
        public WindowsScript(string pName, int pType, string pCode, bool pSysWow, bool pASync, bool pHidden)
        {
            name = pName;
            async = pASync;
            code = pCode;
            type = pType;
            wow64 = pSysWow;
            taskid = Guid.NewGuid().ToString();
            hidden = pHidden;
        }

        //Constructor parameters: 
        // pTimeout = script timeout
        // pASync = run script asynchronously
        // pCode = the actual script text
        // pSysWow = run in 32bit mode on a 64 bit OS
        public WindowsScript(string pName, int pType, string pCode, bool pSysWow, bool pASync, int pTimeout, bool pHidden)
        {
            name = pName;
            timeout = pTimeout;
            async = pASync;
            code = pCode;
            type = pType;
            wow64 = pSysWow;
            taskid = Guid.NewGuid().ToString();
            hidden = pHidden;
        }


        //========================
        //Properties
        //========================

        public string Name
        {
            get  {return this.name;}
            set {this.name = value;}
        }

        public int Timeout
        {
            get { return this.timeout; }
            set { this.timeout = value; }
        }

        public bool ASync
        {
            get { return this.async; }
            set { this.async = value; }
        }

        public string Code
        {
            get { return this.code; }
            set { this.code = value; }
        }

        public bool Wow64
        {
            get { return this.wow64; }
            set { this.wow64 = value; }
        }

        public string ID
        {
            get { return this.taskid; }
            set { this.taskid = value; }
        }

        public bool Hidden
        {
            get { return this.hidden; }
            set { this.hidden = value; }
        }

        public int Type
        {
            get { return this.type; }
            set { this.type = value; }
        }

        public string Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }
        //=====================================
        // /Properties
        //=====================================


        //get the xml representation of the task
        public XElement GetXml()
        {
            XElement details = new XElement("Task",
                new XElement("name",name),
                new XElement("taskid",taskid),
                new XElement("async",async),
                new XElement("timeout", timeout),
                new XElement("code",code),
                new XElement("type",type),
                new XElement("wow64",wow64),
                new XElement("hidden", hidden),
                new XElement("comments", comments));

            details.SetAttributeValue("Type", "WinScript");
            return details;
        }
        private void BuildFromXml(XElement pElement,bool pImport)
        {
            name = pElement.Element("name").Value;          
            async = XmlConvert.ToBoolean(pElement.Element("async").Value);
            timeout = XmlConvert.ToInt32(pElement.Element("timeout").Value);
            code = pElement.Element("code").Value;
            type = XmlConvert.ToInt32(pElement.Element("type").Value);
            wow64 = XmlConvert.ToBoolean(pElement.Element("wow64").Value);
            hidden = XmlConvert.ToBoolean(pElement.Element("hidden").Value);
            comments = pElement.Element("comments").Value;
            if (pImport == false) { taskid = pElement.Element("taskid").Value; }
        }

        public void ImportXml(XElement pElement)
        {
            this.BuildFromXml(pElement,true);
        }

        public void OpenXml(XElement pElement)
        {
            this.BuildFromXml(pElement, false);
        }

        //Run a Task_Winscript object
        public int Run()
        {
            int state = 0;
            string strScriptFile;
            string strArguments;
            string strExtn;
            string strStartFile;
            string strWorkingPath = SystemLackey.IO.IOConfiguration.WorkingPath;

            //make sure the working directory is there
            System.IO.Directory.CreateDirectory(strWorkingPath);

            //Figure out the correct scripting engine to use based on the type and SysWow64 setting i.e.
            //run code as 32bit on 64bit OS
            switch (this.type)
            {
                //batch script.
                case 0:
                    if (this.wow64)
                    {
                        strStartFile = Environment.GetFolderPath(Environment.SpecialFolder.SystemX86) + @"\cmd.exe";
                    }

                    else
                    {
                        strStartFile = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\cmd.exe";
                    }
                    strExtn = ".cmd";

                    strScriptFile = strWorkingPath + @"\" + this.taskid + strExtn;
                    strArguments = "/c " + strScriptFile;
                    break;

                //vbscript
                case 1:
                    strExtn = ".vbs";
                    if (this.wow64)
                    {
                        strStartFile = Environment.GetFolderPath(Environment.SpecialFolder.SystemX86) + @"\cscript.exe";
                    }

                    else
                    {
                        strStartFile = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\cscript.exe";
                    }
                    strScriptFile = strWorkingPath + @"\" + this.taskid + strExtn;
                    strArguments = "/nologo " + strScriptFile;
                    break;

                //powershell
                case 2:
                    strExtn = ".ps1";
                    if (this.wow64)
                    {
                        strStartFile = Environment.GetFolderPath(Environment.SpecialFolder.SystemX86) + @"\WindowsPowerShell\v1.0\powershell.exe";
                    }

                    else
                    {
                        strStartFile = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\WindowsPowerShell\v1.0\powershell.exe";
                    }
                    strScriptFile = strWorkingPath + @"\" + this.taskid + strExtn;
                    strArguments = "-executionpolicy bypass " + strScriptFile;
                    break;

                //invalid type. Throw exception
                default:
                    System.ArgumentException argEx = new System.ArgumentException("Invalid script type " + this.type, "SetType");
                    return 5;
            }

            //Now write the script file to the working directory
            WriteScript(strScriptFile, this.code);

            //Now run the script
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();

            //Set if the script windows is hidden
            if (this.hidden)
            {
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            }

            startInfo.FileName = strStartFile;
            startInfo.Arguments = strArguments;

            process.StartInfo = startInfo;

            //try to run the process script.
            try
            {
                process.Start();
                process.WaitForExit(this.timeout * 1000);
                int intReturn = process.ExitCode;
                //return intReturn;
            }

            catch
            {
                //timeout reached
                return 4;
            }

            return state;
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
