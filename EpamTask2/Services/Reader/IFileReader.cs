using System.Collections.Generic;

namespace EpamTask2.Services.Reader
{
    public interface IFileReader
    {
        List<string> Read();
    }
}