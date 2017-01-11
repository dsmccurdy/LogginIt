using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace LogginIt
{
    public class Log
    {
        private string source;

        #region ctor 
        public Log(string source)
        {
            this.source = source;
        }
        #endregion

        #region log

        public void debug(string message, Exception ex = null)
        {
            log(LogLevel.DEBUG, source, message, ex);
        }

        public void info(string message, Exception ex = null)
        {
            log(LogLevel.INFO, source, message, ex);
        }

        public void warning(string message, Exception ex = null)
        {
            log(LogLevel.WARNING, source, message, ex);
        }

        public void error(string message, Exception ex = null)
        {
            log(LogLevel.ERROR, source, message, ex);
        }

        #endregion


        #region static
        private static ReaderWriterLockSlim s_lock = new ReaderWriterLockSlim();
        private static List<ITarget> s_targets = new List<ITarget>();
        
        public static void registerTarget(ITarget target)
        {
            try 
            {
                s_lock.EnterWriteLock();
                s_targets.Add(target);
            }
            finally
            {
                s_lock.ExitWriteLock();
            }
        }

        private static void log(LogLevel level, string source, string message, Exception exception)
        {
            try
            {
                s_lock.EnterReadLock();

                foreach(var t in s_targets)
                {
                    t.log(level, source, message, exception);
                }
            }
            finally
            {
                s_lock.ExitReadLock();
            }
        }

        #endregion
    }
}
