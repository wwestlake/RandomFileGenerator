using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomFileGeneratorLib
{
    public static class OptionExtensions
    {
        private static List<Policies.Policy> _policies = new List<Policies.Policy>();

        static OptionExtensions() {
            _policies.Add(new Policies.PathPolicy());
            _policies.Add(new Policies.ParagraphSizePolicy());
            _policies.Add(new Policies.FileTypePolicy());
        }

        public static long FileSize(this IFileGeneratorOptions options)
        {
            switch (options.Unit)
            {
                case "B":
                case "b": return options.Size;
                case "K":
                case "k": return options.Size * 1024;
                case "M":
                case "m": return options.Size * 1024 * 1024;
                case "G":
                case "g": return options.Size * 1024 * 1024 * 1024;
            }
            return options.Size;
        }

        public static bool Validate(this IFileGeneratorOptions options, out string message)
        {
            foreach (Policies.Policy policy in _policies)
            {
                if (! policy.Check(options, out message))
                {
                    return false;
                }
            }
            message = "Ok";
            return true;
        }

        public static bool Exists(this IFileGeneratorOptions options)
        {
            return File.Exists(options.Filename);
        }

        public static FileStream Open(this IFileGeneratorOptions options)
        {
            if (options == null || options.Filename == null) 
                throw new ArgumentNullException(nameof(options));

            if (options.Exists())
            {
                return File.OpenRead(options.Filename);
            }

            throw new FileNotFoundException(options.Filename);
        }


    }
}
