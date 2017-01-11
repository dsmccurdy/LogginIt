using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogginIt
{
    public interface ITarget
    {

        void log(LogLevel level, string source, string message, Exception exception);
    }
}
