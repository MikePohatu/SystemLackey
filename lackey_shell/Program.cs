using System;
using SystemLackey.Worker;
using SystemLackey.UI;

namespace SystemLackey.UI.Shell
{
    class LackeyShell
    {
        static void Main(string[] args)
        {
            WindowsScript task1 = new WindowsScript("task1",0, "echo \"task1\" && pause", false, 5,false);
            WindowsScript task2 = new WindowsScript("task2", 0, "@echo off && echo \"task2\" && pause", false, 10, false);
            WindowsScript task3 = new WindowsScript("task3", 0, "@echo off && echo \"task3\" && pause", false, 10, false);

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

            subJob.Root = new Step(subJob,task3);

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
    }
}
