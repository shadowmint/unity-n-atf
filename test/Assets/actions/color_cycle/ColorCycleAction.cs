using UnityEngine;
using N.Package.ATF;
using N.Package.Command;
using N.Package.Events;

/// Trigger the 'MakeTiny' animation state on the target.
public class ColorCycleAction : IAction
{
  public GameObject target;
  public Animator animator;

  public string Description
  {
    get { return "Trigger the 'Color' animation state on the target"; }
  }

  public EventHandler EventHandler
  {
    get { return _eventHandler; }
    set { _eventHandler = value; }
  }

  private EventHandler _eventHandler = new EventHandler();
  
  public bool CanExecute()
  {
    return true;
  }

  public void Execute()
  {
    if (target != null)
    {
      animator = target.GetComponentInChildren<Animator>();
      animator.SetBool("Color", true);

      // See the AnimationTrigger type for how this works; the ColorCycleTrigger
      // is set on the state machine for the animation.
      animator.OnAnimationTrigger((ep) =>
      {
        if (!ep.Is(AnimationTriggerType.End)) return false;
        animator.SetBool("Color", false);
        this.Completed();
        return true;
      });
    }
    else
    {
      this.Completed();
    }
  }

  // Configure with target game object
  public bool Configure<T>(T instance)
  {
    var obj = instance as GameObject;
    if (obj != null)
    {
      target = (GameObject) (object) instance;
      return true;
    }
    return false;
  }
}