using System;

namespace SystemLackey.Worker
{
    public class Job : IJobItem
    {
        private string name = "";        //Name of the task

        private string jobid;
        private string comments = "";

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

        //========================
        // /Properties
        //========================
        
    }

}
