using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileGeneratorGui.Models
{
    public class BinaryFile : FileModelBase
    {
        public Guid Id { get; set; }

        public bool Zeros { get; set; }

        public BinaryFile(string? folder, string? fileName, string? description, long size, bool zeros, int blockSize)
            : base(folder, fileName, description, size, blockSize)
        {
            Zeros = zeros;
        }

        public override void GenerateFile()
        {
            throw new NotImplementedException();
        }
    }
}
