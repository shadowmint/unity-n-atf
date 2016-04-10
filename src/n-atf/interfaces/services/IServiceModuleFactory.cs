using NE = N.Package.Events;
using N.Package.Bind;

namespace N.Package.ATF
{
    /// Implement this to register services from other packages.
    public interface IServiceModuleFactory
    {
        /// Return a module to register
        IServiceModule Services { get; }
    }
}
