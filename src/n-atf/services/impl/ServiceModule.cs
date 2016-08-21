using N.Package.Bind;

namespace N.Package.ATF.Internal
{
  /// Darthstore service registry
  public class ServiceModule : IServiceModule, IServiceModuleFactory
  {
    /// Return self as module
    public IServiceModule Services
    {
      get { return this; }
    }

    // Register service instances
    // NB. The order these are registered in makes a big difference.
    public void Register(ServiceRegistry registry)
    {
      registry.Register<IDebugService, Console>();
      registry.Register<IEventService, EventService>();
    }
  }
}