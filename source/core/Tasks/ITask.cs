//    ITask.cs: Interface for task objects. Task objects define actual things
//              to be done on the machine. Tasks are link together to make a Job
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
using System.Xml.Linq;

namespace SystemLackey.Tasks
{
    public interface ITask
    {
        //methods
        XElement GetXml();
        void ImportXml(XElement pElement);
        void OpenXml(XElement pElement);

        //Run should return a final state
        //0=Succes
        //1=Information
        //2=Warning
        //3=Error
        //4=Timeout
        //5=Exception
        int Run();

        //Properties
        string Name
        {
            get;
            set;
        }

        string ID
        {
            get;
            set;
        }

        string Comments
        {
            get;
            set;
        }
    }

}
