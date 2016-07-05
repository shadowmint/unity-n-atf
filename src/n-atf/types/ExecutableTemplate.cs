using UnityEngine;
using N.Package.Events;

namespace N.Package.ATF
{
    /// This is a template or simple common action types
    public abstract class ExecutableTemplate : IAction
    {
        /// Provide a description for all actions
        public abstract string Description { get; }

        /// Set the Actions api for this action
        protected N.Package.Events.Actions actions;
        public N.Package.Events.Actions Actions { set { actions = value; } }

        /// Set the timer for this action
        protected N.Package.Events.Timer timer;
        public N.Package.Events.Timer Timer { set { timer = value; } }

        /// Run this when done
        protected void Complete()
        {
            PreComplete();
            actions.Complete(this);
        }

        /// Configure this action with T, if T is a supported type.
        /// @param config The configuration
        /// @return True if the configuration worked, and false otherwise.
        public virtual bool Configure<T>(T config)
        {
            return false;
        }

        /// Override this for a pre-complete hook.
        /// It is invoked immediately before the action is resolved.
        protected virtual void PreComplete()
        {
        }

        /// If this is an async task, resolve it when the animator calls it
        /// with the given combination of state and target.
        protected void CompleteOnAnimationTrigger<T>(GameObject target, AnimationTriggerType state) where T : AnimationTrigger
        {
            timer.Events.AddEventHandler((AnimationTriggerEvent ep) =>
            {
                if (ep.Is(target) && ep.Is(state) && (ep.trigger is T))
                {
                    ep.Api.Remove<AnimationTriggerEvent>();
                    Complete();
                }
                else
                {
                    ep.Api.Keep<AnimationTriggerEvent>();
                }
            }, true);
        }

        /// Run the action
        public abstract void Execute();
    }
}
