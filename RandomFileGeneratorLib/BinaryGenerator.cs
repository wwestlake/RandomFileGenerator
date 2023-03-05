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
        bool _zeros;
        public BinaryGenerator(bool zeros)
        {
            _zeros = zeros;
        }

        public void Generate(Stream sink, long numberOfBytes)
        {
            byte[] data = new byte[numberOfBytes];
            for (int i = 0; i < numberOfBytes; i++)
            {
                if (_zeros)
                {
                    data[i] = 0;
                } else
                {
                    data[i] = (byte)random.Next();
                }
            }
            sink.Write(data, 0, data.Length);
            sink.Flush();
        }
    }
}
