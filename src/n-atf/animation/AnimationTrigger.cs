using System;
using UnityEngine;
using EventHandler = N.Package.Events.EventHandler;

namespace N.Package.ATF
{
  /// Base class for behaviours on individual states of state machines.
  public class AnimationTrigger : StateMachineBehaviour
  {
    // The animator that triggered this state
    protected GameObject GameObject;

    // The receiver for events from this object
    protected AnimationEventReceiver Receiver;

    public sealed override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
      GameObject = animator.gameObject;
      Receiver = AnimationEventReceiver.For(GameObject);
      Start();
    }

    public sealed override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
      End();
    }

    public sealed override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
      Update();
    }

    /// Override for enter details if required
    protected virtual void Start()
    {
      Receiver.EventHandler.Trigger(new AnimationTriggerEvent()
      {
        Trigger = this,
        State = AnimationTriggerType.Start,
        GameObject = GameObject
      });
    }

    /// Override for enter details if required
    protected virtual void End()
    {
      Receiver.EventHandler.Trigger(new AnimationTriggerEvent()
      {
        Trigger = this,
        State = AnimationTriggerType.End,
        GameObject = GameObject
      });
    }

    /// Override for update details
    protected virtual void Update()
    {
    }
  }

  public static class AnimationTriggerExtensions
  {
    /// Bind an event listener to any animation triggers on the object
    /// If the Func returns true, the event is removed.
    /// ie. Check for 'End' or 'Start' and return true if its the desired target.
    public static void OnAnimationTrigger(this Animator target, Func<AnimationTriggerEvent, bool> handler)
    {
      var receiver = AnimationEventReceiver.For(target.gameObject);
      Action<AnimationTriggerEvent> wrapper = null;
      wrapper = (ep) =>
      {
        if (handler(ep))
        {
          receiver.EventHandler.RemoveEventHandler(wrapper);
        }
      };
      receiver.EventHandler.AddEventHandler(wrapper);
    }
  }
}