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
using System.IO;
using System.Xml;
using System.Xml.Linq;
using SystemLackey.Core.Messaging;

namespace SystemLackey.Core.Tasks
{
    public class WindowsScript : MessageSender, ITask, IMessageSender, IContentTask
    {
        public string Name { get; set; }
        public int Timeout { get; set; }
        public bool ASync { get; set; }
        public string Code { get; set; }
        public bool Wow64 { get; set; }
        public string ID { get; set; }
        public bool Hidden { get; set; }
        public int Type { get; set; }
        public string Comments { get; set; }
        public ContentPack ContentPack { get; set; }

        //Default constructor
        public WindowsScript()
        {           
            this.ID = Guid.NewGuid().ToString();
            this.Name = "";
            this.Type = 0;
            this.Timeout = 900;
            this.Wow64 = false;
            this.ASync = false;
            this.Hidden = true;
            this.Code = "";
            this.Comments = "";
        }


        //get the xml representation of the task
        public XElement GetXml()
        {
            XElement details = new XElement("Task",
                new XElement("name",Name),
                new XElement("taskid",ID),
                new XElement("async",ASync),
                new XElement("timeout", Timeout),
                new XElement("code",Code),
                new XElement("type",Type),
                new XElement("wow64",Wow64),
                new XElement("hidden", Hidden),
                new XElement("comments", Comments));

            if (this.ContentPack == null) { details.SetAttributeValue("Content", false); }
            else { details.SetAttributeValue("Content", true); }

            details.SetAttributeValue("Type", "WinScript");
            return details;
        }

        private bool BuildFromXml(XElement pElement,bool pImport)
        {
            Name = pElement.Element("name").Value;          
            ASync = XmlConvert.ToBoolean(pElement.Element("async").Value);
            Timeout = XmlConvert.ToInt32(pElement.Element("timeout").Value);
            Code = pElement.Element("code").Value;
            Type = XmlConvert.ToInt32(pElement.Element("type").Value);
            Wow64 = XmlConvert.ToBoolean(pElement.Element("wow64").Value);
            Hidden = XmlConvert.ToBoolean(pElement.Element("hidden").Value);
            Comments = pElement.Element("comments").Value;
            if (pImport == false) { ID = pElement.Element("taskid").Value; }

            bool bContent = XmlConvert.ToBoolean(pElement.Attribute("Content").Value);

            return bContent;
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
            string strWorkingPath;
            if (this.ContentPack == null) { strWorkingPath = SystemLackey.Core.IO.IOConfiguration.WorkingPath; }
            else { strWorkingPath = this.ContentPack.WorkingPath; }

            //make sure the working directory is there
            System.IO.Directory.CreateDirectory(strWorkingPath);
            this.SendMessage(this, new MessageEventArgs("Running script: " + this.Name, 1));

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

                    strScriptFile = strWorkingPath + @"\" + this.ID + strExtn;
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
                    strScriptFile = strWorkingPath + @"\" + this.ID + strExtn;
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
                    strScriptFile = strWorkingPath + @"\" + this.ID + strExtn;
                    strArguments = "-executionpolicy bypass " + strScriptFile;
                    break;

                //invalid type. Throw exception
                default:
                    System.ArgumentException argEx = new System.ArgumentException("Invalid script type " + this.Type, "SetType");
                    return 5;
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

            startInfo.WorkingDirectory = strWorkingPath;
            startInfo.FileName = strStartFile;
            startInfo.Arguments = strArguments;

            process.StartInfo = startInfo;

            //try to run the process script.
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
                File.WriteAllText(pPath, pCode);
            }
            catch
            {
                bolSuccess = false;
            }

            return bolSuccess;
        }

    }
}
