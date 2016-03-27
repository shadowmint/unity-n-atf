using NE = N.Package.Events;
using System.Collections.Generic;

namespace N.ATF.Internal
{
    /// Keep track of players and things
    public class DefaultEventService : IEventService
    {
        private NE.Timer timer;
        private NE.Actions actions;

        public DefaultEventService()
        {
            timer = new NE.Timer();
            actions = new NE.Actions(timer);
        }

        /// The game timer
        public NE.Timer Timer { get { return timer; } }

        /// The actions api for the whole game
        public NE.Actions Actions { get { return actions; } }

        /// Return the events api
        public NE.EventHandler Events { get { return timer.Events; } }
    }
}
