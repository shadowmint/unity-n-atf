using NE = N.Package.Events;

namespace N.ATF
{
    /// This is a template or simple common trigger types
    public abstract class TriggerTemplate : ITrigger
    {
        /// Provide a description for all actions
        public abstract string Description { get; }

        /// The priority for this trigger
        public abstract int Priority { get; }

        /// Set the Actions api for this action
        protected NE.Actions actions;
        public NE.Actions Actions { set { actions = value; } }

        /// Set the timer for this action
        protected NE.Timer timer;
        public NE.Timer Timer { set { timer = value; } }

        /// Run this when done
        protected void Complete()
        { actions.Complete(this); }

        /// Run the action
        public abstract void Execute();

        /// Configure this action with T, if T is a supported type.
        /// @param config The configuration
        /// @return True if the configuration worked, and false otherwise.
        public abstract bool Configure<T>(T config);
    }

}
