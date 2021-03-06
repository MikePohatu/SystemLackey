﻿//    Program.cs: Main SystemLackey executable entry point. Starts either JobBuilder or 
//                or shell depending on argurments
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
using System.IO;
using SystemLackey.UI.Forms;
using SystemLackey.Core;

namespace SystemLackey
{
    public static class Entry
    {
        public static void Main(string[] args)
        {
            Shell newShell = new Shell();

            if (args.Length == 0)
            {
                Console.Write("Please enter path to package: ");
                string path = Console.ReadLine();
                string[] newArgs = new string[2] { "-file", path };
                newShell.Main(newArgs);
            }

            else
            {             
                newShell.Main(args);
            }
        }

        static void StartJB()
        {
            //JobBuilder jb = new JobBuilder();
            

            //create a new thread safe for win forms (STA) and start it. 
            Thread jbThread = new Thread(JobBuilder.Main);
            jbThread.SetApartmentState(ApartmentState.STA);
            jbThread.Start();
        }
    }
}
