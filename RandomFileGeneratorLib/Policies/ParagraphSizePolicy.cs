using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomFileGeneratorLib.Policies
{
    public class ParagraphSizePolicy : Policy
    {
        string message = string.Empty;

        protected override string FailMessage(IFileGeneratorOptions options)
        {
            return message;
        }

        protected override bool PolicyCheck(IFileGeneratorOptions options)
        {
            if (options.FileSize() <= 0)
            {
                this.message = "Filesize must be > 0";
                return false;
            }
            if (options.MinPAragraphSize > options.MaxPAragraphSize)
            {
                this.message = "Min paragraph size cannot be greatter than max file size.";
                return false;
            }
            if (options.MinPAragraphSize > options.FileSize())
            {
                this.message = "Min paragraph size must not be greater that the file size";
                return false;
            }
            if (options.MaxPAragraphSize > options.FileSize())
            {
                this.message = "Max paragraph size must not be greater that the file size";
                return false;
            }
            return true;
        }
    }
}
