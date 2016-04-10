using NE = N.Package.Events;
using N.Package.ATF.Internal;

namespace N.Package.ATF
{
    /// N.Package.ATF task api; do a thing.
    public interface IAction : ITask, NE.IAction
    {
        /// Configure this action with T, if T is a supported type.
        /// @param config The configuration
        /// @return True if the configuration worked, and false otherwise.
        bool Configure<T>(T config);
    }
}
