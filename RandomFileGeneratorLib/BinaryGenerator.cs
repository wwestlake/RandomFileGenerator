using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomFileGeneratorLib
{
    public class BinaryGenerator : IGenerator
    {
        Random random = new Random((int)DateTime.Now.Ticks);

        public BinaryGenerator()
        {

        }

        public void Generate(Stream sink, long numberOfBytes)
        {
            byte[] data = new byte[numberOfBytes];
            for (int i = 0; i < numberOfBytes; i++)
            {
                data[i] = (byte)random.Next();
            }
            sink.Write(data, 0, data.Length);
            sink.Flush();
        }
    }
}
