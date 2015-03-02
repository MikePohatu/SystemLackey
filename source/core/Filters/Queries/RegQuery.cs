//    RegQuery: registry query class. 
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
using Microsoft.Win32;

namespace SystemLackey.Core.Filters
{
    public class RegQuery : IQuery
    {
        private String root; //valid options HKEY_CURRENT_USER, HKEY_LOCAL_MACHINE, HKEY_CLASSES_ROOT, HKEY_USERS
        private String path;
        private String value;
        private Object data;
        private RegistryValueKind type;
        private bool existsOnly = false;

        //========================
        // Properties
        //========================

        public String Root
        {
            get { return this.root; }
            set { this.root = value; }
        }

        public String Path
        {
            get { return this.path; }
            set { this.path = value; }
        }

        public String Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public RegistryValueKind Type
        {
            get { return this.type; }
            set { this.type = value; }
        }

        public bool ExistsOnly
        {
            get { return this.existsOnly; }
            set { this.existsOnly = value; }
        }

        public Object Data
        {
            get { return this.data; }
            set { this.data = value; }
        }
        //========================



        public bool Evaluate()
        {
            String key; 
            key = root + @"\" + path;
            data = Registry.GetValue(key, value, null);

            if ( data != null)
            {
                if (existsOnly) { return true; } //we're only checking if it exists. this is all we need. 
                
                //if (data.GetType is type)
                return true; 
            }

            else
            { return false; }
        }
    }
}