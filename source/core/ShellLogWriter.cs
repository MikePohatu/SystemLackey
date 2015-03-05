//    ShellLogWriter.cs: Displays messaging output to the console
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

namespace SystemLackey.Core
{
    public class ShellLogWriter
    {
        private Logger logger;
        private int logLevel = 5;  //init the value to above maximum, i.e. don't subscribe to anything

        public int LogLevel {
            get 
            { return this.logLevel; } 
            set
            {
                if ((value > 4) || (value < 0))
                { throw new InvalidOperationException("Invalid logging level: " + value); }
                else
                { 
                    this.UpdateSubscriptions(value);
                    this.logLevel = value;
                }
            }
        }

        public ShellLogWriter(Logger pLogger, int pLogLevel)
        {
            this.logger = pLogger;
            this.LogLevel = pLogLevel;
        }

        public void OutputMessage(object o, MessageEventArgs e)
        {
            Console.WriteLine(e.Text);
        }

        private void UpdateSubscriptions(int pNew)
        {
            if (this.logLevel != pNew)
            {
                if (this.logLevel > pNew)
                {
                    for (int i = this.logLevel + 1; i >= pNew; i--)
                    {
                        switch (i)
                        {
                            case 4:
                                logger.EventDanger += this.OutputMessage;
                                break;
                            case 3:
                                logger.EventError += this.OutputMessage;
                                break;
                            case 2: 
                                logger.EventWarning += this.OutputMessage;
                                break;
                            case 1: 
                                logger.EventInfo += this.OutputMessage;
                                break;
                            case 0:
                                logger.EventDebug += this.OutputMessage;
                                break;
                            default:
                                break;
                        }
                    }
                }

                else
                {
                    for (int i = this.logLevel; i < pNew; i++)
                    {
                        switch (i)
                        {
                            case 4:
                                logger.EventDanger -= this.OutputMessage;
                                break;
                            case 3:
                                logger.EventError -= this.OutputMessage;
                                break;
                            case 2:
                                logger.EventWarning -= this.OutputMessage;
                                break;
                            case 1:
                                logger.EventInfo -= this.OutputMessage;
                                break;
                            case 0:
                                logger.EventDebug -= this.OutputMessage;
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }
    }
}
