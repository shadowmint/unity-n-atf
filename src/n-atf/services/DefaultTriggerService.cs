using N.Package.Events;
using System.Collections.Generic;
using N.Package.ATF.Utils;
using System.Linq;

namespace N.Package.ATF.Internal
{
    /// Sort and execute triggers by type and priority
    public class DefaultTriggerService : ITriggerService
    {
        /// Events api
        private IEventService events;
        public IEventService Events { set { events = value; } }

        /// Set of known trigger class types
        private Queue<System.Type> triggerTypes = new Queue<System.Type>();

        public DefaultTriggerService()
        {
            foreach (var tt in Types.Find<ITrigger>())
            {
                triggerTypes.Enqueue(tt);
            }
        }

        /// Yield held trigger types
        public IEnumerable<System.Type> Triggers
        { get { return triggerTypes; } }

        /// Trigger a specific type of trigger.
        public void Trigger<T>() where T : ITrigger
        {
            Trigger<T, int>(0);
        }

        /// Trigger a specific type of trigger.
        public void Trigger<T, TConfig>(TConfig config) where T : ITrigger
        {
            var collection = Triggers.Where(t => Types.Implements<T>(t))
                                     .Select(t => CreateInstance(t));

            var task = new ActionSequence();
            foreach (var trigger in collection.OrderByDescending(action => action.Priority))
            {
                trigger.Configure(config);
                task.Add(trigger);
            }

            events.Actions.Execute(task);
        }

        /// Trigger a specific type of trigger.
        public PreparedAction Prepare<T>() where T : ITrigger
        {
            return Prepare<T, int>(0);
        }

        /// Trigger a specific type of trigger.
        public PreparedAction Prepare<T, TConfig>(TConfig config) where T : ITrigger
        {
            var collection = Triggers.Where(t => Types.Implements<T>(t))
                                     .Select(t => CreateInstance(t));

            var task = new TriggerSequence();
            foreach (var trigger in collection.OrderByDescending(action => action.Priority))
            { task.Add(trigger); }

            return new PreparedAction(task, events);
        }

        /// Make a new instance of T
        private ITrigger CreateInstance(System.Type T)
        {
            object rtn = null;
            rtn = System.Activator.CreateInstance(T);
            Service.Registry.Bind(rtn);
            return rtn as ITrigger;
        }
    }
}
