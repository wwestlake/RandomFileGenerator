using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileGeneratorGui.Types;

namespace FileGeneratorGui.Models
{
    public class TextFile : FileModelBase
    {
        public TextFile(string? folder, string? fileName, string? description, 
            long size, TextFileContents contents, TextFileFormat format, bool paragraphs,
            int minParagraphWords, int maxParagraphWords, int blockSize) : base(folder, fileName, description, size, blockSize)
        {
            Id = Guid.NewGuid();
            Contents = contents;
            Format = format;
            Paragraphs = paragraphs;
            MinParagraphWords = minParagraphWords;
            MaxParagraphWords = maxParagraphWords;
            BlockSize = blockSize;

        }

        public Guid Id { get; set; }
        public TextFileContents Contents { get; set; }
        public TextFileFormat Format { get; set; }

        public bool Paragraphs { get; set; }

        public int MinParagraphWords { get; set; }
        public int MaxParagraphWords { get; set; }

        public int BlockSize { get; set; }

        public override void GenerateFile()
        {
            throw new NotImplementedException();
        }
    }
}
