using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileGeneration.Models
{
    public class TextFile : FileDetails
    {
        public TextFileContents Contents { get; set; }
        public TextFileFormat Format { get; set; }

        public bool Paragraphs { get; set; }

        public int MinParagraphWords { get; set; }
        public int MaxParagraphWords { get; set; }

        public override void GenerateFile()
        {
            throw new NotImplementedException();
        }
    }
}
