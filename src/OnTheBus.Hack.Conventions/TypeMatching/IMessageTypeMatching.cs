using System;

namespace OnTheBus.Hack.Conventions.TypeMatching
{
    public interface IMessageTypeMatching
    {
        bool IsMessageType(Type type);
    }
}