//    Logger.cs: Provides a mechanism for logging for other classes. Fires
//               events for any logging activity e.g. that the JBConsole 
//               can subscribe to
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
using System.Threading.Tasks;

namespace SystemLackey.Core.Messaging
{
    public class Logger
    {
        //Logging levels
        //0=Debug
        //1=Information
        //2=Warning
        //3=Error
        //4=Danger Will Robinson!
        public event MessagingEventHandler EventDebug;
        public event MessagingEventHandler EventInfo;
        public event MessagingEventHandler EventWarning;
        public event MessagingEventHandler EventError;
        public event MessagingEventHandler EventDanger;
        
        public void Write(MessageEventArgs e)
        {
            this.Write(e.Text, e.Level, e.Time);
        }

        public void Write(object o, MessageEventArgs e)
        {        
            string type = o.GetType().ToString();
            this.Write(e.Text + " - SOURCE=" + type, e.Level);
            //this.Write(e.Text, e.Level, e.Time);            
        }

        //take a Write with no time set. Set time to when it reached the logger. 
        public void Write(string pText,int pLevel)
        {
            string time;
            time = DateTime.Now.ToString("u") + ": ";
            this.Write(pText, pLevel, time);
        }

        public void Write(string pText,int pLevel, string pTime)
        {
            DateTime now = DateTime.Now;
            string time = pTime;
            string prefix;
            switch (pLevel)
            {
                case 0:
                    if (EventDebug != null)
                    {
                        prefix = " [DEBUG] ";
                        EventDebug(this, new MessageEventArgs(time + prefix + pText + Environment.NewLine, pLevel));
                    }
                    
                    break;
                case 1:
                    if (EventInfo != null)
                    {
                        prefix = " [INFO] ";
                        EventInfo(this, new MessageEventArgs(time + prefix + pText + Environment.NewLine, pLevel));
                    } 
                    break;
                case 2:
                    prefix = " [WARN] ";
                    EventWarning(this, new MessageEventArgs(time + prefix + pText + Environment.NewLine, pLevel));
                    break;
                case 3:
                    prefix = " [ERROR] ";
                    EventError(this, new MessageEventArgs(time + prefix + pText + Environment.NewLine, pLevel));
                    break;
                case 4:
                    prefix = " [DANGER WILL ROBINSON!!!] ";
                    EventDanger(this, new MessageEventArgs(time + prefix + pText + Environment.NewLine, pLevel));
                    break;
                default:
                    prefix = " [Invalid logging level] ";
                    System.ArgumentException argEx = new System.ArgumentException("Invalid logging level " + pLevel, "Logger.Write");
                    break;
            }            
        }
    }
}
