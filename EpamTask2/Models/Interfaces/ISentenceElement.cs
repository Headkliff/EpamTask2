using EpamTask2.Enums;

namespace EpamTask2.Models.Interfaces
{
    public interface ISentenceElement
    {
        string Value { get; set; }
        SentenceElementType SentenceElementType { get; }
    }
}