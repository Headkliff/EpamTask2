namespace EpamTask2.Models.Interfaces
{
    public interface ISentence
    {
        int GetWordsCount();
        int GetElementsCount();
        ISentenceElement GetElementByIndex(int index);
        void DeleteWords(int wordLenght);
        void ReplaceWords(int wordLenght, string newValue);
    }
}
