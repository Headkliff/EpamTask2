using EpamTask2.Enums;
using EpamTask2.Models.Interfaces;

namespace EpamTask2.Serveces.Workers
{
    public class PunctuationMarkWorker : IPunctuationMarkWorker
    {
        public bool IsQuestionMark(ISentenceElement element)
        {
            if (element.SentenceElementType == SentenceElementType.PunctuationMark)
            {
                if (element.Value.Equals("?"))
                {
                    return true;
                }

                return false;
            }

            return false;
        }
    }
}
