using UnityEngine;

public class ColorCycleEnd : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
  	{
        animator.SetBool("Color", false);

        // If there is a pending action, resolve it.
        var marker = animator.GetComponent<ColorCycleMarker>();
        if (marker != null)
        {
            marker.Completed();
        }
    }
}
