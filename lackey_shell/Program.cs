using System;
using SystemLackey.Worker;

namespace SystemLackey.Shell
{
    class LackeyShell
    {
        static void Main(string[] args)
        {
            Task_WinScript task = new Task_WinScript("task",0, "echo \"test\" && pause", false, 5,false);
            Task_WinScript task2 = new Task_WinScript("task2", 0, "@echo off && echo \"DICK!!!\" && pause", false, 10, false);
            Task_WinScript task3 = new Task_WinScript("task3", 0, "@echo off && echo \"blaaaaah\" && pause", false, 10, false);

            Job mainJob = new Job();
            mainJob.Name = "Test job";
            mainJob.Comments = "This is a job to test the structure of the job";

            mainJob.Root = new Step(mainJob, task);
            Step tempStep = new Step(mainJob, task2);

            mainJob.Root.Next = tempStep;
            tempStep.Prev = mainJob.Root;

            Job subJob = new Job();
            subJob.Name = "Test sub job";
            subJob.Comments = "This is a sub job to test it all hangs together";

            subJob.Root = new Step(subJob,task3);

            tempStep.Next = new Step(mainJob, subJob);
            tempStep.Next.Prev = tempStep;





            //Task_WinTaskWorker worker = new Task_WinTaskWorker();
            
            //SystemLackey.IO.XmlHandler handler = new SystemLackey.IO.XmlHandler();

            //handler.Write(SystemLackey.IO.IOConfiguration.WorkingPath + @"\test.xml",task.GetXml());
            
            //Task_WinScript task3 = new Task_WinScript();
            //task3.OpenXml(handler.Read(SystemLackey.IO.IOConfiguration.WorkingPath + @"\test.xml"));
            //task3.Name = "task3";
            //worker.Run(task);
            //worker.Run(task2);
            //Console.WriteLine(task.ScriptFile);

            //handler.Write(SystemLackey.IO.IOConfiguration.WorkingPath + @"\" + task.TaskID + ".xml",task2.GetXml());
            Console.WriteLine(task.GetXml());
            //Console.WriteLine(task3.GetXml());
            //Console.WriteLine(task3.Code);
            Console.Read();

        }
    }
}
