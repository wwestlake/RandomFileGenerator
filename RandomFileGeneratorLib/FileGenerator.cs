using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RandomFileGeneratorLib.Connectors;

namespace RandomFileGeneratorLib
{
    public class FileGenerator
    {
        private ProgressConnector _connector;

        public FileGenerator(ParsingTarget parsingTarget, ProgressConnector connector = null)
        {
            _connector = connector;
            ParsingTarget = parsingTarget;
        }

        public ParsingTarget ParsingTarget { get; }
        public long TotalSize 
        { 
            get 
            {
                return ParsingTarget.FileSize();
            } 
        }


        public void Generate()
        {
            Generator gen = new Generator(ParsingTarget, _connector);
            var stream = new FileStream(ParsingTarget.Filename, FileMode.Create, FileAccess.Write);
            gen.Generate(stream, TotalSize);
            stream.Close();
        }

    }
}
