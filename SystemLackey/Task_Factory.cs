using System;
using System.Xml.Linq;

namespace SystemLackey.Worker
{
    class Task_Factory
    {
        public ITask Create(string pType)
        {
            ITask ret;
            switch (pType)
            {
                //batch script.
                case "WinScript":
                    ret = new Task_WinScript();
                    break;
                case "Job":
                    ret = new Job();
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
            ITask t = this.Create( pElement.Attribute("Type").Value );
            t.ImportXml(pElement);
            return t;

        }
    }
}
