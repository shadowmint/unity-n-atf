using System;
using N.Package.Command;

namespace N.Package.ATF.Internal
{
  public class EventService : IEventService
  {
    public void Execute(ICommand command)
    {
      Service.Registry.Bind(command);
      if (!command.CanExecute()) return;
      command.Execute();
    }

    public void Execute(ICommand command, Action<CommandExecutedEvent> onComplete)
    {
      Service.Registry.Bind(command);
      if (!command.CanExecute()) return;

      Action<CommandExecutedEvent> handler = null;
      handler = (ep) =>
      {
        command.EventHandler.RemoveEventHandler(handler);
        onComplete(ep);
      };

      command.EventHandler.AddEventHandler(handler);
      command.Execute();
    }
  }
}