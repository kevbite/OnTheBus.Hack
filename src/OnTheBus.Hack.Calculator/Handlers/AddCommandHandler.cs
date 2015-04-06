using NServiceBus;
using OnTheBus.Hack.Calculator.Messages.Commands;
using OnTheBus.Hack.Calculator.Messages.Commands.Responses;
using OnTheBus.Hack.Calculator.Messages.Events;

namespace OnTheBus.Hack.Calculator.Handlers
{
    public class AddCommandHandler : IHandleMessages<AddCommand>
    {
        private readonly IBus _bus;

        public AddCommandHandler(IBus bus)
        {
            _bus = bus;
        }

        public void Handle(AddCommand message)
        {
            var result = message.Value1 + message.Value2;

            SendAddCommandResponse(result);

            RaiseAddedEvent(message, result);
        }

        private void RaiseAddedEvent(AddCommand message, decimal result)
        {
            _bus.Publish(new AddedEvent
            {
                Value1 = message.Value1,
                Value2 = message.Value2,
                Result = result
            });
        }

        private void SendAddCommandResponse(decimal result)
        {
            _bus.Reply(new AddCommandResponse{Result = result});
        }
    }
}
