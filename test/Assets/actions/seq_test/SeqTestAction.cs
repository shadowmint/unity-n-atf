using UnityEngine;
using N.Package.ATF;
using N.Package.Command;
using N.Package.Events;

/// Trigger the 'MakeTiny' animation state on the target.
public class SeqTestAction : IAction
{
  public GameObject Target;
  private readonly EventHandler _eventHandler = new EventHandler();

  public string Description
  {
    get { return "Run a bunch of animations"; }
  }

  public EventHandler EventHandler
  {
    get { return _eventHandler; }
  }

  public bool CanExecute()
  {
    return true;
  }

  public void Execute()
  {
    if (Target != null)
    {
      var sequence = new CommandSequence();

      IAction action = new GoTinyAction();
      action.Configure(Target);
      sequence.Add(action);

      action = new ColorCycleAction();
      action.Configure(Target);
      sequence.Add(action);

      action = new GoTinyAction();
      action.Configure(Target);
      sequence.Add(action);

      sequence.OnCompleted((ep) => { this.Completed(); });
      sequence.Execute();
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
    if (obj == null) return false;
    Target = (GameObject) (object) instance;
    return true;
  }
}