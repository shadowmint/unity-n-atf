using System.Collections.Generic;
using NE = N.Package.Events;

namespace N.ATF
{
    /// Global triggers api
    public interface ITriggerService
    {
        /// Trigger some specific type of event
        void Trigger<T>() where T : ITrigger;

        /// Prepare a trigger and return it
        PreparedAction Prepare<T>() where T : ITrigger;

        /// Iterate over the set of types this system is aware of
        IEnumerable<System.Type> Triggers { get; }
    }

    /// Helpers
    public static class ITriggerServiceHelpers
    {
        /// Check if the trigger system knows about a specific trigger type
        /// Mostly useful for debugging.
        public static bool HasTrigger<T>(this ITriggerService self)
        {
            foreach (var t in self.Triggers)
            {
                if (t == typeof(T))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
