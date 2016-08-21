using N.Package.Command;
using UnityEngine;

public class GoTinyBehaviour : MonoBehaviour
{
  public float Duration = 0f;

  public float TargetScale = 0.5f;

  public float Elapsed;

  public GoTinyAction Action;

  public void Update()
  {
    var factor = Mathf.Clamp((Duration - Elapsed)/Duration, 0f, 1f);
    factor = TargetScale + (1.0f - TargetScale)*factor;
    gameObject.transform.localScale = Vector3.one*factor;
    Elapsed += Time.deltaTime;
    if (Elapsed > Duration)
    {
      Action.Completed();
      Destroy(this);
    }
  }
}