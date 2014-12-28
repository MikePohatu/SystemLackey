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
        private int level = 2;

        //========================
        // Properties
        //========================

        public int Level
        {
            get { return this.level; }
            set { this.level = value; }

        }

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



        public event LoggerEventHandler NewEvent;


        public void Subscribe(Object o)
        {
            //m.Tick += new Metronome.TickHandler(HeardIt);
        }

        public void Write(string pText,int pLevel)
        {
            if (pLevel <= this.level)
            {
                string prefix;
                switch (pLevel)
                {
                    case 0:
                        prefix = "[DEBUG]";
                        break;
                    case 1:
                        prefix = "[INFO]";
                        break;
                    case 2:
                        prefix = "[WARN]";
                        break;
                    case 3:
                        prefix = "[ERROR]";
                        break;
                    case 4:
                        prefix = "[DANGER WILL ROBINSON!!!]";
                        break;
                    default:
                        prefix = "[Invalid logging level]";
                        System.ArgumentException argEx = new System.ArgumentException("Invalid logging level " + level, "Logger.Write");
                        break;
                }
                     
                LoggerEventArgs lea = new LoggerEventArgs(prefix + pText + Environment.NewLine, pLevel);
                NewEvent(this, lea);
                //System.Console.WriteLine("HEARD IT");
            }
            
        }
    }
}
