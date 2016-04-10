using NE = N.Package.Events;

namespace N.Package.ATF
{
    /// A wrapper for an action for some useful features
    public class PreparedAction
    {
        private IEventService events;
        private IConfiguredAction action;

        public PreparedAction(IConfiguredAction action, IEventService events)
        {
            this.action = action;
            this.events = events;
        }

        /// Attempt to configure action
        public bool Configure<T>(T config)
        { return action.Configure(config); }

        /// Add an on complete handler
        public void OnComplete(ActionWaitHandler onComplete)
        {
            events.Events.AddEventHandler<NE.ActionCompleteEvent>((ap) =>
            {
                if (ap.Is(action))
                {
                    onComplete();
                }
            }, true);
        }

        /// Execute this action
        public void Execute()
        { events.Actions.Execute(action); }

        /// Cast the inner action as T
        public T As<T>() where T: class, IAction
        { return action as T; }
    }
}
