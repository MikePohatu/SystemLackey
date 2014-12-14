using System;
using SystemLackey.Tasks;
using SystemLackey.Tasks.WindowsScripting;

namespace SystemLackey.Shell
{
    class LackeyShell
    {
        static void Main(string[] args)
        {
            Task_WinTaskWorker worker = new Task_WinTaskWorker();
            Task_WinScript task = new Task_WinScript(0, "echo test && pause", false, 5,false);
            Task_WinScript task2 = new Task_WinScript(0, @"@echo off && echo DICK!!! && pause", false, 10, false);
            SystemLackey.IO.XmlHandler handler = new SystemLackey.IO.XmlHandler();

            //worker.Run(task);
            //worker.Run(task2);
            //Console.WriteLine(task.ScriptFile);

            handler.Write(SystemLackey.IO.IOConfiguration.WorkingPath + @"\" + task.TaskID + ".xml",task2.GetXml());
            Console.WriteLine(task.GetXml());
            Console.Read();

        }
    }
}
