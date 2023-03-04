using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomFileGeneratorLib
{
    internal class Generator
    {
        IGenerator _generator; 

        public Generator(ParsingTarget options)
        {
            Options = options;
            switch (options.FileType)
            {
                case "text": _generator = new LoremIpsumGenerator(options); break;
                case "binary": _generator = new BinaryGenerator(); break;
            }
        }

        public ParsingTarget Options { get; }
        public IGenerator Gen { get; }

        public void Generate(Stream sink, long numberOfBytes)
        {
            float percent;
            if (numberOfBytes < Constants.MaxBlockSize)
            {
                _generator.Generate(sink, numberOfBytes);
            } else
            {
                var remaining = numberOfBytes;
                while (remaining > 0)
                {
                    percent = remaining / (float)numberOfBytes;
                    _generator.Generate(sink, Math.Min(Constants.MaxBlockSize, remaining));
                    remaining -= Constants.MaxBlockSize;
                    Console.WriteLine($"{percent}% complete, Remain bytes: {remaining}");
                }
            }
        }

    }
}
