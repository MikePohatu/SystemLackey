//    Step.cs: The Step class provides the links in a job. A Step links to
//             the desired ITask. Multiple Steps may link to the same ITask.
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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using SystemLackey.Messaging;

namespace SystemLackey.Tasks
{
    //The step class contains details of each step in a job, including the previous and next steps. 
    //This will allow for easy re-ordering of the job. note that a task may be referenced 
    public class Step : MessageSender,IMessageReceiver
    {
        private Job parent;

        //========================
        // Constructors
        //========================
        public Step(Job pParent, ITask pTask)
        {
            parent = pParent;
            Task = pTask;
            this.IsPickupPoint = false;

            //Suscribe to the tasks messages
            if (Task is IMessageSender)
            {
                //this.SendMessage(this, new MessageEventArgs("Added task to step: " + pTask.Name,1));
                ((IMessageSender)Task).SendMessageEvent += this.ReceiveMessage;
            }
        }



        //========================
        // Properties
        //========================

        public Step Next { get; set; }
        public Step Prev { get; set; }
        public ITask Task { get; set; }
        public bool ContinueOnError { get; set; }
        public bool ContinueOnWarning { get; set; }
        public bool IsPickupPoint { get; set; }

        public Job Parent
        {
            get { return this.parent; }
            set
            {
                //check if changed and update messaging
                if (this.parent != value)
                {
                    SendMessage(this, new MessageEventArgs("Changing step parent for task: " + this.Task.Name, 0));
                    if (this.parent != null)
                    {
                        this.SendMessageEvent -= this.parent.ReceiveMessage;
                    }

                    this.parent = value;

                    if (this.parent != null)
                    {
                        this.SendMessageEvent += this.parent.ReceiveMessage;
                    }
                }
            }
        }


        //========================
        // /Properties
        //========================


        //Forward any logging messages from the task up the chain. 
        //send pickup and putdown events as a new event from the step,
        //do not forwrard from the task. 
        public void ReceiveMessage(object o, MessageEventArgs e)
        {
            if (e.Type == MessageType.PUTDOWN)
            {
                IsPickupPoint = true;
                //forward the message as a log. 
                //SendMessage(o, new MessageEventArgs(e.Text, e.Level, MessageType.LOG));
                //send a putdown
                SendMessage(this, e);
            }
            
            else if (e.Type == MessageType.PICKUP)
            {
                IsPickupPoint = false;
                //forward the message as a log. 
                //SendMessage(o, new MessageEventArgs(e.Text, e.Level, MessageType.LOG));
                //send a pickup
                SendMessage(this, e);
            }

            //Forward message on
            else
            { SendMessage(o, e); }            
        }




        public XElement GetXML()
        {
            XElement details = new XElement("Step",
                new XElement("ContinueOnError",ContinueOnError),
                new XElement("ContinueOnWarning",ContinueOnWarning));

            if (Task != null)
            {
                details.Add(new XElement("taskid", Task.ID));
                details.Add(Task.GetXml());
            }
            details.SetAttributeValue("IsPickupPoint", IsPickupPoint);
   
            return details;
        }
    }
}
