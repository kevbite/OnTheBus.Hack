using System;

namespace OnTheBus.Hack.Conventions.TypeMatching
{
    public interface ICommandMessageTypeMatching
    {
        bool IsCommandType(Type type);
    }
}