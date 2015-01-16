//    Program.cs: Entry point for the LackeyShell application
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
using SystemLackey.Worker;
using SystemLackey.UI;

namespace SystemLackey.UI.Shell
{
    public class LackeyShell
    {
        static void Main(string[] args)
        {
            WindowsScript task1 = new WindowsScript("task1",0, "echo \"task1\" && pause", false, 5,false);
            WindowsScript task2 = new WindowsScript("task2", 0, "@echo off && echo \"task2\" && pause", false, 10, false);
            WindowsScript task3 = new WindowsScript("task3", 0, "@echo off && echo \"task3\" && pause", false, 10, false);
            PowerControl task4 = new PowerControl();

            Job mainjob = new Job();
            mainjob.Name = "Test job";
            mainjob.Comments = "This is a job to test the structure of the job";

            mainjob.Root = new Step(mainjob,task1);
            Step tempStep = new Step(mainjob,task2);

            mainjob.Root.Next = tempStep;
            tempStep.Prev = mainjob.Root;

            Job subJob = new Job();
            subJob.Name = "Test sub job";
            subJob.Comments = "This is a sub job to test it all hangs together";

            subJob.Root = new Step(subJob,task4);

            tempStep.Next = new Step(mainjob,subJob);
            tempStep.Next.Prev = tempStep;

            Console.WriteLine(mainjob.GetXml());
            //Console.WriteLine(subJob.GetXml());

            Job newjob = new Job();

            newjob.ImportXml(mainjob.GetXml());

            //Console.WriteLine(newjob.GetXml());

            newjob.Run();

            //Task_WinTaskWorker worker = new Task_WinTaskWorker();
            
            SystemLackey.IO.XmlHandler handler = new SystemLackey.IO.XmlHandler();

            handler.Write(SystemLackey.IO.IOConfiguration.WorkingPath + @"\test.xml",newjob.GetXml());

            Console.Read();

        }

        public void Write(string pMessage)
        {
            Console.WriteLine(pMessage);
            Console.Read();
        }
    }
}
