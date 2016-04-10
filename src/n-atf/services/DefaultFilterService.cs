using N.Package.Events;
using System.Collections.Generic;
using N.Package.ATF.Utils;
using System.Linq;

namespace N.Package.ATF.Internal
{
    /// Sort and execute filters by type and priority
    public class DefaultFilterService : IFilterService
    {
        /// Currently debugging?
        private bool DEBUG = false;

        /// Services
        public IDebugService Debug { get; set; }

        /// Set of known trigger class types
        private Queue<System.Type> triggerTypes = new Queue<System.Type>();

        public DefaultFilterService()
        {
            foreach (var tt in Types.Find<IFilter>())
            {
                triggerTypes.Enqueue(tt);
            }
        }

        /// Process the target and return a logical AND of all the
        /// highest priority filters for the given target.
        /// @param U The filter type to invalid
        /// @param V The target to check
        public bool IsValid<U, V>(V target) where U : IFilter
        {
            var collection = Filters.Where(t => Types.Implements<U>(t))
                                    .Select(t => CreateInstance(t));

            var rtn = true;
            var priority = -1;
            foreach (var filter in collection)
            {
                if (filter.Priority > priority)
                {
                    rtn = filter.IsValid<V>(target);
                    priority = filter.Priority;
                    if (DEBUG) Debug.Log("{0} -> {1}, P{2}", filter.Description, rtn, priority);
                }
                else if (filter.Priority == priority)
                {
                    var old = rtn;
                    var valid = filter.IsValid<V>(target);
                    rtn = old && valid;
                    if (DEBUG) Debug.Log("{0} -> {1} && {2} -> {3} P{4}", filter.Description, old, valid, rtn, priority);
                }
            }

            return rtn;
        }

        /// Yield held trigger types
        public IEnumerable<System.Type> Filters
        { get { return triggerTypes; } }

        /// Make a new instance of T
        private IFilter CreateInstance(System.Type T)
        {
            object rtn = null;
            rtn = System.Activator.CreateInstance(T);
            Service.Registry.Bind(rtn);
            return rtn as IFilter;
        }
    }
}
