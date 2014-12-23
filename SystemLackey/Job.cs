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
        private Step root = new Step();

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
                new XElement("id", jobid),
                new XElement("comments",comments));
            details.SetAttributeValue("Type", "Job");
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

        //
        public void ImportXml(XElement pElement)
        {
            Task_Factory factory = new Task_Factory();
            Step i = root;
            name = pElement.Element("name").Value;
            //taskid = pElement.Element("taskid").Value;
            jobid = pElement.Element("id").Value;
            comments = pElement.Element("comments").Value;
            foreach (XElement step in pElement.Descendants("Step"))
            {
                i.Next = new Step();
                i.Next.Prev = i;
                i.Next.Task = factory.Create(step.Element("Task").Attribute("Type").Value);
                i.Next.Task.ImportXml(step.Element("Task"));
                i = i.Next;

            }
        }

        // Run the job
        public int Run()
        {
            int state = 0;
            return state;
        }
    }

}
