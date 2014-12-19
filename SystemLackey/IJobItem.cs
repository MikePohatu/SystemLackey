using System;

namespace SystemLackey.Worker
{
    interface IJobItem
    {
        string Name
        {
            get;
            set;
        }

        string Comments
        {
            get;
            set;
        }

        string ID
        {
            get;
            set;
        }
    }
}
