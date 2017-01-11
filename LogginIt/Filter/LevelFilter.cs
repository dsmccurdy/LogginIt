using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogginIt.Filter
{
    public class LevelFilter:ITarget
    {
        private LogLevel minLevel;
        private ITarget target;

        public LevelFilter(LogLevel minLevel, ITarget target)
        {
            this.minLevel = minLevel;
            this.target = target;
        }

        public void log(LogLevel level, string source, string message, Exception exception)
        {
            if(level >= minLevel)
            {
                target.log(level, source, message, exception);
            }
        }
    }
}
