using System;
using N.Package.Command;

namespace N.Package.ATF
{
  public interface IEventService
  {
    /// Bind a command and then execute it
    void Execute<T>(T command) where T : class, ICommand;

    /// Bind a command, execute it and then do something
    void Execute<T>(T command, Action<CommandExecutedEvent> onComplete) where T : class, ICommand;

    /// Bind a command but return it instead of executing it.
    IAction Prepare<T>() where T : class, IAction;
  }
}