using System;
using N.Package.Command;

namespace N.Package.ATF
{
  public interface IEventService
  {
    /// Bind a command and then execute it
    void Execute(ICommand command);

    /// Bind a command, execute it and then do something
    void Execute(ICommand command, Action<CommandExecutedEvent> onComplete);
  }
}