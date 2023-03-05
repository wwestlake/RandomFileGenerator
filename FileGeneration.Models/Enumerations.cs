using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileGeneration.Models
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

    public enum TextFileFormat
    {
        Continuous,
        Paragraphs
    }

}
