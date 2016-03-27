using N.Package.Bind;
using N.ATF.Internal;
using N.ATF.Utils;
using System.Linq;

namespace N.ATF
{
    /// Darthstore service registry
    public class Service
    {
        private static ServiceRegistry registry;
        public static ServiceRegistry Registry
        {
            get
            {
                if (registry == null)
                { Service.Rebuild(); }
                return registry;
            }
        }

        // Clear and rebuild.
        // Notice this does not do the same thing as Registry.Reset();
        // The default service modules are attached after running this.
        // Service modules are loaded in no particular order. Avoid binds.
        public static void Rebuild()
        {
            registry = new ServiceRegistry();
            foreach (var item in Types.Spawn<IServiceModuleFactory>())
            { registry.Register(item.Services); }
        }
    }
}
