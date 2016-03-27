using NE = N.Package.Events;
using N.ATF.Internal;

namespace N.ATF
{
    /// N.ATF task api; do a thing.
    public interface IAction : ITask, NE.IAction
    {
    }

    /// Something that can be configured
    public interface IConfiguredAction : IAction
    {
        /// Configure this action with T, if T is a supported type.
        /// @param config The configuration
        /// @return True if the configuration worked, and false otherwise.
        bool Configure<T>(T config);
    }
}
