using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomFileGeneratorLib
{
    public class FileGenerator
    {
        public FileGenerator(ParsingTarget parsingTarget)
        {
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
            Generator gen = new Generator(ParsingTarget);
            var stream = new FileStream(ParsingTarget.Filename, FileMode.Create, FileAccess.Write);
            gen.Generate(stream, TotalSize);
            stream.Close();
        }

    }
}
