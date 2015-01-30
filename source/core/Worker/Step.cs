//    Step.cs: The Step class provides the links in a job. A Step links to
//             the desired ITask. Multiple Steps may link to the same ITask.
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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using SystemLackey.Logging;

namespace SystemLackey.Worker
{
    //The step class contains details of each step in a job, including the previous and next steps. 
    //This will allow for easy re-ordering of the job. note that a task may be referenced 
    public class Step : LoggingExtensions
    {
        private Step next;
        private Step prev;
        private ITask task;
        private Job parent;
        private bool isPickupPoint = false;
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
        public Job Parent
        {
           get { return this.parent; }
           set { this.parent = value; }
        }

        public bool IsPickupPoint
        {
            get { return this.isPickupPoint; }
            set { this.isPickupPoint = value; }
        }


        //========================
        // /Properties
        //========================




        //========================
        // Constructors
        //========================
        public Step(Job pParent,ITask pTask)
        {
            parent = pParent;
            task = pTask;

            //Suscribe to the tasks logs for forwarding
            if (task is LoggingExtensions)
            {
                ((LoggingExtensions)task).LogEvent += this.ForwardLog;
            }

            
            if (task is IPickupPoint)
            {
                //Subscribe to putdown events
                ((IPickupPoint)task).OnPutDown += this.CatchPutDown;
            }
        }

        //Catch a putdown event from a task and process it. 
        public void CatchPutDown(object o, EventArgs e)
        {
            isPickupPoint = true;
            NotifyIsPickup(this, EventArgs.Empty);
        }

        public XElement GetXML()
        {
            XElement details = new XElement("Step",
                new XElement("ContinueOnError",onError),
                new XElement("ContinueOnWarning",onWarn));

            if (isPickupPoint)
            {
                details.Add(new XElement("IsPickupPoint", isPickupPoint));
            }

            if (task != null)
            {
                details.Add(new XElement("taskid", task.ID));
                details.Add(task.GetXml());
            }
   
            return details;
        }

        public event EventHandler NotifyIsPickup;

    }
}
