using N.Package.Events;

namespace N.ATF
{
    /// Global time and actions api
    public interface IDebugService
    {
        /// Log a message
        void Log(string format, params object[] args);

        /// Log a message
        void Log(object target);
    }
}
