
using OnTheBus.Hack.Conventions;

namespace OnTheBus.Hack.Client
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
            configuration.EndpointName(GetEndpointName());

            configuration.Conventions().MyDefaultConventions();

            configuration.UseTransport<RabbitMQTransport>();

            configuration.UsePersistence<InMemoryPersistence>();
        }

        private string GetEndpointName()
        {
            // TODO: Give your endpoint a unique name so they dont conflict with other peoples clients.
            throw new System.NotImplementedException();
            return "OnTheBus.Hack.JoeBlogsClient";
        }
    }
}
