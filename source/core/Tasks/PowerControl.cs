//    PowerControl.cs: PowerControl task class
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
using SystemLackey.Filters;

namespace SystemLackey.Tasks
{
    public class PowerControl : MessageSender, ITask, IPickupPoint
    {
        private DateTime putDownTime;


        //Properties
        public string Name { get; set; }
        public string ID { get; set; }
        public string Comments { get; set; }
        public char PowerOption { get; set; }
        //PowerOption:
        //r = reboot
        //s = shutdown
        //l = logoff
        public int Wait { get; set; }
        

        public PowerControl()
        {
            this.Name = "Reboot";
            this.PowerOption = 'r';
            this.ID = Guid.NewGuid().ToString();
            this.Wait = 0;
        }

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
            startInfo.Arguments = @"/" + PowerOption + @" /t " + Wait;

            this.PutDown();

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
            
            return intReturn;
        }


        

        

        private void BuildFromXml(XElement pElement, bool pImport)
        {
            Name = pElement.Element("name").Value;
            Comments = pElement.Element("comments").Value;
            PowerOption = XmlConvert.ToChar(pElement.Element("powerOption").Value);
            Wait = XmlConvert.ToInt32(pElement.Element("wait").Value);
            
            //get the putdowntime if there is one. This element may not exist
            XElement dt = pElement.Element("PutDownTime");
            if (dt != null) putDownTime = (DateTime)dt;

            if (!pImport) { ID = pElement.Element("id").Value; }
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
                new XElement("name", Name),
                new XElement("id", ID),
                new XElement("comments", Comments),
                new XElement("powerOption", PowerOption),
                new XElement("wait", Wait));

            if (putDownTime != DateTime.MinValue) details.Add(new XElement("PutDownTime", putDownTime));
            details.SetAttributeValue("Type", "PowerControl");          
            return details;
        }


        public int PickUp()
        {
            
            if (WindowsPerformanceQuery.BootTime > putDownTime)
            { //reset the putdown time
                putDownTime = DateTime.MinValue;
                SendMessage(this, new MessageEventArgs("Bootime: " + WindowsPerformanceQuery.BootTime.ToString(), MessageType.LOG));
                SendMessage(this, new MessageEventArgs("Clear ONBOOT setup", MessageType.ONBOOT_CLEAR));
                SendMessage(this, new MessageEventArgs("PowerControl reboot completed. Continue job", MessageType.PICKUP));
                return 0;
            }
            else
            {
                SendMessage(this, new MessageEventArgs("No reboot since putdown", 2));
                return 2;
            }
        }

        public void PutDown()
        {
            //record the putdown
            putDownTime = DateTime.Now;
            
            SendMessage(this, new MessageEventArgs("PowerControl rebooting machine. Stop job", MessageType.PUTDOWN));
            SendMessage(this, new MessageEventArgs("PowerControl contine on reboot requested", MessageType.ONBOOT_CONTINUE));                       
        }
    }
}
