//    Panel2Factory.cs: Factory class to create the panel2 forms objects
//                      for a selected treenode
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
using System.Windows.Forms;
using SystemLackey.Worker;
using SystemLackey.Logging;

namespace SystemLackey.UI.Forms
{
    class Panel2Factory: ILoggable
    {
        public Form Create(TreeNode n)
        {
            Object o = n.Tag;
            //MessageBox.Show(o.ToString(), o.ToString());
            //job form
            if (o is Job)
            { 
                return new FormJobDetails((Job)o,n);
            }
            
            else
            {
                Step s = (Step)o;
                ITask task = s.Task;
                //WinScript form
                if (s.Task is WindowsScript)
                {
                    return new FormWindowsScriptTaskControl((WindowsScript)task, n);
                }

                //Power control form
                else if (s.Task is PowerControl)
                {
                    return new FormPowerControl((PowerControl)task, n);
                }

                //Subjob form
                else if (s.Task is Job)
                {
                    return new FormJobDetails((Job)task, n);
                }

                //Unknown type
                else { return null; }
            }
        }


        //Events
        public event LoggerEventHandler LogMessage;
    }
}
