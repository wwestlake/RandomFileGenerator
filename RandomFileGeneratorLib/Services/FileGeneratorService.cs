using RandomFileGeneratorLib.Connectors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace RandomFileGeneratorLib.Services
{
    public class FileGeneratorService : IFileGneratorAPI
    {

        public void GenerateSingleFile(IFileGeneratorOptions options, Stream fileStream, ProgressConnector? connector = null)
        {
            FileGenerator gen = new FileGenerator(options, connector);
            gen.Generate();
        }

        public void GenerateMultipleFiles(IEnumerable<Tuple<IFileGeneratorOptions, Stream>> options, ProgressConnector? connector = null)
        {
            foreach (var file in options)
            {
                GenerateSingleFile(file.Item1, file.Item2, connector);
            }
        }


    }
}
