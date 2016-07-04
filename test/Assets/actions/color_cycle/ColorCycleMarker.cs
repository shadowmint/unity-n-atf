using UnityEngine;

/// Helper class to allow a state machine behaviour to find its associated action
public class ColorCycleMarker : MonoBehaviour
{
    public ColorCycleAction action;

    public void Completed()
    {
        action.Completed();
        GameObject.Destroy(this);
    }
}
