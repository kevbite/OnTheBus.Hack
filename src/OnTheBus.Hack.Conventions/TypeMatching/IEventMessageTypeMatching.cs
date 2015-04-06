using System;

namespace OnTheBus.Hack.Conventions.TypeMatching
{
    public interface IEventMessageTypeMatching
    {
        bool IsEventType(Type type);
    }
}