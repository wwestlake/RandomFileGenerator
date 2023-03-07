using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomFileGeneratorLib
{
    public static class Constants
    {
        public static readonly int MaxBlockSize = 32 * 1024 * 1024;
        public const string FILE_NAME_NULL = "Filename must not be null";
        public const string PARSING_TARGE_NULL = "Parsing Target must not be null";

    }
}
