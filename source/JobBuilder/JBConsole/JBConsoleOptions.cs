//    JBConsoleOptions.cs: Class to contain options for the JBConsole
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

namespace SystemLackey.UI.Forms
{
    public class JBConsoleOptions
    {
        private bool debug;
        private bool info;
        private bool warning;
        private bool error;
        private bool danger;

        public bool Debug
        {
            get { return debug; }
            set { this.debug = value; }
        }

        public bool Info
        {
            get { return info; }
            set { this.info = value; }
        }

        public bool Warning
        {
            get { return warning; }
            set { this.warning = value; }
        }

        public bool Error
        {
            get { return error; }
            set { this.error = value; }
        }

        public bool Danger
        {
            get { return danger; }
            set { this.danger = value; }
        }
    }
}
