using NE = N.Package.Events;

namespace N.Package.ATF
{
    /// This is a template or simple common trigger types
    public abstract class TriggerTemplate : ExecutableTemplate, ITrigger
    {
        /// The priority for this trigger
        public abstract int Priority { get; }
    }
}
