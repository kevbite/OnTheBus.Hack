using System;

namespace OnTheBus.Hack.Conventions.TypeMatching
{
    public class EventMessageTypeMatching : IEventMessageTypeMatching
    {
        private readonly IMessageTypeMatching _messageTypeMatching;

        public EventMessageTypeMatching(IMessageTypeMatching messageTypeMatching)
        {
            _messageTypeMatching = messageTypeMatching;
        }

        public bool IsEventType(Type type)
        {
            var isMessage = _messageTypeMatching.IsMessageType(type);
            var nameEndsWithEvent = type.Name.EndsWith("Event");

            return isMessage && nameEndsWithEvent;
        }
    }
}