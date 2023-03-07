
using CommandLineParser.Arguments;

namespace RandomFileGeneratorLib.Policies
{
    public abstract class Policy
    {
        public bool Check(IFileGeneratorOptions options, out string message)
        {
            if (! PolicyCheck(options) )
            {
                message = FailMessage(options);
                return false;
            }
            message = "Ok";
            return true;
        }

        protected abstract bool PolicyCheck(IFileGeneratorOptions options);

        protected abstract string FailMessage(IFileGeneratorOptions options);
    }
}
