using System;

namespace OnTheBus.Hack.Conventions.TypeMatching
{
    public class CommandMessageTypeMatching : ICommandMessageTypeMatching
    {
        private readonly IMessageTypeMatching _messageTypeMatching;

        public CommandMessageTypeMatching(IMessageTypeMatching messageTypeMatching)
        {
            _messageTypeMatching = messageTypeMatching;
        }

        public bool IsCommandType(Type type)
        {
            var isMessage = _messageTypeMatching.IsMessageType(type);
            var nameEndsWithCommand = type.Name.EndsWith("Command");

            return isMessage && nameEndsWithCommand;
        }
    }
}