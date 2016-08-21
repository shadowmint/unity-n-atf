using N.Package.Bind;
using N.Package.ATF.Utils;

namespace N.Package.ATF
{
  /// Darthstore service registry
  public class Service
  {
    private static ServiceRegistry _registry;

    public static ServiceRegistry Registry
    {
      get
      {
        if (_registry == null)
        {
          Rebuild();
        }
        return _registry;
      }
    }

    // Clear and rebuild.
    // Notice this does not do the same thing as Registry.Reset();
    // The default service modules are attached after running this.
    // Service modules are loaded in no particular order. Avoid binds.
    public static void Rebuild()
    {
      _registry = new ServiceRegistry();
      foreach (var item in Types.Spawn<IServiceModuleFactory>())
      {
        _registry.Register(item.Services);
      }
    }
  }
}