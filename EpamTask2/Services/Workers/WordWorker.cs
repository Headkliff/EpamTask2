using System.Text.RegularExpressions;
using EpamTask2.Enums;
using EpamTask2.Models.Interfaces;

namespace EpamTask2.Services.Workers
{
    public class WordWorker : IWordWorker
    {
        public int GetWordLength(ISentenceElement element)
        {
            return element.Value.Length;
        }

        public bool FirstLetterIsConsonant(ISentenceElement element)
        {
            var pattern = @"[aeiou]";
            if (element.SentenceElementType == SentenceElementType.Word)
            {
                if (!string.IsNullOrEmpty(element.Value) &&
                    !(Regex.Matches(element.Value[0].ToString(), pattern).Count > 0)) return true;

                return false;
            }

            return false;
        }

        public void ReplaceValue(int wordLength, ISentenceElement element, string newValue)
        {
            if (element.SentenceElementType == SentenceElementType.Word && GetWordLength(element) == wordLength)
                element.Value = newValue;
        }
    }
}