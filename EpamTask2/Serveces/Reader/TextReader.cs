using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EpamTask2.Serveces.Reader
{
    public class TextReader : IFileReader
    {
        private string _fileName;
        private string _bufLine = string.Empty;

        public TextReader(string fName)
        {
            this._fileName = fName;
        }

        public List<string> Read()
        {
            using (FileStream stream = new FileStream(_fileName, FileMode.Open))
            {
                List<string> result = new List<string>();

                using (StreamReader reader = new StreamReader(stream, Encoding.Default))
                {
                    string str = string.Empty;
                    while (!reader.EndOfStream)
                    {
                        str = reader.ReadLine();
                        result.AddRange(SplitText(str, reader.EndOfStream));
                    }

                    reader.Close();
                    return result;
                }
            }
        }

        private List<string> SplitText(string line, bool isLastLine)
        {
            line = string.Join(" ", _bufLine, line);
            List<string> sentences = new List<string>();
            string remained = line;

            while (remained.Length > 0)
            {
                int pointIndex = remained.IndexOf('.');
                int exlamationIndex = remained.IndexOf('!');
                int questionIndex = remained.IndexOf('?');

                if (pointIndex < 0 && exlamationIndex < 0 && questionIndex < 0)
                {
                    if (isLastLine)
                    {
                        sentences.Add(remained);
                    }
                    break;
                }

                var endOfSentence = (pointIndex < 0 ? remained.Length : pointIndex);

                if (exlamationIndex > -1 && exlamationIndex < endOfSentence)
                    endOfSentence = exlamationIndex;

                if (questionIndex > -1 && questionIndex < endOfSentence)
                    endOfSentence = questionIndex;
                
                sentences.Add(remained.Substring(0, endOfSentence + 1));
                remained = remained.Substring(endOfSentence + 1);
                _bufLine = remained;
            }

            return sentences;
        }

    }
}
