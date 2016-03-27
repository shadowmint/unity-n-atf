using NE = N.Package.Events;

namespace N.ATF
{
    /// Delegate for multiple type filters
    public delegate bool FilterTemplateDelegate<T>(T target);

    /// This is a template or simple common Filter types
    public abstract class FilterTemplate : IFilter
    {
        /// Provide a description for all actions
        public abstract string Description { get; }

        /// The priority for this Filter
        public abstract int Priority { get; }

        /// Setup filters in the registry
        /// Run the Filter
        public abstract bool IsValid<T>(T target);

        /// Check if a type matches
        protected bool Is<U, V>()
        { return typeof(U) == typeof(V); }
    }

}
