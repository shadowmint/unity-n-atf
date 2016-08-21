using UnityEngine;
using N.Package.ATF;
using N.Package.Command;
using N.Package.Events;

/// Trigger the 'MakeTiny' animation state on the target.
public class GoTinyAction : IAction
{
  public GameObject Target;

  public string Description
  {
    get { return "Trigger the 'Tiny' state on the target"; }
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
    if (Target != null)
    {
      var instance = Target.AddComponent<GoTinyBehaviour>();
      instance.Action = this;
      instance.Duration = 2f;
    }
    else
    {
      this.Completed();
    }
  }

  // Configure with target game object
  public bool Configure<T>(T instance)
  {
    if (!(instance is GameObject)) return false;
    Target = (GameObject) (object) instance;
    return true;
  }
}