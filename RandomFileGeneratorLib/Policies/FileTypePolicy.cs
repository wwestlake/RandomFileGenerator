using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomFileGeneratorLib.Policies
{
    public class FileTypePolicy : Policy
    {
        string message = "Ok";
        protected override string FailMessage(ParsingTarget options)
        {
            return message;
        }

        protected override bool PolicyCheck(ParsingTarget options)
        {
            if (options == null)
            {
                throw new ArgumentNullException("options");
            }

            if (options.FileType != "text" && options.Paragraphize == true)
            {
                message = $"Paragraphize has no meaning for non-text files";
                return false;
            }

            return true;
        }
    }
}
