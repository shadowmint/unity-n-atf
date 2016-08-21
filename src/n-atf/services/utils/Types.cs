using System.Collections.Generic;
using N.Package.Bind;
using N.Package.ATF;

namespace N.Package.ATF.Utils
{
    public class Types
    {
        /// Find all classes that implement T and spawn instances
        /// The spawned instance is automatically bound.
        public static IEnumerable<T> Spawn<T>() where T : class
        {
            var method = typeof(ServiceRegistry).GetMethod("CreateInstance");
            foreach (var t in Types.Find<T>())
            {
                var generic = method.MakeGenericMethod(t);
                yield return generic.Invoke(Service.Registry, null) as T;
            }
        }

        /// Find all classes with the interface T
        public static IEnumerable<System.Type> Find<T>() where T : class
        {
            foreach (var currentAssembly in System.AppDomain.CurrentDomain.GetAssemblies())
            {
                var types = currentAssembly.GetTypes();
                foreach (var type in types)
                {
                    if (Types.Implements<T>(type))
                    {
                        yield return type;
                    }
                }
            }
        }

        /// Check if a type implements an interface
        /// Also requires IsPublic and the implementer is not an interface.
        public static bool Implements<T>(System.Type type)
        {
            return typeof(T).IsAssignableFrom(type) && type.IsPublic && !type.IsInterface && !type.IsAbstract;
        }
    }
}
