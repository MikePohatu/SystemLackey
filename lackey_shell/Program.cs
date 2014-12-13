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

            Task_WinScript task = new Task_WinScript(0,"echo test && pause", false, 5);
            Console.WriteLine(task.ScriptFile);
            Console.WriteLine(task.Run());
            //Console.Read();

        }
    }
}
