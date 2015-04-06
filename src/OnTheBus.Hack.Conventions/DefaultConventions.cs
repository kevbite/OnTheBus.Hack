using NServiceBus;
using OnTheBus.Hack.Conventions.TypeMatching;

namespace OnTheBus.Hack.Conventions
{
    public static class DefaultConventions
    {
        private static readonly IMessageTypeMatching MessageTypeMatching;
        private static readonly ICommandMessageTypeMatching CommandMessageTypeMatching;
        private static readonly IEventMessageTypeMatching EventMessageTypeMatching;

        static DefaultConventions()
        {
            MessageTypeMatching = new MessageTypeMatching();
            CommandMessageTypeMatching = new CommandMessageTypeMatching(MessageTypeMatching);
            EventMessageTypeMatching = new EventMessageTypeMatching(MessageTypeMatching);
        }

        public static ConventionsBuilder MyDefaultConventions(this ConventionsBuilder conventionsBuilder)
        {
            conventionsBuilder = conventionsBuilder.DefiningMessagesAs(MessageTypeMatching.IsMessageType);
            conventionsBuilder = conventionsBuilder.DefiningCommandsAs(CommandMessageTypeMatching.IsCommandType);
            conventionsBuilder = conventionsBuilder.DefiningEventsAs(EventMessageTypeMatching.IsEventType);

            return conventionsBuilder;
        }
    }
}
