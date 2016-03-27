using System.Collections.Generic;
using NE = N.Package.Events;

namespace N.ATF
{
    /// Global triggers api
    public interface IFilterService
    {
        /// Check if the target is valid given the filter type.
        bool IsValid<U, V>(V target) where U : IFilter;

        /// Iterate over the set of types this system is aware of
        IEnumerable<System.Type> Filters { get; }
    }

    /// Helpers
    public static class IFilterServiceHelpers
    {
        /// Check if the trigger system knows about a specific trigger type
        /// Mostly useful for debugging.
        public static bool HasFilter<T>(this IFilterService self)
        {
            foreach (var t in self.Filters)
            {
                if (t == typeof(T))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
