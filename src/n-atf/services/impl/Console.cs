namespace N.Package.ATF.Internal
{
  public class Console : IDebugService
  {
    /// Log a message
    public void Log(string format, params object[] args)
    {
      var msg = string.Format(format, args);
      Core.Console.Log(msg);
    }

    /// Log a message
    public void Log(object target)
    {
      Core.Console.Log(target);
    }
  }
}