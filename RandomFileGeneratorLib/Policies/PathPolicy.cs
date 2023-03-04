using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomFileGeneratorLib.Policies
{
    public class PathPolicy : Policy
    {
        protected override string FailMessage(ParsingTarget options)
        {
            return $"The path '{options.Filename}' contains invalid characters.";
        }

        protected override bool PolicyCheck(ParsingTarget options)
        {
            if (options == null || options.Filename == null) return false;
            return options.Filename.IndexOfAny(Path.GetInvalidPathChars()) == -1;
        }
    }
}
