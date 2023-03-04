using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomFileGenerator
{
    internal class FileGenerator
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
                switch (ParsingTarget.Unit)
                {
                    case "B":
                    case "b": return ParsingTarget.Size;
                    case "K":
                    case "k": return ParsingTarget.Size * 1024;
                    case "M":
                    case "m": return ParsingTarget.Size * 1024 * 1024;
                    case "G":
                    case "g": return ParsingTarget.Size * 1024 * 1024 * 1024;
                }
                return ParsingTarget.Size;
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
