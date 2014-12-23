using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace SystemLackey.Worker
{
    //The step class contains details of each step in a job, including the previous and next steps. 
    //This will allow for easy re-ordering of the job. note that a task may be referenced 
    public class Step
    {
        private Step next;
        private Step prev;
        private ITask task;
        //private Job parent;
        //private Evaluation eval;
        private bool onError = true;
        private bool onWarn = true;
        //private 

        //========================
        // Properties
        //========================

        public Step Next
        {
            get { return this.next; }
            set { this.next = value; }
        }

        public Step Prev
        {
            get { return this.prev; }
            set { this.prev = value; }
        }

        public ITask Task
        {
            get { return this.task; }
            set { this.task = value; }
        }

        public bool ContinueOnError
        {
            get { return this.onError; }
            set { this.onError = value;}
        }

        public bool ContinueOnWarning
        {
            get { return this.onWarn; }
            set { this.onWarn = value; }
        }
        //public Job Parent
        //{
        //   get { return this.parent; }
        //  set { this.parent = value; }
        //}
        //========================
        // /Properties
        //========================


        //========================
        // Constructors
        //========================
        public Step(ITask pTask)
        {
            //this.parent = pParent;
            this.task = pTask;
        }

        public Step()
        { }

        //public Step(Job pParent)
        //{
        //    this.parent = pParent;
        //}

        public Step(Step pPrev, ITask pTask,Step pNext)
        {
            //this.parent = pParent;
            this.task = pTask;
            this.next = pNext;
            this.prev = pPrev;
        }

        public Step(ITask pTask, Step pNext)
        {
            //this.parent = pParent;
            this.task = pTask;
            this.next = pNext;
        }

        public Step(Step pPrev, ITask pTask)
        {
            //this.parent = pParent;
            this.task = pTask;
            this.prev = pPrev;
        }
        //Insert a step after this step.
        //if there is an existing step after this, set it as the step after
        //the new step
        public void InsertAfter(Step pStep)
        {
            if (this.next == null)
            {
                this.next = pStep;
            }
            else
            {
                //insert is between two steps, so we will have to 
                //save to a temp variable
                Step tempStep = this.next;
                this.next = pStep;
                pStep.Next = tempStep;
                tempStep.Prev = pStep;
            }
        }

        //Insert a step before this step.
        //if there is an existing step before this, set it as the step before
        //the new step
        public void InsertBefore(Step pStep)
        {
            if (this.prev == null)
            {
                this.prev = pStep;
            }
            else 
            {
                //insert is between two steps, so we will have to 
                //save to a temp variable
                Step tempStep = this.prev;
                this.prev = pStep;
                pStep.Prev = tempStep;
                tempStep.Next = pStep;
            } 
        }

        public XElement GetXML()
        {
            XElement details = new XElement("Step",
                new XElement("taskid", task.ID),
                new XElement("ContinueOnError",onError),
                this.Task.GetXml());
            return details;
        }

    }
}
