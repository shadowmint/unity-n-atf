using NE = N.Package.Events;

namespace N.Package.ATF
{
    /// Generate completion delegate helper
    public delegate void ActionWaitHandler();

    /// This is a template or simple common action types
    public abstract class ActionTemplate : IAction
    {
        /// Provide a description for all actions
        public abstract string Description { get; }

        /// Set the Actions api for this action
        protected NE.Actions actions;
        public NE.Actions Actions { set { actions = value; } }

        /// Set the timer for this action
        protected NE.Timer timer;
        public NE.Timer Timer { set { timer = value; } }

        /// Run the action
        public abstract void Execute();

        /// Run this when done
        protected void Complete()
        { actions.Complete(this); }
    }
}
