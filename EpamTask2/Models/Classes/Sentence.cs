using System.Collections.Generic;
using System.Text;
using EpamTask2.Enums;
using EpamTask2.Models.Interfaces;
using EpamTask2.Services.Workers;

namespace EpamTask2.Models.Classes
{
    public class Sentence : ISentence
    {
        private readonly List<ISentenceElement> _sententenceElements;
        private readonly IWordWorker _wordWorker;

        public Sentence()
        {
            _sententenceElements = new List<ISentenceElement>();
            _wordWorker = new WordWorker();
        }

        public int GetWordsCount()
        {
            var count = 0;
            foreach (var sentenceElement in _sententenceElements)
                if (sentenceElement.SentenceElementType == SentenceElementType.Word)
                    count++;
            return count;
        }

        public int GetElementsCount()
        {
            return _sententenceElements.Count;
        }

        public ISentenceElement GetElementByIndex(int index)
        {
            if (index < 0 || index >= _sententenceElements.Count) return null;
            return _sententenceElements[index];
        }

        public void DeleteWords(int wordLength)
        {
            for (int i = _sententenceElements.Count - 1; i >= 0; i--)
            {
                if (_sententenceElements[i].SentenceElementType == SentenceElementType.Word &&
                    _wordWorker.GetWordLength(_sententenceElements[i]) == wordLength &&
                     _wordWorker.FirstLetterIsConsonant(_sententenceElements[i]))
                {
                    _sententenceElements.Remove(_sententenceElements[i]);
                    i--;
                }
            }
                
        }

        public void ReplaceWords(int wordLength, string newValue)
        {
            foreach (var currentSentence in _sententenceElements)
                _wordWorker.ReplaceValue(wordLength, currentSentence, newValue);
        }

        public void AddElementToEnd(ISentenceElement element)
        {
            _sententenceElements.Add(element);
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.Append(_sententenceElements[0].Value);
            for (var i = 1; i < _sententenceElements.Count; i++)
            {
                if (_sententenceElements[i].SentenceElementType == SentenceElementType.Word) builder.Append(" ");
                builder.Append(_sententenceElements[i].Value);
            }

            return builder.ToString();
        }
    }
}