using OnTheBus.Hack.Conventions;

namespace OnTheBus.Hack.Calculator
{
    using NServiceBus;

    /*
		This class configures this endpoint as a Server. More information about how to configure the NServiceBus host
		can be found here: http://particular.net/articles/the-nservicebus-host
	*/
    public class EndpointConfig : IConfigureThisEndpoint
    {
        public void Customize(BusConfiguration configuration)
        {
            configuration.Conventions().MyDefaultConventions();

            configuration.UseTransport<RabbitMQTransport>();

            configuration.UsePersistence<InMemoryPersistence>();
        }
    }
}
