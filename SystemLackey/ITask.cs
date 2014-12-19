﻿using System;
using System.Xml.Linq;

namespace SystemLackey.Worker
{
    interface ITask
    {
        //methods
        XElement GetXml();
        void Run();

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
