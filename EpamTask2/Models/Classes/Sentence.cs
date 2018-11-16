using System.Collections.Generic;
using System.Text;
using EpamTask2.Enums;
using EpamTask2.Models.Interfaces;
using EpamTask2.Serveces.Workers;

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

        public void AddElementToEnd(ISentenceElement element)
        {
            _sententenceElements.Add(element);
        }

        public int GetWordsCount()
        {
            int count = 0;
            foreach (var sentenceElement in _sententenceElements)
            {
                if (sentenceElement.SentenceElementType == SentenceElementType.Word)
                {
                    count++;
                }
            }
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


        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(_sententenceElements[0].Value);
            for (int i = 1; i < _sententenceElements.Count; i++)
            {
                if (_sententenceElements[i].SentenceElementType == SentenceElementType.Word)
                {
                    builder.Append(" ");
                }
                builder.Append(_sententenceElements[i].Value);
            }
            return builder.ToString();
        }

        public void DeleteWords(int wordLenght)
        {
            for (int i = 0; i < _sententenceElements.Count; i++)
            {
                if (_sententenceElements[i].SentenceElementType == SentenceElementType.Word
                    && _wordWorker.GetWordLength(_sententenceElements[i]) == wordLenght
                    && _wordWorker.FirstLetterIsConsonant(_sententenceElements[i]))
                {
                    _sententenceElements.Remove(_sententenceElements[i]);
                    i--;
                }
            }
        }

        public void ReplaceWords(int wordLenght, string newValue)
        {
            foreach (var currentSentence in _sententenceElements)
            {
                _wordWorker.ReplaceValue(wordLenght, currentSentence, newValue);
            }
        }
    }
}
