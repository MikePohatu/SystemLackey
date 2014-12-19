using System;
using System.Collections;
using System.Xml.Linq;

namespace SystemLackey.Worker
{
    public class Job : ITask //: IEnumerable
    {
        private string name = "";        //Name of the task

        private string jobid;
        private string comments = "";
        private Step root;
        private Step last;

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
            set { this.root = value; }
        }

        //========================
        // /Properties
        //========================

        //IEnumerator GetEnumerator()
        //{
        //}

        //get the xml representation of the task
        public XElement GetXml()
        {
            XElement details = new XElement("Job",
                new XElement("name", name),
                new XElement("jobid", jobid),
                new XElement("comments",comments));
            return details;
        }



        //Insert a new step. If the job is not empty, put it at the end
        public void Insert(Step pStep)
        {
            if (root == null)
            {
                root = pStep;
                last = pStep;
            }
        }

        // Run the job
        public void Run()
        { }
    }

}
