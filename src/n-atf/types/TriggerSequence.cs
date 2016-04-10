using N.Package.Events;

namespace N.Package.ATF
{
    public class TriggerSequence : ActionSequence, IAction
    {
        public string Description { get { return "A sequence of triggered tasks"; } }
        public bool Configure<T>(T config)
        { return false; }
    }
}
