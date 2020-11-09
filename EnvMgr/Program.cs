using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.ServiceProcess;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnvMgr
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

    static class Test
    {
        public static int Results1(int a1, int a2)
        {
            int answer = a1 + a2;
            return answer;
        }

        public static int Results2(int a1, int a2)
        {
            int answer = a1 - a2;
            return answer;
        }
    }
}
