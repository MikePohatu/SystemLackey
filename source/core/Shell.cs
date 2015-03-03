//    Shell.cs: Entry point for the LackeyShell application
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
using System.Diagnostics;
using System.IO;
using System.Threading;

using SystemLackey.Core.Messaging;
using SystemLackey.Core.Tasks;
using SystemLackey.Core.IO;
using SystemLackey.Core.Worker;



namespace SystemLackey.Core
{
    public class Shell
    {
        JobPackage jp;
        Logger logger = new Logger();
        Job rootJob = null;
        //bool foreground = false;

        public void Main(string[] args)
        {
            

            //deal with arguments
            if (args.Length == 0)
            {
                ShowHelp();
            }

            else
            {
                for (int i = 0; i < args.Length; i++)
                {
                    switch (args[i].ToLower())
                    {
                        case "-file":
                        case "/file":
                            if (args.Length < (i+2)) 
                            {
                                Console.WriteLine("-file missing parameter");
                                System.Environment.Exit(1); 
                            }
                            else
                            {                              
                                jp = new JobPackage(args[i + 1]);
                                try
                                { rootJob = jp.Open(); }
                                catch (FileNotFoundException e)
                                {
                                    Console.WriteLine(e.Message);
                                    System.Environment.Exit(1);
                                }
                            }
                            break;
                        //case "-foreground":
                        //case "/foreground":
                        //    foreground = true;
                        //    break;
                        default:
                            break;
                    }

                    if (rootJob != null)
                    {
                        var runner = new JobRunner(rootJob);
                        runner.SendMessageEvent += this.ReceiveMessage;
                        Thread runnerThread = new Thread(runner.Run);
                        //if (foreground) {  }
                        runnerThread.IsBackground = false;
                        runnerThread.Start(); 
                    }
                    else
                    {
                        Console.WriteLine("No job specified");
                        System.Environment.Exit(1);
                    }
                }
            }
        }

        private static void ShowHelp()
        { 
            string helpText = "";
            Console.WriteLine(helpText);
        }

        public void ReceiveMessage(object o, MessageEventArgs e)
        {
            logger.Write(o, e);
        }
    }
}
