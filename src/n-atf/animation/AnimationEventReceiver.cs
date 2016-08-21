using System;
using UnityEngine;
using EventHandler = N.Package.Events.EventHandler;

namespace N.Package.ATF
{
  /// This class is automatically added for state machines to notify events through.
  [AddComponentMenu("")]
  public class AnimationEventReceiver : MonoBehaviour
  {
    // The event handler for this trigger
    private readonly EventHandler _events = new EventHandler();

    public EventHandler EventHandler
    {
      get { return _events; }
    }

    /// Automatically add a receiver on the target
    public static AnimationEventReceiver For(GameObject target)
    {
      var receiver = target.GetComponent<AnimationEventReceiver>() ?? target.gameObject.AddComponent<AnimationEventReceiver>();
      return receiver;
    }
  }
}