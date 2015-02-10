//    UpdateTimer.cs: provides a timer for policy updates
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
using System.Threading;

namespace SystemLackey.Service
{
    internal class UpdateTimer
    {
        private int period = 7200; //default time in seconds
        
        public int Period
        {
            get { return this.period; }
            set { this.period = value; }
        }

        public int PeriodMinutes
        {
            get { return this.period / 60; }
            set { this.period = value * 60 ; }
        }


        public int PeriodSeconds
        {
            get { return this.period; }
            set { this.period = value ; }
        }

        Timer timer;

        //Constructors
        public UpdateTimer(TimerCallback pMethod, object pState)
        {
            this.Period = 120;
            timer = new Timer(pMethod, pState, 0, this.Period * 1000);
        }


        public UpdateTimer(TimerCallback pMethod, object pState, int pPeriod)
        {
            this.Period = pPeriod;
            timer = new Timer(pMethod, pState, 0, this.Period * 1000);
        }


        public UpdateTimer(TimerCallback pMethod, object pState, int pPeriod, int pDelay)
        {
            this.Period = pPeriod;
            timer = new Timer(pMethod, pState, pDelay, this.Period * 1000);
        }
    }
}
