using System;
using System.Collections;
using System.Xml.Linq;

namespace SystemLackey.Worker
{
    public class Task_Job : ITask //: IEnumerable
    {
        private string name = "";        //Name of the task

        private string jobid;
        private string comments = "";
        private Step root = null;

        public Task_Job()
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
            XElement details = new XElement("Task",
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
        
        // import job details from xml
        public void ImportXml(XElement pElement)
        {
            Task_Factory factory = new Task_Factory();
            Step i = new Step(this);
            root = i;
            bool first = true;

            name = pElement.Element("name").Value;
            //taskid = pElement.Element("taskid").Value;
            jobid = pElement.Element("id").Value;
            comments = pElement.Element("comments").Value;
            
            foreach (XElement step in pElement.Elements("Step"))
            {
                if (!first)
                {
                    i.Next = new Step(this);
                    i.Next.Prev = i;
                    i.Next.Task = factory.Create(step.Element("Task"));
                    i = i.Next;
                }
                else
                {
                    i.Task = factory.Create(step.Element("Task"));
                    first = false;
                }
                
            }
        }

        // Run the job
        public int Run()
        {
            int state = 0;
            int ret;
            Step s = root;

            while (true)
            {
                //check for null step. A null step indicates the end of the job. 
                if (s != null)
                {
                    //check for step with a null task. In theory it shouldn't happen, but oh well. 
                    if (s.Task != null)
                    {
                        //run the task for the step, keeping the return value
                        ret = s.Task.Run();

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
