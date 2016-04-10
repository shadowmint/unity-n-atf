using N.Package.Bind;
using System.Linq;

namespace N.Package.ATF.Internal
{
    /// Darthstore service registry
    public class ServiceModule : IServiceModule, IServiceModuleFactory
    {
        /// Return self as module
        public IServiceModule Services { get { return this; } }

        // Register service instances
        // NB. The order these are registered in makes a big difference.
        public void Register(ServiceRegistry registry)
        {
            registry.Register<IDebugService, ConsoleDebug>();
            registry.Register<IEventService, DefaultEventService>();
            registry.Register<ITriggerService, DefaultTriggerService>();
            registry.Register<IFilterService, DefaultFilterService>();
        }
    }
}
