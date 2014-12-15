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

        public void OpenXml(XElement pElement)
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
    }
}
