using UnityEngine;
using N.Package.ATF;

public class ActionFactory : MonoBehaviour
{
  [Tooltip("Drag an object here to select it")]
  public GameObject[] targets;

  [Tooltip("Trigger 'Go Tiny' on targets")]
  public bool goTiny = false;

  [Tooltip("Trigger 'Color cycle' on targets")]
  public bool colorCycle = false;

  [Tooltip("Trigger 'Sequence test' on targets")]
  public bool seqTests = false;

  public void Awake()
  {
    Service.Registry.Bind(this);
  }

  public void Update()
  {
    if (targets.Length > 0)
    {
      if (goTiny)
      {
        goTiny = false;
        for (var i = 0; i < targets.Length; ++i)
        {
          var action = new GoTinyAction();
          action.Configure(targets[i]);
          action.Execute();
        }
      }
      if (colorCycle)
      {
        colorCycle = false;
        for (var i = 0; i < targets.Length; ++i)
        {
          var action = new ColorCycleAction();
          action.Configure(targets[i]);
          action.Execute();
        }
      }
      if (seqTests)
      {
        seqTests = false;
        for (var i = 0; i < targets.Length; ++i)
        {
          var action = new SeqTestAction();
          action.Configure(targets[i]);
          action.Execute();
        }
      }
    }
  }

  // Ui events
  public void TriggerGoTiny()
  {
    goTiny = true;
  }

  public void TriggerSeqTests()
  {
    seqTests = true;
  }

  public void TriggerColorCycle()
  {
    colorCycle = true;
  }
}