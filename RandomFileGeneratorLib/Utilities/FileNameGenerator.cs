using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomFileGeneratorLib.Utilities
{
    public class FileNameGenerator
    {
        private int _sequence = 0;

        public FileNameGenerator()
        {
        }


        public string Dated(string filename, string extension)
        {
            var date = DateTime.Now.ToString("MMddyy");
            return $"{filename}_{date}.{extension}";
        }

        public string Ticks(string filename, string extension)
        {
            string ticks = DateTime.Now.Ticks.ToString();
            return $"{filename}_{ticks}.{extension}";
        }

        public string Sequence(string filename, string extension)
        {
            return $"{filename}_{_sequence++}.{extension}";
        }

        public string UseGuid(string? filename = null, string? extension = null)
        {
            var guid = Guid.NewGuid().ToString().Replace("-", string.Empty).ToUpper();

            if (string.IsNullOrEmpty(filename))
            {
                if (!string.IsNullOrEmpty(extension))
                {
                    return $"{guid}.{extension}";
                } else
                {
                    return $"{guid}";
                }
            } else
            {
                if (!string.IsNullOrEmpty(extension))
                {
                    return $"{filename}_{guid}.{extension}";
                } else
                {
                    return $"{filename}_{guid}";
                }
            }
        }
    }
}
