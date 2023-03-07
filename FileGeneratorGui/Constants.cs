using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileGeneratorGui
{
    public static class Constants
    {
        public static readonly string DefaultPath;
        public static readonly int BlockSize = 32 * 1024 * 1024;

        static Constants()
        {
            DefaultPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
               + Path.PathSeparator + "LagDaemon Software"
               + Path.PathSeparator + "RandomFileGenerator"
               + Path.PathSeparator + "Projects";
        }
    }
}
