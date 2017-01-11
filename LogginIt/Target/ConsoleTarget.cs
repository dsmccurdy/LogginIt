using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogginIt.Target
{
    public class ConsoleTarget : ITarget
    {
        private static object s_lock = new object();

        private static Dictionary<LogLevel, ConsoleColor> colors;
        static ConsoleTarget()
        {
            colors = new Dictionary<LogLevel, ConsoleColor>();
            colors[LogLevel.DEBUG] = ConsoleColor.Blue;
            colors[LogLevel.ERROR] = ConsoleColor.Red;
            colors[LogLevel.INFO] = ConsoleColor.White;
            colors[LogLevel.WARNING] = ConsoleColor.Yellow;
        }

        public void log(LogLevel level, string source, string message, Exception exception)
        {
            lock (s_lock)
            {   
                Console.ForegroundColor = colors[level];

                Console.WriteLine(level.ToString() + " " + source + ": " + message);
                if (exception != null)
                {
                    Console.WriteLine("Exception " + exception.GetType().FullName);
                    Console.WriteLine("Message: " + exception.Message);
                    Console.WriteLine("Trace: " + exception.StackTrace);
                }
            }
        }
    }
}
