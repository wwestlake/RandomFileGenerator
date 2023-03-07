using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileGeneratorGui.Models
{
    public enum FileTypes
    {
        Text,
        Binary
    }

    public enum TextFileContents 
    { 
        RandomLetters,
        LoremIpsum,
    }

    public enum BinaryFileContents
    {
        AllZeros,
        AllOnes,
        RandomBytes,
        SequentialBytes,
        Custom
    }

    public enum TextFileFormat
    {
        Continuous,
        Paragraphs
    }

}
