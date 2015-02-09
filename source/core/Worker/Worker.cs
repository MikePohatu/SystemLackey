//    Worker.cs: Main worker class. Responsible for running jobs
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
using SystemLackey.Tasks;
using SystemLackey.Messaging;
using SystemLackey.IO;

namespace SystemLackey.Worker
{
    public class JobRunner: MessageForwarder
    {
        public Job Job { get; set; }

        public void Run()
        {
            if (this.Job != null)
            { }
            else
            { SendMessage(this, new MessageEventArgs("No job configured", 3)); }
        }

        //Forward any logging messages from the task up the chain. 
        //send pickup and putdown events as a new event from the job 
        public void ReceiveMessage(object o, MessageEventArgs e)
        {
            if (e.Type == MessageType.CONTINUE_ONBOOT)
            {
                if (this.Job != null)
                { 
                    var ts = new WindowsTaskScheduler();
                    ts.SendMessageEvent += this.ForwardMessage;

                    //save a new running xml file
                    string xmlFile = this.Job.ID + "-Running.xml";
                    string xmlPath = IOConfiguration.WorkingPath + @"\" +xmlFile;
                    XmlHandler xmlHandler = new XmlHandler();
                    xmlHandler.Write(xmlPath, this.Job.GetXml());

                    ts.SetupOnBoot(xmlFile,xmlPath);

                    ts.SendMessageEvent -= this.ForwardMessage;
                }
                //forward message on
                SendMessage(o, e);
            }

            if (e.Type == MessageType.CLEAR_ONBOOT)
            {
                if (this.Job != null)
                {
                    var ts = new WindowsTaskScheduler();
                    ts.SendMessageEvent += this.ForwardMessage;

                    //save a new running xml file
                    string xmlFile = this.Job.ID + "-Running.xml";

                    ts.ClearOnBoot(xmlFile);

                    ts.SendMessageEvent -= this.ForwardMessage;
                }
                //forward message on
                SendMessage(o, e);
            }

            //Forward message on
            else
            {
                //var me = new MessageEventArgs("Message forwarded from: " + this.GetType().ToString(), 0);
                //SendMessage(this, me);
                SendMessage(o, e);
            }
        }
    }
}
