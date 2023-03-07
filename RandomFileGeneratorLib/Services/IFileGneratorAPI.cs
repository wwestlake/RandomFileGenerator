using RandomFileGeneratorLib.Connectors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomFileGeneratorLib.Services
{
    public interface IFileGneratorAPI
    {
        void GenerateSingleFile(IFileGeneratorOptions options, Stream fileStream, ProgressConnector? connector = null);
        void GenerateMultipleFiles(IEnumerable<Tuple<IFileGeneratorOptions, Stream>> options, ProgressConnector? connector = null);
    }
}
