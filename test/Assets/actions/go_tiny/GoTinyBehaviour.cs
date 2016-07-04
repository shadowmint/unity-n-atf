using UnityEngine;

public class GoTinyBehaviour : MonoBehaviour
{
    public float duration = 0f;

    public float targetScale = 0.5f;

    public float elapsed;

    public GoTinyAction action;

    public void Update()
    {
        var factor = Mathf.Clamp((duration - elapsed) / duration, 0f, 1f);
        factor = targetScale + (1.0f - targetScale) * factor;
        gameObject.transform.localScale = Vector3.one * factor;
        elapsed += Time.deltaTime;
        if (elapsed > duration)
        {
            action.Completed();
            GameObject.Destroy(this);
        }
    }
}
