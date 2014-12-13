using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using SystemLackey.Tasks;

namespace lackey_shell
{
    class LackeyShell
    {
        static void Main(string[] args)
        {
            //string strTestCode = "";
            //string 

            CmdTask task = new CmdTask("echo test && pause", false, 5);
            Console.WriteLine(task.strScriptFile);
            task.WriteScriptFile();
            task.Run();

        }
    }
}
