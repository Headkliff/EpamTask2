using System;
using System.Collections.Generic;
using EpamTask2.Models.Classes;
using EpamTask2.Services.Parser;
using EpamTask2.Services.Reader;

namespace EpamTask2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var line = "=============================================================";
            IFileReader r = new TextReader("input.txt");
            var listSentences = new List<string>();
            IParser<Text> parser = new TextParser();
            listSentences = r.Read();
            var text = parser.Parse(listSentences);

            ///1 Вывести все предложения заданного текста в порядке возрастания количества слов в каждом из них.
            foreach (var item in text.SortSentences()) Console.WriteLine(item);
            Console.WriteLine(line);

            ///2 Во всех вопросительных предложениях текста найти и напечатать без повторений слова заданной длины.
            var result = text.FindWordsOByLength(text, wordLength:3);
            foreach (var item in result) Console.WriteLine(item);
            Console.WriteLine(line);

            ///3 Из текста удалить все слова заданной длины, начинающиеся на согласную букву.
            text.RemoveWords(wordLength:3);
            Console.WriteLine(text);
            Console.WriteLine(line);

            ///4 В некотором предложении текста слова заданной длины заменить указанной подстрокой, 
            ///длина которой может не совпадать с длиной слова.

            text.ReplaceWords(indexSentense:0, wordLength:3, newValue:"I love programming on C#");
            Console.WriteLine(text);
            Console.WriteLine(line);

            Console.ReadKey();
        }
    }
}