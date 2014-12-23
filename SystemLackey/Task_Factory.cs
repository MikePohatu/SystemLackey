using System;

namespace SystemLackey.Worker
{
    class Task_Factory
    {
        public ITask Create(string pType)
        {
            switch (pType)
            {
                //batch script.
                case "WinScript":
                    return new Task_WinScript();
                    break;
                case "Job":
                    return new Job();
                    break;
                //invalid type. Throw exception
                default:
                    System.ArgumentException argEx = new System.ArgumentException("Invalid script type " + pType,"SetType");
                    return null;
            }
            //return 
        }

    }
}
