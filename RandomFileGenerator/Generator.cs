using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomFileGenerator
{
    internal class Generator
    {
        const int _maxBlockSize = 32 * 1024 * 1024;
        IGenerator _generator; 

        public Generator(ParsingTarget options)
        {
            Options = options;
            switch (options.FileType)
            {
                case "text": _generator = new LoremIpsumGenerator(); break;
                case "binary": _generator = new BinaryGenerator(); break;
            }
        }

        public ParsingTarget Options { get; }
        public IGenerator Gen { get; }

        public void Generate(Stream sink, long numberOfBytes)
        {
            float percent;
            if (numberOfBytes < _maxBlockSize)
            {
                _generator.Generate(sink, numberOfBytes);
            } else
            {
                var remaining = numberOfBytes;
                while (remaining > 0)
                {
                    percent = remaining / (float)numberOfBytes;
                    _generator.Generate(sink, Math.Min( _maxBlockSize, remaining));
                    remaining -= _maxBlockSize;
                    Console.WriteLine($"{percent}% complete, Remain bytes: {remaining}");
                }
            }
        }

    }
}
