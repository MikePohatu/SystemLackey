using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SystemLackey.Worker
{
    //The step class contains details of each step in a job, including the previous and next steps. 
    //This will allow for easy re-ordering of the job. note that a task may be referenced 
    class Step
    {
        private Step next;
        private Step prev;
        private ITask task;
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
        //========================
        // /Properties
        //========================


        //========================
        // Constructors
        //========================
        public Step(ITask pTask)
        {
            this.task = pTask;
        }

    }
}
