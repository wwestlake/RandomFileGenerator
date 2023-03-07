using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomFileGeneratorLib
{
    public class TextGenerator : IGenerator
    {
        private IGenerator _generator;

        public TextGenerator(IGenerator generator)
        {
            _generator = generator;
        }

        public void Generate(Stream sink, long numberOfBytes)
        {
            _generator.Generate(sink, numberOfBytes);
        }

    }
}
