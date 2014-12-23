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
            Step current = root;
            XElement details = new XElement("Job",
                new XElement("name", name),
                new XElement("jobid", jobid),
                new XElement("comments",comments));

            //enumerate through the list and get the xml from each node (step)
            while (true)
            {
                details.Add(current.GetXML());
                current = current.Next;
                if (current == null)
                { break; }
            }
            



            return details;
        }


        // Run the job
        public int Run()
        {
            int state = 0;
            return state;
        }
    }

}
