using System;
using System.Text;

namespace SystemLackey.Logging
{
    public class LoggerEventArgs : EventArgs
    {
        private string text;
        private int level;

        public LoggerEventArgs(string pText,int pLevel)
        {
            text = pText;
            level = pLevel;
        }

        public string Text
        {
            get { return this.text; }
            set { this.text = value; }
        }

        //0=Success, 1=Information, 2=Warning, 3=Error, 4=Unknown 
        public int Level
        {
            get { return this.level; }
            set { this.level = value; }
        }
    }
}
