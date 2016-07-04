using UnityEngine;
using N.Package.ATF;

/// Trigger the 'MakeTiny' animation state on the target.
public class ColorCycleAction : ActionTemplate
{
    public GameObject target;

    public override string Description { get { return "Trigger the 'Color' animation state on the target"; } }

    public override void Execute()
    {
        if (target != null)
        {
            var animator = target.GetComponentInChildren<Animator>();
            animator.SetBool("Color", true);

            var marker = target.AddComponent<ColorCycleMarker>();
            marker.action = this;
        }
        else
        {
            Completed();
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
