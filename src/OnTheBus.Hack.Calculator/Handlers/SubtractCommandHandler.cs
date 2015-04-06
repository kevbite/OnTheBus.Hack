using NServiceBus;
using OnTheBus.Hack.Calculator.Messages.Commands;
using OnTheBus.Hack.Calculator.Messages.Commands.Responses;
using OnTheBus.Hack.Calculator.Messages.Events;

namespace OnTheBus.Hack.Calculator.Handlers
{
    public class SubtractCommandHandler : IHandleMessages<SubtractCommand>
    {
        private readonly IBus _bus;

        public SubtractCommandHandler(IBus bus)
        {
            _bus = bus;
        }

        public void Handle(SubtractCommand message)
        {
            var result = message.Value1 - message.Value2;

            SendSubtractCommandResponse(result);

            RaiseSubtractedEvent(message, result);
        }

        private void RaiseSubtractedEvent(SubtractCommand message, decimal result)
        {
            _bus.Publish(new SubtractedEvent
            {
                Value1 = message.Value1,
                Value2 = message.Value2,
                Result = result
            });
        }

        private void SendSubtractCommandResponse(decimal result)
        {
            _bus.Reply(new SubtractCommandResponse { Result = result });
        }
    }
}
