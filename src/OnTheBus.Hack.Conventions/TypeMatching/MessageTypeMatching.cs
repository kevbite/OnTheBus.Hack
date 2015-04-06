using System;
using System.Linq;

namespace OnTheBus.Hack.Conventions.TypeMatching
{
    public class MessageTypeMatching : IMessageTypeMatching
    {
        public bool IsMessageType(Type type)
        {
            var validMessageNamespaces = new[] {"Messages", "InternalMessages"};

            bool isInMessageNamespace = false;
            if (type.Namespace != null)
            {
                isInMessageNamespace  = type.Namespace.Split('.').Any(validMessageNamespaces.Contains);
            }

            return isInMessageNamespace;
        }
    }
}