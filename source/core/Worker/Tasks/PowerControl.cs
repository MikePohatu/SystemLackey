﻿//    PowerControl.cs: PowerControl task class
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
using System.Diagnostics;
using SystemLackey.Messaging;


namespace SystemLackey.Worker
{
    public class PowerControl : MessageSender, ITask, IPickupPoint, IMessageSender
    {
        private string name = "Reboot";
        private string id;
        private string comments;
        private int wait = 0;
        

        //r = reboot
        //s = shutdown
        //l = logoff
        private char powerOption = 'r'; 

        public PowerControl()
        {
            id = Guid.NewGuid().ToString();
        }

        //Events
        public event EventHandler OnPutDown;

        //Run should return a final state
        //0=Succes
        //1=Information
        //2=Warning
        //3=Error
        //4=Timeout
        //5=Exception
        public int Run()
        {
            int intReturn;

            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();

            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "shutdown";
            startInfo.Arguments = @"/" + powerOption + @" /t " + wait;

            Console.WriteLine(startInfo.FileName + " " + startInfo.Arguments);

            if ( this.SetupScheduledTask() )
            {
                try
                {
                    process.StartInfo = startInfo;
                    //process.Start();
                    //process.WaitForExit(5000);
                    intReturn = process.ExitCode;
                }
                
                catch
                {
                    intReturn = 1;
                }
            }

            else { return 1; }
            
            return intReturn;
        }


        private bool SetupScheduledTask()
        {
            string command;
            string exePath;
            string exeOptions;
            string jobXml = "";
            string schedTaskName = "SystemLackey-" + jobXml;
            bool success = true;
            exePath = "";
            exeOptions = "";

            try
            {
                exeOptions = "";
                exePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\SystemLackey.exe";
                command = @"schtasks /create /tn """ + schedTaskName + @""" /sc ONSTART /z /v1 /f /ru SYSTEM /tr """ + exePath + @"""" + " " + exeOptions + @"""";
                //LogMessage(this, new LoggerEventArgs(exePath, 0));
                SendMessage(this, new MessageEventArgs("Scheduled task creation: " + schedTaskName, 1));
                SendMessage(this, new MessageEventArgs(command, 0));
            }
            catch
            { 
                //exception to be added
                success = false;
            }

            return success;
        }


        private bool ClearScheduledTask()
        {
            string command;
            string jobXml = "";
            string schedTaskName = "SystemLackey-" + jobXml;
            bool success = true;

            try
            {
                command = @"schtasks /delete /tn """ + schedTaskName + @""" /f";
                SendMessage(this, new MessageEventArgs("Scheduled task deletion: " + schedTaskName, 1));
                SendMessage(this, new MessageEventArgs(command, 0));
            }
            catch
            {
                //exception to be added
                success = false;
            }

            return success;
        }

        //Properties
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public string ID
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public string Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        public char PowerOption
        {
            get { return this.powerOption; }
            set { this.powerOption = value; }
        }

        public int Wait
        {
            get { return this.wait; }
            set { this.wait = value; }
        }

        private void BuildFromXml(XElement pElement, bool pImport)
        {
            name = pElement.Element("name").Value;
            comments = pElement.Element("comments").Value;
            powerOption = XmlConvert.ToChar(pElement.Element("powerOption").Value);
            wait = XmlConvert.ToInt32(pElement.Element("wait").Value);
            if (!pImport) { id = pElement.Element("id").Value; }
        }

        public void ImportXml(XElement pElement)
        {
            this.BuildFromXml(pElement,true);
        }

        public void OpenXml(XElement pElement)
        {           
            this.BuildFromXml(pElement,false);
        }

        public XElement GetXml()
        {
            XElement details = new XElement("Task",
                new XElement("name", name),
                new XElement("id", id),
                new XElement("comments", comments),
                new XElement("powerOption", powerOption),
                new XElement("wait", wait));

            details.SetAttributeValue("Type", "PowerControl");
            return details;
        }


        public bool PickUp()
        {
            SendMessage(this, new MessageEventArgs("PowerControl reboot completed. Continue job", MessageType.PICKUP));
            //code to be added. 
            //has the machine rebooted since the putdown
            return true;
        }

        public void PutDown()
        {
            //code to be added. 
            //record the putdown
            SendMessage(this, new MessageEventArgs("PowerControl rebooting machine. Stop job", MessageType.PUTDOWN));
            OnPutDown(this, EventArgs.Empty);
        }

        
    }
}
