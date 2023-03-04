using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLineParser.Arguments;
using CommandLineParser.Exceptions;

namespace RandomFileGeneratorLib
{
    public class ParsingTarget
    {
        [ValueArgument(typeof(string), 'f', "file", Description = "name of file to generate", Optional = false)]
        public string? Filename { get; set; }

        [ValueArgument(typeof(long), 's', "size", Description = "Size of file in units", DefaultValue = 1024)]
        public long Size { get; set; }

        [EnumeratedValueArgument(typeof(string), 'u', "unit", Description = "Units are Bytes, KBytes, MBytes, GByte (B|b, K|k, M|m, Gg)", AllowedValues = "B;b;K;k;M;m;G;g", DefaultValue = "B")]
        public string? Unit { get; set; }

        [EnumeratedValueArgument(typeof(string), 't', "type", Description = "Text or Binary", AllowedValues = "text;binary", DefaultValue = "text")]
        public string? FileType { get; set; }

        [SwitchArgument('p', "paragraphize", false)]
        public bool Paragraphize { get; set; }

        [ValueArgument(typeof(int), "min", Description = "Minimum Paragraph Size in words", DefaultValue = 25)]
        public int MinPAragraphSize { get; set; }

        [ValueArgument(typeof(int), "max", Description = "Maximum Paragraph Size in words", DefaultValue = 50)]
        public int MaxPAragraphSize { get; set; }

        [EnumeratedValueArgument(typeof(string), 'h', "hash", Description = "none|sha1|sha256|", AllowedValues = "sha1;sha256", DefaultValue = "none")]
        public string? HashType { get; set; }


    }
}
