//    WindowsTaskScheduler.cs: Class to create scheduled tasks
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
using SystemLackey.Core.Messaging;

namespace SystemLackey.Core.Worker
{
    public class WindowsTaskScheduler: MessageSender
    {
        public bool SetupOnBoot(string pName, string pJobXmlFile)
        {
            string commandArgs;
            string exePath = "";
            string exeOptions = "-file " + pJobXmlFile;
            string schedTaskName = "SystemLackey-" + pName;
            int intReturn;
            bool success = true;

            try
            {
                exeOptions = "";
                exePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\SystemLackey.exe";
                commandArgs = @" /create /tn """ + schedTaskName + @""" /sc ONSTART /z /v1 /f /ru SYSTEM /tr """ + exePath + @"""" + " " + exeOptions;
                //LogMessage(this, new LoggerEventArgs(exePath, 0));
                SendMessage(this, new MessageEventArgs("Scheduled task creation: " + schedTaskName, 1));
                SendMessage(this, new MessageEventArgs("schtasks " +  commandArgs, 0));

                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();

                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = "schtasks";
                startInfo.Arguments = commandArgs;

                process.StartInfo = startInfo;
                process.Start();
                process.WaitForExit(5000);
                intReturn = process.ExitCode;
            }
            catch
            {
                //exception to be added
                success = false;
            }

            return success;
        }


        public bool ClearOnBoot(string pSchedTaskName)
        {
            string commandArgs;
            string schedTaskName = "SystemLackey-" + pSchedTaskName;
            bool success = true;
            int intReturn;

            try
            {
                commandArgs = @"/delete /tn """ + schedTaskName + @""" /f";
                SendMessage(this, new MessageEventArgs("Scheduled task deletion: " + schedTaskName, 1));
                SendMessage(this, new MessageEventArgs("schtasks " + commandArgs, 0));


                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();

                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = "schtasks";
                startInfo.Arguments = commandArgs;

                process.StartInfo = startInfo;
                process.Start();
                process.WaitForExit(5000);
                intReturn = process.ExitCode;
            }
            catch
            {
                //exception to be added
                success = false;
            }

            return success;
        }
    }
}
