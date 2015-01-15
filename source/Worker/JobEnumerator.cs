using System;
using System.Collections;

namespace SystemLackey.Worker
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
