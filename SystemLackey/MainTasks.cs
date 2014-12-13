using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SystemLackey.Tasks
{
    interface ITask
    {
        int Run();
    }

    class PowerControl : ITask
    {
        public int Run()
        {
            return 0;
        }
    }

    class CopyFile : ITask
    {
        public int Run()
        {
            return 0;
        }
    }

    class CopyFolder : ITask
    {
        public int Run()
        {
            return 0;
        }
    }
}
