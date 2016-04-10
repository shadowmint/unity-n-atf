using NE = N.Package.Events;
using N.Package.ATF.Internal;

namespace N.Package.ATF
{
    /// A filter maps over a target and either rejects or accepts it based on conditions.
    public interface IFilter : ITask
    {
        /// The priority order (highest precidence) of this Filter.
        int Priority { get; }

        /// Evaluate a target and return true/false based on if it is valid.
        /// eg. Is a target targetable, etc.
        bool IsValid<T>(T target);
    }
}
