using UnityEngine;
using N.Package.ATF;
using N.Package.Events;

/// Trigger the 'MakeTiny' animation state on the target.
public class SeqTestAction : ActionTemplate
{
    public GameObject target;

    public override string Description { get { return "Run a bunch of animations"; } }

    public IEventService Events { get; set; }

    public override void Execute()
    {
        if (target != null)
        {
            var sequence = Events.Prepare<TriggerSequence>();

            N.Package.ATF.IAction action = new GoTinyAction();
            action.Configure(target);
            sequence.As<TriggerSequence>().Add(action);

            action = new ColorCycleAction();
            action.Configure(target);
            sequence.As<TriggerSequence>().Add(action);

            action = new GoTinyAction();
            action.Configure(target);
            sequence.As<TriggerSequence>().Add(action);

            sequence.OnComplete(() => { Complete(); });
            sequence.Execute();
        }
        else
        {
            Complete();
        }
    }

    // Configure with target game object
    public override bool Configure<T>(T instance)
    {
        if (instance is GameObject)
        {
            target = (GameObject) (object) instance;
            return true;
        }
        return false;
    }
}
