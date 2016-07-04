using UnityEngine;
using N.Package.ATF;

/// Trigger the 'MakeTiny' animation state on the target.
public class GoTinyAction : ActionTemplate
{
    public GameObject target;

    public override string Description { get { return "Trigger the 'Tiny' state on the target"; } }

    public override void Execute()
    {
        if (target != null)
        {
            var instance = target.AddComponent<GoTinyBehaviour>();
            instance.action = this;
            instance.duration = 2f;
        }
        else
        {
            Complete();
        }
    }

    // Run this when the action completes
    public void Completed()
    {
        Complete();
    }

    // Configure with target game object
    public override bool Configure<T>(T instance)
    {
		    if (instance.GetType() == typeof(GameObject))
        {
            target = (GameObject) (object) instance;
            return true;
        }
        return false;
    }
}
