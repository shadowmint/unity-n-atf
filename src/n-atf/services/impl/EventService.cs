using System;
using N.Package.Command;
using N.Package.Events;

namespace N.Package.ATF.Internal
{
  public class EventService : IEventService
  {
    public void Execute<T>(T command) where T : class, ICommand
    {
      Service.Registry.Bind(command);
      Handler<T>().Execute(command);
    }

    public void Execute<T>(T command, Action<CommandExecutedEvent> onComplete) where T : class, ICommand
    {
      Service.Registry.Bind(command);

      EventBinding<Command.CommandExecutedEvent> binding = null;
      binding = command.EventHandler.AddEventHandler<CommandExecutedEvent>((ep) =>
      {
        if (binding != null) binding.Dispose();
        onComplete(ep);
      });

      Handler<T>().Execute(command);
    }

    public IAction Prepare<T>() where T : class, IAction
    {
      var instance = Activator.CreateInstance<T>();
      Service.Registry.Bind(instance);
      return instance;
    }

    private static ICommandHandler<T> Handler<T>() where T : class, ICommand
    {
      var handler = Service.Registry.Resolve<ICommandHandler<T>>();
      if (handler == null)
      {
        throw new Exception(string.Format("No command handler bound to type: {0}", typeof(T).FullName));
      }
      return handler;
    }
  }
}