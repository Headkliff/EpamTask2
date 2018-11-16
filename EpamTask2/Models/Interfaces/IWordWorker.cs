namespace EpamTask2.Models.Interfaces
{
    public interface IWordWorker
    {
        int GetWordLength(ISentenceElement element);
        bool FirstLetterIsConsonant(ISentenceElement element);
        void ReplaceValue(int wordLenght, ISentenceElement element, string newValue);
    }
}
