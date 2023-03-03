using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLineParser.Arguments;
using CommandLineParser.Exceptions;

namespace RandomFileGenerator
{
    internal class ParsingTarget
    {
        [ValueArgument(typeof(string), 'f', "file", Description = "name of file to generate", Optional = false)]
        public string Filename { get; set; }

        [ValueArgument(typeof(long), 's', "size", Description = "Size of file in units", Optional = false)]
        public long Size { get; set; }

        [EnumeratedValueArgument(typeof(string), 'u', "unit", Description = "Units are Bytes, KBytes, MBytes, GByte (B, KB, MB, GB)", AllowedValues = "B;KB;MB;GB", DefaultValue = "B")]
        public string Unit { get; set; }

        [EnumeratedValueArgument(typeof(string), 't', "type", Description = "Text or Binary", AllowedValues = "text;binary", DefaultValue = "text")]
        public string FileType { get; set; }

    }
}
