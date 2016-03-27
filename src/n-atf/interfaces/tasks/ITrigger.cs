using NE = N.Package.Events;
using N.ATF.Internal;

namespace N.ATF
{
    /// Darthstore task which is executed when a condition is met.
    /// Triggers are executed in priority order.
    public interface ITrigger : IAction
    {
        /// The priority order (highest first) of this Trigger.
        int Priority { get; }
    }
}
