//    TaskFactory.cs: Factory class to return the correct class for an Xml definition
//                    or String value.
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
using System.Xml.Linq;
using SystemLackey.Logging;

namespace SystemLackey.Worker
{
    class TaskFactory: BaseLoggable, ILoggable
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
                    this.LogMessage(this, new LoggerEventArgs("Failed to create unknown type: " + pType, 3));
                    Console.WriteLine("Unknown type:" + pType);
                    System.ArgumentException argEx = new System.ArgumentException("Invalid script type " + pType,"SetType");
                    return null;
            }

            this.LogMessage(this, new LoggerEventArgs("Created " + pType, 1));
            return ret;
            //return 
        }

        public ITask Create(XElement pElement, bool pImport)
        {
            //create the task
            string type = pElement.Attribute("Type").Value;
            ITask t = this.Create(type);

            //subscribe to logging events so the factory can pass them up the tree
            //the parent job won't subscribe until after the factory is finished
            if (t is ILoggable) { ((ILoggable)t).LogEvent += this.ForwardLog; }

            //now import/open the xml
            if (pImport) 
            {
                this.LogMessage(this, new LoggerEventArgs("Importing " + type, 1));
                t.ImportXml(pElement);
                this.LogMessage(this, new LoggerEventArgs("Finished importing " + type + " task: " + t.Name + " ID: " + t.ID, 1));
            }
            else 
            {
                this.LogMessage(this, new LoggerEventArgs("Importing " + type, 1));
                t.OpenXml(pElement);
                this.LogMessage(this, new LoggerEventArgs("Finished opening " + type + " task: " + t.Name + " ID: " + t.ID, 1));
            }
            
            return t;
        }
    }
}
