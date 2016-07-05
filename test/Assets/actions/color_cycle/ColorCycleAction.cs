using UnityEngine;
using N.Package.ATF;

/// Trigger the 'MakeTiny' animation state on the target.
public class ColorCycleAction : ActionTemplate
{
    public GameObject target;
    public Animator animator;

    public override string Description { get { return "Trigger the 'Color' animation state on the target"; } }

    /// Services
    public IEventService Events { get; set; }

    public override void Execute()
    {
        if (target != null)
        {
            animator = target.GetComponentInChildren<Animator>();
            animator.SetBool("Color", true);

            // When the animation state triggers a start event on this object, clear this event for that target.
            CompleteOnAnimationTrigger<ColorCycleTrigger>(target, AnimationTriggerType.START);
        }
        else
        {
            Complete();
        }
    }

    protected override void PreComplete()
    {
        if (animator != null)
        {
            animator.SetBool("Color", false);
        }
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
