﻿//    JobScheduler.cs: Contains a list of jobs with scheduled start times
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
using SystemLackey.Core.Messaging;

namespace SystemLackey.Core.Service
{
    public class JobScheduler: MessageSender
    {
        private List<JobSchedule> jobList = new List<JobSchedule>();

        public void Add(JobSchedule pJobSchedule)
        {
            string text = "";
            this.jobList.Add(pJobSchedule);
            this.jobList.Sort();

            foreach (JobSchedule js in this.jobList)
            {
                text += js.Job.Name + " : " + js.StartTime + System.Environment.NewLine;
            }
            
            SendMessage(this, new MessageEventArgs("Current schedule:" + System.Environment.NewLine + text, 0));
        }
    }
}
