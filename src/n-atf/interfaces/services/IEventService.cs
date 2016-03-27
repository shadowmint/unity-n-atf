using NE = N.Package.Events;

namespace N.ATF
{
    /// Global time and actions api
    public interface IEventService
    {
        /// The game timer
        NE.Timer Timer { get; }

        /// The actions api for the whole game
        NE.Actions Actions { get; }

        /// Event handler api
        NE.EventHandler Events { get; }
    }

    /// Helpers
    public static class IEventServiceHelpers
    {
        /// Execute a resolved action
        public static T Action<T>(this IEventService self, bool executeNow = true) where T : class, IAction
        {
            var action = Service.Registry.CreateInstance<T>();
            if (executeNow) { self.Actions.Execute(action); }
            return action;
        }

        /// Return a prepared action
        public static PreparedAction Prepare<T>(this IEventService self) where T : class, IConfiguredAction
        {
            var action = Service.Registry.CreateInstance<T>();
            return new PreparedAction(action, self);
        }
    }
}
