using System;
using SystemLackey.Worker;
using SystemLackey.UI;

namespace SystemLackey.UI.Shell
{
    class LackeyShell
    {
        static void Main(string[] args)
        {
            Task_WinScript task1 = new Task_WinScript("task1",0, "echo \"task1\" && pause", false, 5,false);
            Task_WinScript task2 = new Task_WinScript("task2", 0, "@echo off && echo \"task2\" && pause", false, 10, false);
            Task_WinScript task3 = new Task_WinScript("task3", 0, "@echo off && echo \"task3\" && pause", false, 10, false);

            Task_Job mainjob = new Task_Job();
            mainjob.Name = "Test job";
            mainjob.Comments = "This is a job to test the structure of the job";

            mainjob.Root = new Step(mainjob,task1);
            Step tempStep = new Step(mainjob,task2);

            mainjob.Root.Next = tempStep;
            tempStep.Prev = mainjob.Root;

            Task_Job subJob = new Task_Job();
            subJob.Name = "Test sub job";
            subJob.Comments = "This is a sub job to test it all hangs together";

            subJob.Root = new Step(subJob,task3);

            tempStep.Next = new Step(mainjob,subJob);
            tempStep.Next.Prev = tempStep;

            Console.WriteLine(mainjob.GetXml());
            //Console.WriteLine(subJob.GetXml());

            Task_Job newjob = new Task_Job();

            newjob.ImportXml(mainjob.GetXml());

            //Console.WriteLine(newjob.GetXml());

            newjob.Run();

            //Task_WinTaskWorker worker = new Task_WinTaskWorker();
            
            SystemLackey.IO.XmlHandler handler = new SystemLackey.IO.XmlHandler();

            handler.Write(SystemLackey.IO.IOConfiguration.WorkingPath + @"\test.xml",newjob.GetXml());

            Console.Read();

        }
    }
}
