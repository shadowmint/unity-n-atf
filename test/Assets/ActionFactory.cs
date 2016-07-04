using UnityEngine;
using N.Package.ATF;

public class ActionFactory : MonoBehaviour
{
    [Tooltip("Drag an object here to select it")]
    public GameObject target;

    [Tooltip("Trigger 'Go Tiny' on target")]
    public bool goTiny = false;

    [Tooltip("Trigger 'Color cycle' on target")]
    public bool colorCycle = false;

    /// Services
    public IEventService Events { get; set; }

    public void Awake()
    {
        Service.Registry.Bind(this);
    }

    public void Update()
    {
        if (goTiny)
        {
            goTiny = false;
            var action = Events.Prepare<GoTinyAction>();
            action.Configure(target);
            action.Execute();
        }
        if (colorCycle)
        {
            colorCycle = false;
            var action = Events.Prepare<ColorCycleAction>();
            action.Configure(target);
            action.Execute();
        }
    }
}
