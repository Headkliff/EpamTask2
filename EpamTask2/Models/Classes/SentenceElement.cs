using EpamTask2.Enums;
using EpamTask2.Models.Interfaces;

namespace EpamTask2.Models.Classes
{
    public class SentenceElement : ISentenceElement
    {
        public SentenceElement(string sentenceElementValue, SentenceElementType type)
        {
            Value = sentenceElementValue;
            SentenceElementType = type;
        }

        public string Value { get; set; }
        public SentenceElementType SentenceElementType { get; }
    }
}