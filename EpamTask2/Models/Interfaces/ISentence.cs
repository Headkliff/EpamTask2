namespace EpamTask2.Models.Interfaces
{
    public interface ISentence
    {
        int GetWordsCount();
        int GetElementsCount();
        ISentenceElement GetElementByIndex(int index);
        void DeleteWords(int wordLength);
        void ReplaceWords(int wordLength, string newValue);
    }
}