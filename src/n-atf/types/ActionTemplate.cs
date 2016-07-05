using UnityEngine;
using N.Package.Events;

namespace N.Package.ATF
{
    /// Generate completion delegate helper
    public delegate void ActionWaitHandler();

    /// This is a template or simple common action types
    public abstract class ActionTemplate : ExecutableTemplate, IAction
    {
    }
}
