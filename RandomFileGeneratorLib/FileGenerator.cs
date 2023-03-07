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
        private ProgressConnector? _connector;

        public FileGenerator(IFileGeneratorOptions parsingTarget, ProgressConnector? connector = null)
        {
            _connector = connector;
            ParsingTarget = parsingTarget;
        }

        public IFileGeneratorOptions ParsingTarget { get; }
        public long TotalSize 
        { 
            get 
            {
                return ParsingTarget.FileSize();
            } 
        }


        public void Generate()
        {
            if (ParsingTarget == null)
            {
                throw new NullReferenceException(Constants.PARSING_TARGE_NULL);
            }
            if (ParsingTarget.Filename == null)
            {
                throw new NullReferenceException(Constants.FILE_NAME_NULL);
            }
            Generator gen = new Generator(ParsingTarget, _connector);
            var stream = new FileStream(ParsingTarget.Filename, FileMode.Create, FileAccess.Write);
            gen.Generate(stream, TotalSize);
            stream.Close();
        }

    }
}
