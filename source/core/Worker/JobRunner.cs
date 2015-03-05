//    JobRunner.cs: Main worker class. Responsible for running jobs
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
using SystemLackey.Core.Messaging;
using SystemLackey.Core.Tasks;
using SystemLackey.Core.Service;
using SystemLackey.Core.IO;

namespace SystemLackey.Core.Worker
{
    public class JobRunner: IMessageSender, IMessageReceiver
    {
        private Job job;

        public Job Job 
        {
            get { return this.job; }
            set
            {
                if (this.job != null) { this.job.SendMessageEvent -= this.ReceiveMessage; } 
                this.job = value;
                this.job.SendMessageEvent += this.ReceiveMessage;
            }
        }

        public JobRunner(Job pRootJob)
        {
            this.Job = pRootJob;
        }


        //run the assigned job
        public void Run()
        {
            if (this.job != null)
            {
                this.SendMessage(this, new MessageEventArgs("Running job: " + this.job.Name, 1));
                job.Run();

                //clear message subscriptions
                this.SendMessageEvent = null;
            }
            else
            { SendMessage(this, new MessageEventArgs("No job configured", 3)); }
        }



        //Messaging
        #region
        public event MessagingEventHandler SendMessageEvent;

        //Log a new event. Check for empty event handler first
        public virtual void SendMessage(Object o, MessageEventArgs e)
        {
            MessagingEventHandler temp = SendMessageEvent;
            if (temp != null)
            { temp(o, e); }
        }

        //Forward any logging messages from the task up the chain. 
        //send pickup and putdown events as a new event from the job 
        public void ReceiveMessage(object o, MessageEventArgs e)
        {
            if (e.Type == MessageType.ONBOOT_CONTINUE)
            {
                if (this.job != null)
                { 
                    var wts = new WindowsTaskScheduler();
                    wts.SendMessageEvent += this.ReceiveMessage;

                    //save a new running xml file
                    string xmlFile = this.job.ID + "-Running.xml";
                    string xmlPath = IOConfiguration.WorkingPath + @"\" +xmlFile;
                    XmlHandler xmlHandler = new XmlHandler();
                    xmlHandler.Write(xmlPath, this.job.GetXml());

                    wts.SetupOnBoot(xmlFile, xmlPath);

                    wts.SendMessageEvent -= this.ReceiveMessage;
                }
                //forward message on
                this.SendMessage(o, e);
            }

            if (e.Type == MessageType.ONBOOT_CLEAR)
            {
                if (this.job != null)
                {
                    var wts = new WindowsTaskScheduler();
                    wts.SendMessageEvent += this.ReceiveMessage;

                    //save a new running xml file
                    string xmlFile = this.job.ID + "-Running.xml";

                    wts.ClearOnBoot(xmlFile);

                    wts.SendMessageEvent -= this.ReceiveMessage;
                }
                //forward message on
                this.SendMessage(o, e);
            }

            //Forward message on
            else
            {
                this.SendMessage(o, e);
            }
        }
        #endregion
    }
}
