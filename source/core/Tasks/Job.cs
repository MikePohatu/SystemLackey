//    Job.cs: Job class. Jobs are a linked list of Tasks in a particular fashion
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

namespace SystemLackey.Tasks
{
    public class Job : MessageSender, IMessageReceiver, ITask, IEnumerable, IPickupPoint
    {    
        private Step pickupPoint;       //step to restart from for restarted job e.g. after reboot
        private bool isPutDown = false;         //has this job been put down

        public Job()
        {
            this.ID = Guid.NewGuid().ToString();
        }

        //========================
        // Properties
        //========================

        public string Name { get; set; }
        public string ID { get; set; }
        public string Comments { get; set; }
        public Step Root { get; set; }  //root step for the job

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
            return Run();
        }

        public void PutDown()
        {
            //code to be added. 
            //record the putdown
            //SendMessage(this, new MessageEventArgs("PowerControl rebooting machine. Stop job", MessageType.PUTDOWN));
        }


        //Forward any logging messages from the task up the chain. 
        //send pickup and putdown events as a new event from the job 
        public void ReceiveMessage(object o, MessageEventArgs e)
        {
            if (e.Type == MessageType.PUTDOWN)
            {
                this.isPutDown = true;
                this.pickupPoint = (Step)o;
                //forward the message as a log. 
                //var me = new MessageEventArgs("Message forwarded from: " + this.GetType().ToString(), 0);
                //SendMessage(this, me);

                SendMessage(this, e);
            }

            else if (e.Type == MessageType.PICKUP)
            {
                this.isPutDown = false;
                this.pickupPoint = null;
                //forward the message as a log. 
                //var me = new MessageEventArgs("Message forwarded from: " + this.GetType().ToString(), 0);
                //SendMessage(this, me);
                SendMessage(this, e);
            }

            //Forward message on
            else
            {
                //var me = new MessageEventArgs("Message forwarded from: " + this.GetType().ToString(), 0);
                //SendMessage(this, me);
                SendMessage(o, e); 
            }
        }
        

        //get the xml representation of the task
        public XElement GetXml()
        {
            Step currentStep = this.Root;

            XElement details = new XElement("Task",
                new XElement("name", this.Name),
                new XElement("id", this.ID),
                new XElement("comments", this.Comments));
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

        //public method to get a list of tasks in the job.
        //this is an accessor method. This calls the private recusive method GetSubTasks 
        //that walks the tree to get all the details
        public Dictionary<string, ITask> GetTasks()
        {
            Dictionary<string, ITask> taskDictionary = new Dictionary<string, ITask>();
            taskDictionary.Add(this.ID, this);

            this.GetSubTasks(taskDictionary);
            return taskDictionary;
        }

        //get all the tasks in the job and subjobs, and add them to the provided dictionary
        private void GetSubTasks(Dictionary<string, ITask> pTaskDictionary)
        {
            Step currentStep = this.Root;

                       

            //enumerate through the list and get the xml from each node (step)
            while (true)
            {
                if (currentStep == null)
                { break; }

                //if not in the dictionary, add it
                if (!(pTaskDictionary.ContainsKey(currentStep.Task.ID)))
                {
                    pTaskDictionary.Add(currentStep.Task.ID, currentStep.Task); 
                }
                
                //recursively add to the dictionary
                if (currentStep.Task is Job)
                {
                    ((Job)currentStep.Task).GetSubTasks(pTaskDictionary);
                }
                currentStep = currentStep.Next;

            }
        }


        // import job details from xml
        //private void BuildFromXML(XElement pElement, bool pImport)
        //{
        //    TaskFactory factory = new TaskFactory();
        //    factory.SendMessageEvent += this.ReceiveMessage;

        //    Step currentStep = null;
        //    Step newStep;
        //    this.Root = null;

        //    this.Name = pElement.Element("name").Value;
        //    this.Comments = pElement.Element("comments").Value;
        //    if (pImport == false) { this.ID = pElement.Element("id").Value; }

        //    foreach (XElement step in pElement.Elements("Step"))
        //    {
        //        newStep = new Step(this, factory.Create(step.Element("Task"),pImport));

        //        //Suscribe to the step's logs for forwarding
        //        ((IMessageSender)newStep).SendMessageEvent += this.ReceiveMessage;

        //        //now check if the step is a pickup point
        //        XAttribute isPickup = step.Attribute("IsPickupPoint");
        //        if ((isPickup != null) && ((bool)isPickup == true))
        //        {
        //            newStep.IsPickupPoint = true;
        //            if (this.pickupPoint != null) { SendMessage(this, new MessageEventArgs("Corrupt XML. Multiple pickup points for job", 3)); }
        //            this.pickupPoint = newStep;
        //            this.isPutDown = true;
        //            SendMessage(this, new MessageEventArgs("PickupPoint: " + newStep.Task.Name + " ID: " + newStep.Task.ID, 1));
        //        }

        //        if (this.Root == null)
        //        {
        //            this.Root = newStep;
        //            currentStep = newStep;
        //        }
        //        else
        //        {
        //            currentStep.Next = newStep;
        //            newStep.Prev = currentStep;
        //            currentStep = newStep;
        //        }
        //    }

        //    //cleanup
        //    factory.SendMessageEvent -= this.ReceiveMessage;
        //}


        // import job details from xml
        public void BuildTreeFromXml(XElement pElement, bool pImport)
        {
            Step currentStep = null;
            Step newStep;
            this.Root = null;

            this.Name = pElement.Element("name").Value;
            this.Comments = pElement.Element("comments").Value;
            if (pImport == false) { this.ID = pElement.Element("id").Value; }

            foreach (XElement step in pElement.Elements("Step"))
            {
                //create a new empty step with the taskid
                newStep = new Step(this, step.Element("taskid").Value);

                //Suscribe to the step's logs for forwarding
                ((IMessageSender)newStep).SendMessageEvent += this.ReceiveMessage;

                //now check if the step is a pickup point
                XAttribute isPickup = step.Attribute("IsPickupPoint");
                if ((isPickup != null) && ((bool)isPickup == true))
                {
                    newStep.IsPickupPoint = true;
                    if (this.pickupPoint != null) { SendMessage(this, new MessageEventArgs("Corrupt XML. Multiple pickup points for job", 3)); }
                    this.pickupPoint = newStep;
                    this.isPutDown = true;
                    SendMessage(this, new MessageEventArgs("PickupPoint: " + newStep.Task.Name + " ID: " + newStep.TaskID, 1));
                }

                if (this.Root == null)
                {
                    this.Root = newStep;
                    currentStep = newStep;
                }
                else
                {
                    currentStep.Next = newStep;
                    newStep.Prev = currentStep;
                    currentStep = newStep;
                }
            }
        }

        //populate an empty job tree with tasks.
        public void Populate(Dictionary<string, ITask> pTaskDictionary)
        {
            this.SendMessage(this, new MessageEventArgs("Populating job: " + this.ID, 1));
            ITask currentTask;
            foreach (Step s in this)
            {
                if (pTaskDictionary.TryGetValue(s.TaskID, out currentTask))
                {
                    if (currentTask is Job) { ((Job)currentTask).Populate(pTaskDictionary); }
                    else 
                    {
                        this.SendMessage(this, new MessageEventArgs("Attaching task: " + currentTask.ID, 1));
                        s.Task = currentTask; 
                    }
                }
            }
        }

        public void OpenXml(XElement pElement)
        {
            BuildTreeFromXml(pElement, false);
        }

        public void ImportXml(XElement pElement)
        {
            BuildTreeFromXml(pElement, true);
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
            { s = this.Root; }

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
