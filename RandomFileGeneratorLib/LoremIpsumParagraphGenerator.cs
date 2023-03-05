using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RandomFileGeneratorLib
{


    internal class LoremIpsumParagraphGenerator : IGenerator
    {
        private readonly ParsingTarget _options;
        private readonly LoremIpsumGenerator _paragraphGenerator = new LoremIpsumGenerator();

        public LoremIpsumParagraphGenerator(ParsingTarget options)
        {
            _options = options;
        }

        public void Generate(Stream sink, long numberOfBytes)
        {
            if (_options.Paragraphize)
            {
                GenerateParagraphs(sink, numberOfBytes);
            } else
            {
                GenerateWords(sink, numberOfBytes);
            }

        }

        private void GenerateParagraphs(Stream sink, long numberOfBytes)
        {
            Random random = new Random((int)DateTime.Now.Ticks);
            var minWords = _options.MinPAragraphSize;
            var maxWords = _options.MaxPAragraphSize;
            long bytesGenerated = 0;
            StreamWriter sw = new StreamWriter(sink);
            while (bytesGenerated < numberOfBytes)
            {
                var words = random.Next(minWords, maxWords);
                var paragraph = _paragraphGenerator.CreateParagraph(words) + "\n\n";
                if (paragraph.Length > (numberOfBytes - bytesGenerated))
                {
                    paragraph = paragraph.Substring(0, (int)(numberOfBytes - bytesGenerated));
                }
                sw.Write(paragraph);
                bytesGenerated += paragraph.Length;
            }
            sw.Flush();
        }

        private void GenerateWords(Stream sink, long numberOfBytes)
        {
            long bytesGenerated = 0;
            StreamWriter sw = new StreamWriter(sink);
            while (bytesGenerated < numberOfBytes)
            {
                var word = _paragraphGenerator.SingleWord();
                sw.Write(word + " ");
                bytesGenerated += word.Length + 1;
            }
            sw.Flush();
        }

    }
}
