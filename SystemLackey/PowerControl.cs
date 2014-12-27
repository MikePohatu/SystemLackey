using System;
using System.Xml;
using System.Xml.Linq;
using System.Diagnostics;

namespace SystemLackey.Worker
{
    public class PowerControl : ITask
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

        //Run should return a final state
        //0=Succes
        //1=Information
        //2=Warning
        //3=Error
        //4=Timeout
        //5=Exception
        public int Run()
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();

            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "shutdown";
            startInfo.Arguments = @"/" + powerOption + @" /t " + wait;

            Console.WriteLine(startInfo.FileName + " " + startInfo.Arguments);

            process.StartInfo = startInfo;
            //process.WaitForExit(5000);

            //int intReturn = process.ExitCode;
            return 0;
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

        public void ImportXml(XElement pElement)
        {
            name = pElement.Element("name").Value;
            //id = pElement.Element("id").Value;
            comments = pElement.Element("comments").Value;
            powerOption = XmlConvert.ToChar(pElement.Element("powerOption").Value);
            wait = XmlConvert.ToInt32(pElement.Element("wait").Value);
        }

        public XElement GetXml()
        {
            XElement details = new XElement("Task",
                new XElement("name", name),
                new XElement("id", id),
                new XElement("comments", comments),
                new XElement("powerOption", powerOption),
                new XElement("wait", wait));

            details.SetAttributeValue("Type", "Power");
            return details;
        }
    }
}
