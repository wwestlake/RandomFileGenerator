using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileGeneration.Models
{
    public class BinaryFile : FileDetails
    {
        public bool Zeros { get; set; }
        public int BlockSize { get; set; }

        public override void GenerateFile()
        {
            throw new NotImplementedException();
        }
    }
}
