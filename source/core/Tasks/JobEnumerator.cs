//    JobEnumerator.cs: for IEnumerable support for the Job class
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
using System.Collections;

namespace SystemLackey.Tasks
{
    class JobEnumerator : IEnumerator
    {
        private Step current;
        private Job parentJob;

        public JobEnumerator(Job pParent)
        {
            parentJob = pParent;
        }

        public Object Current
        {
            get { return this.current; }
        }

        public bool MoveNext()
        {
            if (current == null) { current = parentJob.Root; }
            else { current = current.Next; }

            if ( current != null ) { return true; }
            else { return false; }
        }

        public void Reset()
        {
            this.current = null;
        }
    }
}
