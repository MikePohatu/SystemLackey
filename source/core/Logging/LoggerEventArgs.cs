//    LoggerEventArgs.cs: EventArgs derived class for the Logger class
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
using System.Text;

namespace SystemLackey.Logging
{
    public class LoggerEventArgs : EventArgs
    {
        private string text;
        private int level;
        private string time;

        public LoggerEventArgs(string pText,int pLevel)
        {
            text = pText;
            level = pLevel;
            //Set time to the creation of the loggereventargs (which will probably be
            //accurate in most cases).
            time = DateTime.Now.ToString("u") + ": ";
        }

        public string Text
        {
            get { return this.text; }
            set { this.text = value; }
        }

        public string Time
        {
            get { return this.time; }
            set { this.time = value; }
        }

        //0=Success, 1=Information, 2=Warning, 3=Error, 4=Unknown 
        public int Level
        {
            get { return this.level; }
            set { this.level = value; }
        }
    }
}
