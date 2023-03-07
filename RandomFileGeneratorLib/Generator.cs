using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RandomFileGeneratorLib.Connectors;

namespace RandomFileGeneratorLib
{
    internal class Generator
    {
        IGenerator? _generator;
        Connector? _connector;

        public Generator(IFileGeneratorOptions options, Connector? connector = null)
        {
            _connector = connector;
            Options = options;
            switch (options.FileType)
            {
                case "text":
                    {
                        // TODO: we will select different generators here
                        _generator = new TextGenerator(new LoremIpsumParagraphGenerator(options)); break;
                    } 
                case "binary": _generator = new BinaryGenerator(options.Zeros); break;
            }
        }

        public IFileGeneratorOptions Options { get; }
        public IGenerator Gen { get; }

        public void Generate(Stream sink, long numberOfBytes)
        {
            float percent;
            if (numberOfBytes < Constants.MaxBlockSize)
            {
                _generator?.Generate(sink, numberOfBytes);
            } else
            {
                var remaining = numberOfBytes;
                while (remaining > 0)
                {
                    percent = remaining / (float)numberOfBytes;
                    if (_connector != null)
                    {
                        _connector.Send(new ProgressMessage((1.0f - percent) * 100));
                    }
                    _generator?.Generate(sink, Math.Min(Constants.MaxBlockSize, remaining));
                    remaining -= Constants.MaxBlockSize;
                }
            }
        }

    }
}
