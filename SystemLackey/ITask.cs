using System;
using System.Xml.Linq;

namespace SystemLackey.Worker
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
