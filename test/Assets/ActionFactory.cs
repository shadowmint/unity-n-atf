using UnityEngine;
using N.Package.ATF;
using N.Package.Command;

public class ActionFactory : MonoBehaviour
{
  [Tooltip("Drag an object here to select it")]
  public GameObject[] Targets;

  [Tooltip("Trigger 'Go Tiny' on targets")]
  public bool GoTiny = false;

  [Tooltip("Trigger 'Color cycle' on targets")]
  public bool ColorCycle = false;

  [Tooltip("Trigger 'Sequence test' on targets")]
  public bool SeqTests = false;

  // Services
  public IEventService Events { get; set; }
  public IDebugService Debug { get; set; }

  public void Awake()
  {
    Service.Registry.Bind(this);
  }

  public void Update()
  {
    if (Targets.Length > 0)
    {
      if (GoTiny)
      {
        GoTiny = false;
        var task = Promise();
        foreach (var t in Targets)
        {
          var action = Events.Prepare<GoTinyAction>();
          action.Configure(t);
          task.Add(action);
        }
        Events.Execute(task);
      }

      if (ColorCycle)
      {
        ColorCycle = false;
        var task = Promise();
        foreach (var t in Targets)
        {
          var action = Events.Prepare<ColorCycleAction>();
          action.Configure(t);
          task.Add(action);
        }
        Events.Execute(task);
      }

      if (SeqTests)
      {
        SeqTests = false;
        var task = Promise();
        foreach (var t in Targets)
        {
          var action = Events.Prepare<SeqTestAction>();
          action.Configure(t);
          task.Add(action);
        }
        Events.Execute(task, (ep) => { Debug.Log("All done~"); });
      }
    }
  }

  // Return a promise for all actions to use
  private CommandGroup Promise()
  {
    var task = new CommandGroup();
    task.OnCompleted((ep) => { Debug.Log("Completed all animations!"); });
    return task;
  }

  // Ui events
  public void TriggerGoTiny()
  {
    GoTiny = true;
  }

  public void TriggerSeqTests()
  {
    SeqTests = true;
  }

  public void TriggerColorCycle()
  {
    ColorCycle = true;
  }
}