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

        public void log(LogLevel level, string source, string message, Exception exception)
        {
            lock (s_lock)
            {
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
