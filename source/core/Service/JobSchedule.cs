//    JobSchedule.cs: defines a specific scheduling of a job
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
using SystemLackey.Core.Tasks;

namespace SystemLackey.Core.Service
{
    public class JobSchedule:IComparable<JobSchedule>
    {
        public Job Job { get; set; }
        public DateTime StartTime { get; set; }

        //sort in descending order i.e. the next job to run should go at the end.
        //this is purely for performance reasons. 
        public int CompareTo(JobSchedule other)
        {
            if (this.StartTime > other.StartTime) { return -1; }
            else if (this.StartTime > other.StartTime) { return 1; }
            //if the time is the same, sort by job name. 
            else
            {
                return String.Compare(this.Job.Name, other.Job.Name, true) * -1;
            }
        }
    }
}
