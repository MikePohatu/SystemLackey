using System;
using SystemLackey.Worker;

namespace SystemLackey.Shell
{
    class LackeyShell
    {
        static void Main(string[] args)
        {
            Task_WinScript task1 = new Task_WinScript("task1",0, "echo \"test\" && pause", false, 5,false);
            Task_WinScript task2 = new Task_WinScript("task2", 0, "@echo off && echo \"DICK!!!\" && pause", false, 10, false);
            Task_WinScript task3 = new Task_WinScript("task3", 0, "@echo off && echo \"blaaaaah\" && pause", false, 10, false);

            Task_Job mainjob = new Task_Job();
            mainjob.Name = "Test job";
            mainjob.Comments = "This is a job to test the structure of the job";

            mainjob.Root = new Step(task1);
            Step tempStep = new Step(task2);

            mainjob.Root.Next = tempStep;
            tempStep.Prev = mainjob.Root;

            Task_Job subJob = new Task_Job();
            subJob.Name = "Test sub job";
            subJob.Comments = "This is a sub job to test it all hangs together";

            subJob.Root = new Step(task3);

            tempStep.Next = new Step(subJob);
            tempStep.Next.Prev = tempStep;

            Task_Job newjob = new Task_Job();

            newjob.ImportXml(mainjob.GetXml());

            Console.WriteLine(newjob.GetXml());

            newjob.Run();

            //Task_WinTaskWorker worker = new Task_WinTaskWorker();
            
            SystemLackey.IO.XmlHandler handler = new SystemLackey.IO.XmlHandler();

            handler.Write(SystemLackey.IO.IOConfiguration.WorkingPath + @"\test.xml",newjob.GetXml());
            
            //Task_WinScript task3 = new Task_WinScript();
            //task3.OpenXml(handler.Read(SystemLackey.IO.IOConfiguration.WorkingPath + @"\test.xml"));
            //task3.Name = "task3";
            //worker.Run(task);
            //worker.Run(task2);
            //Console.WriteLine(task.ScriptFile);

            //handler.Write(SystemLackey.IO.IOConfiguration.WorkingPath + @"\" + task.TaskID + ".xml",task2.GetXml());
           // Console.WriteLine(task.GetXml());
            

            //Console.WriteLine(task3.GetXml());
            //Console.WriteLine(task3.Code);
            Console.Read();

        }
    }
}
