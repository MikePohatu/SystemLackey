using System;
using System.Xml.Linq;

namespace SystemLackey.Worker
{
    class TaskFactory
    {
        public ITask Create(string pType)
        {
            ITask ret;
            switch (pType)
            {
                //batch script.
                case "WinScript":
                    ret = new WindowsScript();
                    break;
                case "Job":
                    ret = new Job();
                    break;
                case "Power":
                    ret = new PowerControl();
                    break;
                //invalid type. Throw exception
                default:
                    Console.WriteLine("Unknown type:" + pType);
                    System.ArgumentException argEx = new System.ArgumentException("Invalid script type " + pType,"SetType");
                    return null;
            }

            return ret;
            //return 
        }

        public ITask Create(XElement pElement)
        {
            ITask t = this.Create(pElement.Attribute("Type").Value);
            t.ImportXml(pElement);
            return t;
        }
    }
}
