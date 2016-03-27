using N;
using N.Package.Events;
using System.Collections.Generic;

namespace N.ATF.Internal
{
    /// Keep track of players and things
    public class ConsoleDebug : IDebugService
    {
        /// Log a message
        public void Log(string format, params object[] args)
        {
            var msg = string.Format(format, args);
            N.Console.Log(msg);
        }

        /// Log a message
        public void Log(object target)
        {
            N.Console.Log(target);
        }
    }
}
