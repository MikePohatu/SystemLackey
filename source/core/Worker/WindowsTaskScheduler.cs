using System;
using SystemLackey.Messaging;

namespace SystemLackey.Worker
{
    public class WindowsTaskScheduler: MessageSender
    {
        public bool SetupOnBoot(string pJobXmlFile)
        {
            string commandArgs;
            string exePath = "";
            string exeOptions = "";
            string schedTaskName = "SystemLackey-" + pJobXmlFile;
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


        public bool ClearOnBoot(string pJobXmlFile)
        {
            string commandArgs;
            string schedTaskName = "SystemLackey-" + pJobXmlFile;
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
