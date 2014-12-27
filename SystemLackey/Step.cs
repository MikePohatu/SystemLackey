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
        private Task_Job parent;
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
        public Task_Job Parent
        {
           get { return this.parent; }
           set { this.parent = value; }
        }
        //========================
        // /Properties
        //========================


        //========================
        // Constructors
        //========================
        public Step(Task_Job pParent,ITask pTask)
        {
            parent = pParent;
            task = pTask;
        }

        //public Step(Task_Job pParent)
        //{
        //    parent = pParent;
        //}

        public XElement GetXML()
        {
            XElement details = new XElement("Step",
                new XElement("ContinueOnError",onError),
                new XElement("ContinueOnWarning",onWarn));
            
            if (task != null)
            {
                details.Add(new XElement("taskid", task.ID));
                details.Add(task.GetXml());
            }
                
            return details;
        }

    }
}
