using System;
using System.Threading.Tasks;

namespace SystemLackey.Logging
{
    public delegate void LoggerEventHandler(Object o, LoggerEventArgs e);

    public class Logger
    {
        //Logging levels
        //0=Debug
        //1=Information
        //2=Warning
        //3=Error
        //4=Danger Will Robinson!

        private bool toConsole = true;
        private bool toEventLog = false;

        //========================
        // Properties
        //========================

        public bool ToConsole
        {
            get { return this.toConsole; }
            set { this.toConsole = value; }
        }

        public bool ToEventLog
        {
            get { return this.toEventLog; }
            set { this.toEventLog = value; }
        }
        //=======================


        public event LoggerEventHandler EventDebug;
        public event LoggerEventHandler EventInfo;
        public event LoggerEventHandler EventWarning;
        public event LoggerEventHandler EventError;
        public event LoggerEventHandler EventDanger;

        public void Subscribe(Object o)
        {
            //m.Tick += new Metronome.TickHandler(HeardIt);
        }

        public void Write(string pText,int pLevel)
        {
            DateTime now = DateTime.Now;
            string time = now.ToString("u") + ": ";
            string prefix;
            switch (pLevel)
            {
                case 0:
                    if (EventDebug != null)
                    {
                        prefix = " [DEBUG] ";
                        EventDebug(this, new LoggerEventArgs(time + prefix + pText + Environment.NewLine, pLevel));
                    }
                    
                    break;
                case 1:
                    if (EventInfo != null)
                    {
                        prefix = " [INFO] ";
                        EventInfo(this, new LoggerEventArgs(time + prefix + pText + Environment.NewLine, pLevel));
                    } 
                    break;
                case 2:
                    prefix = " [WARN] ";
                    EventWarning(this, new LoggerEventArgs(time + prefix + pText + Environment.NewLine, pLevel));
                    break;
                case 3:
                    prefix = " [ERROR] ";
                    EventError(this, new LoggerEventArgs(time + prefix + pText + Environment.NewLine, pLevel));
                    break;
                case 4:
                    prefix = " [DANGER WILL ROBINSON!!!] ";
                    EventDanger(this, new LoggerEventArgs(time + prefix + pText + Environment.NewLine, pLevel));
                    break;
                default:
                    prefix = " [Invalid logging level] ";
                    System.ArgumentException argEx = new System.ArgumentException("Invalid logging level " + pLevel, "Logger.Write");
                    break;
            }            
        }
    }
}
