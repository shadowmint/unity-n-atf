namespace N.ATF.Internal
{
    /// Common base for tasks
    public interface ITask
    {
        /// A human readable description of this task for debugging
        string Description { get; }
    }
}
