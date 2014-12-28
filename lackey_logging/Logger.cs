using System;
using System.Threading.Tasks;

namespace SystemLackey.Logging
{
    public delegate void LoggerEventHandler(Object o, LoggerEventArgs e);

    public class Logger
    {
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



        public event LoggerEventHandler NewEvent;


        public void Subscribe(Object o)
        {
            //m.Tick += new Metronome.TickHandler(HeardIt);
        }

        public void Write(string pText,int pLevel)
        {
            LoggerEventArgs lea = new LoggerEventArgs(pText + Environment.NewLine, pLevel);

            NewEvent(this, lea);
            //System.Console.WriteLine("HEARD IT");
        }
    }
}
