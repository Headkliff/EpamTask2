using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EpamTask2.Services.Reader
{
    public class TextReader : IFileReader
    {
        private string _bufLine = string.Empty;
        private readonly string _fileName;

        public TextReader(string fName)
        {
            _fileName = fName;
        }

        public List<string> Read()
        {
            using (var stream = new FileStream(_fileName, FileMode.Open))
            {
                var result = new List<string>();

                using (var reader = new StreamReader(stream, Encoding.Default))
                {
                    var str = string.Empty;
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
            var sentences = new List<string>();
            var remained = line;

            while (remained.Length > 0)
            {
                var pointIndex = remained.IndexOf('.');
                var exlamationIndex = remained.IndexOf('!');
                var questionIndex = remained.IndexOf('?');

                if (pointIndex < 0 && exlamationIndex < 0 && questionIndex < 0)
                {
                    if (isLastLine) sentences.Add(remained);
                    break;
                }

                var endOfSentence = pointIndex < 0 ? remained.Length : pointIndex;

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