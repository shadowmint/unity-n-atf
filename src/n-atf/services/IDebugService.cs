namespace N.Package.ATF
{
  public interface IDebugService
  {
    /// Log a message
    void Log(string format, params object[] args);

    /// Log a message
    void Log(object target);
  }
}