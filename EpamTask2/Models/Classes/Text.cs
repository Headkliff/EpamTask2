using System;
using System.Collections.Generic;
using System.Linq;
using EpamTask2.Enums;
using EpamTask2.Models.Interfaces;
using EpamTask2.Services.Workers;

namespace EpamTask2.Models.Classes
{
    public class Text
    {
        private readonly IPunctuationMarkWorker _punctuationMarkWorker;
        private readonly IWordWorker _wordWorker;
        private readonly List<ISentence> _sentences;

        public Text()
        {
            _sentences = new List<ISentence>();
            _wordWorker = new WordWorker();
            _punctuationMarkWorker = new PunctuationMarkWorker();
        }

        public void AddSentence(ISentence sentence)
        {
            _sentences.Add(sentence);
        }

        public IEnumerable<ISentence> SortSentences()
        {
            return _sentences.OrderBy(x => x.GetWordsCount());
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, _sentences);
        }

        public List<ISentence> GetQuestionSentences()
        {
            var questionSentences = new List<ISentence>();
            foreach (var currentSentence in _sentences)
            {
                var count = currentSentence.GetElementsCount();
                var currentElement = currentSentence.GetElementByIndex(count - 1);
                if (currentElement == null) continue;
                if (_punctuationMarkWorker.IsQuestionMark(currentElement)) questionSentences.Add(currentSentence);
            }

            return questionSentences;
        }

        public void RemoveWords(int wordLength)
        {
            foreach (var currentSentence in _sentences) currentSentence.DeleteWords(wordLength);
        }

        public void ReplaceWords(int indexSentense, int wordLength, string newValue)
        {
            if (_sentences != null)
            {
                var currentSentence = _sentences[indexSentense];

                currentSentence?.ReplaceWords(wordLength, newValue);
            }
        }

        public IList<string> FindWordsOByLength(Text text, int wordLength)
        {
            var words = new List<string>();
            foreach (var currentSentence in text.GetQuestionSentences())
                for (var i = 0; i < currentSentence.GetWordsCount(); i++)
                {
                    var currentElement = currentSentence.GetElementByIndex(i);
                    if (currentElement.SentenceElementType == SentenceElementType.Word
                        && _wordWorker.GetWordLength(currentElement) == wordLength)
                    {
                        var str = currentElement.Value.ToUpper();

                        if (!words.Contains(str)) words.Add(str);
                    }
                }

            return words.ToList();
        }
    }
}