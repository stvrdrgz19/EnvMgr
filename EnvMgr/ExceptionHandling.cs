using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvMgr
{
    class ExceptionHandling
    {
        static string logFile = Environment.CurrentDirectory + @"\Files\Crashlog.txt";
        static string divider = "=================================================================================================================";

        public static bool LogException(string exception, string message)
        {
            //Write the exception and a message to a log.
            if (!File.Exists(logFile))
            {
                try
                {
                    File.Create(logFile);
                }
                catch
                {
                    return false;
                }
            }
            string errorToLog = divider + "\n" + divider + "\n" + "{" + DateTime.Now + "}" + "\n" + message + "\n\n" + exception + "\n";
            using (StreamWriter sw = File.AppendText(logFile))
            {
                try
                {
                    sw.WriteLine(errorToLog);
                }
                catch
                {
                    return false;
                }
            }
            return true;
        }
    }
}
