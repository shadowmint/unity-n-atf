using UnityEngine;
using System;

namespace N.Package.ATF
{
  /// Base class for behaviours on individual states of state machines.
  public class AnimationTrigger : StateMachineBehaviour
  {
      // The animator that triggered this state
      protected GameObject gameObject;

      // Services
      public IEventService Events { get; set; }
      private bool initialized = false;

      override public sealed void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
      {
          if (!initialized)
          {
              Service.Registry.Bind(this);
          }
          gameObject = animator.gameObject;
          Start();
      }

      override public sealed void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
      {
          End();
      }

      override public sealed void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
      {
          Update();
      }

      /// Override for enter details if required
      protected virtual void Start()
      {
          Events.Events.Trigger(new AnimationTriggerEvent()
          {
              trigger = this,
              state = AnimationTriggerType.START,
              gameObject = this.gameObject
          });
      }

      /// Override for enter details if required
      protected virtual void End()
      {
          Events.Events.Trigger(new AnimationTriggerEvent()
          {
              trigger = this,
              state = AnimationTriggerType.END,
              gameObject = this.gameObject
          });
      }

      /// Override for update details
      protected virtual void Update() {}
  }
}
