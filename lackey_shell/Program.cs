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
            Task_WinScript task3 = new Task_WinScript();
            task3.OpenXml(handler.Read(SystemLackey.IO.IOConfiguration.WorkingPath + @"\dbf3a943-af5b-46d3-84f0-15296ae1a9f0.xml"));

            //worker.Run(task);
            //worker.Run(task2);
            //Console.WriteLine(task.ScriptFile);

            //handler.Write(SystemLackey.IO.IOConfiguration.WorkingPath + @"\" + task.TaskID + ".xml",task2.GetXml());
            Console.WriteLine(task3.GetXml());
            Console.Read();

        }
    }
}
