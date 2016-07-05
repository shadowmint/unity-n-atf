using UnityEngine;
using N.Package.Events;

namespace N.Package.ATF
{
    /// Types of events that can be triggered
    public enum AnimationTriggerType
    {
        START,
        END
    }

    public class AnimationTriggerEvent : IEvent
    {
        /// Set and get access to the event helper api
        public IEventApi Api { get; set; }

        /// The GameObject associated with the animator
        public GameObject gameObject;

        /// The type of event
        public AnimationTriggerType state;

        /// The actual trigger object
        public AnimationTrigger trigger;

        /// Check for matching pattern
        public bool Is(AnimationTriggerType state)
        {
            return this.state == state;
        }

        /// Check for matching pattern
        public bool Is(GameObject gameObject)
        {
            return this.gameObject == gameObject;
        }
    }
}
