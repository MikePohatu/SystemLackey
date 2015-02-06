﻿//    Job.cs: Job class. Jobs are a linked list of Tasks in a particular fashion
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
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using SystemLackey.Messaging;

namespace SystemLackey.Worker
{
    public class Job : MessageSender, IMessageReceiver, ITask, IEnumerable, IPickupPoint
    {
        private string name = "";        //Name of the task

        private string jobid;
        private string comments = "";
        private Step root = null;       //root step for the job
        private Step pickupPoint;       //step to restart from for restarted job e.g. after reboot
        private bool isPutDown = false;         //has this job been put down

        public Job()
        {
            jobid = Guid.NewGuid().ToString();
        }

        //========================
        // Properties
        //========================

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public string ID
        {
            get { return this.jobid; }
            set { this.jobid = value; }
        }

        public string Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        public Step Root
        {
            get { return this.root; }
            set 
            {
                //unsubscribe from any messaging
                if (( this.root != null ) && (this.root.Parent != this))
                { root.SendMessageEvent -= this.ReceiveMessage; }

                this.root = value;
                //Suscribe to the step's logs for forwarding
                ((IMessageSender)this.root).SendMessageEvent += this.ReceiveMessage;
                 
            }
        }

        public Step PickupPoint
        {
            get { return this.pickupPoint; }
            set 
            { 
                if (value.Task is IPickupPoint)
                { this.pickupPoint = value; }
                else
                { //exception to be added
                }             
            }
        }

        //========================
        // /Properties
        //========================


        public int PickUp()
        {
            //code to be added. 
            //has the machine rebooted since the putdown
            return Run();
        }

        public void PutDown()
        {
            //code to be added. 
            //record the putdown
            //SendMessage(this, new MessageEventArgs("PowerControl rebooting machine. Stop job", MessageType.PUTDOWN));
        }


        //Forward any logging messages from the task up the chain. 
        //send pickup and putdown events as a new event from the step,
        //do not forwrard from the task. 
        public void ReceiveMessage(object o, MessageEventArgs e)
        {
            if (e.Type == MessageType.PUTDOWN)
            {
                this.isPutDown = true;
                this.pickupPoint = (Step)o;
                //forward the message as a log. 
                //SendMessage(o, new MessageEventArgs(e.Text, e.Level, MessageType.LOG));
                //send a putdown
                SendMessage(this, e);
            }

            else if (e.Type == MessageType.PICKUP)
            {
                this.isPutDown = false;
                this.pickupPoint = null;
                //forward the message as a log. 
                //SendMessage(o, new MessageEventArgs(e.Text, e.Level, MessageType.LOG));
                //send a pickup
                SendMessage(this, e);
            }

            //Forward message on
            else
            { SendMessage(o, e); }
        }
        

        //get the xml representation of the task
        public XElement GetXml()
        {
            Step currentStep = root;

            XElement details = new XElement("Task",
                new XElement("name", name),
                new XElement("id", jobid),
                new XElement("comments", comments));
            details.SetAttributeValue("Type","Job");
            //enumerate through the list and get the xml from each node (step)
            while (true)
            {
                if (currentStep == null)
                { break; }

                details.Add(currentStep.GetXML());
                currentStep = currentStep.Next;
                
            }
            return details;
        }
        
        // import job details from xml
        private void BuildFromXML(XElement pElement, bool pImport)
        {
            TaskFactory factory = new TaskFactory();
            factory.SendMessageEvent += this.ReceiveMessage;

            Step currentStep = root;
            Step newStep;
            root = null;

            name = pElement.Element("name").Value;
            comments = pElement.Element("comments").Value;
            if (pImport == false) { jobid = pElement.Element("id").Value; }

            foreach (XElement step in pElement.Elements("Step"))
            {
                newStep = new Step(this, factory.Create(step.Element("Task"),pImport));

                //Suscribe to the step's logs for forwarding
                ((IMessageSender)newStep).SendMessageEvent += this.ReceiveMessage;

                //now check if the step is a pickup point
                if ((bool)step.Attribute("IsPickupPoint") == true)
                {
                    newStep.IsPickupPoint = true;
                    this.PickupPoint = newStep;
                }

                if (root == null)
                {
                    root = newStep;
                    currentStep = root;
                }
                else
                {
                    currentStep.Next = newStep;
                    newStep.Prev = currentStep;
                    currentStep = newStep;
                }
            }

            //cleanup
            factory.SendMessageEvent -= this.ReceiveMessage;
        }

        public void OpenXml(XElement pElement)
        {
            BuildFromXML(pElement, false);
        }

        public void ImportXml(XElement pElement)
        {
            BuildFromXML(pElement, true);
        }

        public IEnumerator GetEnumerator()
        {
            JobEnumerator jobEnum = new JobEnumerator(this);
            return jobEnum;   
        }

        // Run the job
        public int Run()
        {
            int state = 0;
            int ret;
            Step s;

            //first check for a pickup point. if one exists, start the job from there.
            if (this.pickupPoint != null)
            { 
                s = this.pickupPoint;
                //isPutDown = false;
            }
            else
            { s = this.root; }

            while (true)
            {
                //check for null step. A null step indicates the end of the job. 
                if (s != null)
                {
                    //check for step with a null task. In theory it shouldn't happen, but oh well. 
                    if (s.Task != null)
                    {
                        ITask task = s.Task;
                        //run the task for the step, keeping the return value (or the pickup the task)
                        if (s.IsPickupPoint == true)
                        { 
                            var pickupTask = (IPickupPoint)task;
                            ret = pickupTask.PickUp(); 
                        }
                        else
                        { ret = task.Run(); }
                        

                        //catch warnings. check whether to contine
                        if ((ret == 3) && !s.ContinueOnWarning)
                        {
                            state = ret;
                            break;
                        }

                        //catch errors. check whether to contine
                        else if ((ret == 4) && !s.ContinueOnError)
                        {
                            state = ret;
                            break;
                        }

                        //now check if the job has been putdown
                        if (isPutDown == true) break;
                    }
                    s = s.Next;
                }
    
                //no more steps. break from the loop
                else
                { break; }
            }

            return state;
        }
    }

}
