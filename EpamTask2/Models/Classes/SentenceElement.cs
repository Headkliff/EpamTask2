using EpamTask2.Enums;
using EpamTask2.Models.Interfaces;

namespace EpamTask2.Models.Classes
{
    public class SentenceElement : ISentenceElement
    {
        public string Value { get; set; }
        public SentenceElementType SentenceElementType { get; } 

        public SentenceElement(string sentenceElementValue, SentenceElementType type)
        {
            this.Value = sentenceElementValue;
            this.SentenceElementType = type;
        }

    }
}
