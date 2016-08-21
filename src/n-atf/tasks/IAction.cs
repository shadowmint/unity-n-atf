using N.Package.Command;

namespace N.Package.ATF
{
  /// N.Package.ATF task api; do a thing.
  public interface IAction : ICommand
  {
    /// A human readable description of this task for debugging
    string Description { get; }

    /// Configure this action with T, if T is a supported type.
    /// @param config The configuration
    /// @return True if the configuration worked, and false otherwise.
    bool Configure<T>(T config);
  }
}