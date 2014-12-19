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

    }
}
