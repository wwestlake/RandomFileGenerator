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
        public static readonly int BlockSize = 32 * 1024 * 1024;

        public static readonly string DefaultPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
            + Path.DirectorySeparatorChar + "LagDaemon Software"
            + Path.DirectorySeparatorChar + "RandomFileGenerator"
            + Path.DirectorySeparatorChar + "Projects";

        public static string DefaultProjectPath =
            DefaultPath + Path.DirectorySeparatorChar + "DefaultProject";

    }
}
