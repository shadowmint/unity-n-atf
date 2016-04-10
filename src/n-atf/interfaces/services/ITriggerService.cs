using System.Collections.Generic;
using NE = N.Package.Events;

namespace N.Package.ATF
{
    /// Global triggers api
    public interface ITriggerService
    {
        /// Trigger some specific type of event
        void Trigger<T>() where T : ITrigger;

        /// Trigger some specific type of event
        /// @param config The config to pass to each trigger.
        void Trigger<T, TConfig>(TConfig config) where T : ITrigger;

        /// Return a prepared action for all of triggers of type T
        /// @return A PreparedAction that resolved when all triggers are finished.
        PreparedAction Prepare<T>() where T : ITrigger;

        /// Return a prepared action for all of triggers of type T
        /// @param config A configuration object to pass to all triggers.
        /// @return A PreparedAction that resolved when all triggers are finished.
        PreparedAction Prepare<T, TConfig>(TConfig config) where T : ITrigger;

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
