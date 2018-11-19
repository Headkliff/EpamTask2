using System.Collections.Generic;

namespace EpamTask2.Services.Parser
{
    public interface IParser<T>
    {
        T Parse(List<string> str);
    }
}