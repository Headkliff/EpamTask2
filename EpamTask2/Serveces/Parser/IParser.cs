using System.Collections.Generic;

namespace EpamTask2.Serveces.Parser
{
    public interface IParser <T>
    {
        T Parse(List<string> str);
    }
}
