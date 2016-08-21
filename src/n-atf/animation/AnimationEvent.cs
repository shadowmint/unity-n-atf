using UnityEngine;
using N.Package.Events;

namespace N.Package.ATF
{
  /// Types of events that can be triggered
  public enum AnimationTriggerType
  {
    Start,
    End
  }

  public class AnimationTriggerEvent
  {
    /// The GameObject associated with the animator
    public GameObject GameObject;

    /// The type of event
    public AnimationTriggerType State;

    /// The actual trigger object
    public AnimationTrigger Trigger;

    /// Check for matching pattern
    public bool Is(AnimationTriggerType state)
    {
      return State == state;
    }

    /// Check for matching pattern
    public bool Is(GameObject gameObject)
    {
      return GameObject == gameObject;
    }
  }
}