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

        public void GenerateRandomBytes(Stream sink, long numberOfBytes)
        {
            byte[] data = new byte[numberOfBytes];
            GenerateBytes(data, () => (byte)random.Next());
            WriteBytes(sink, data);
        }

        public void GenerateZeros(Stream sink, long numberOfBytes)
        {
            byte[] data = new byte[numberOfBytes];
            GenerateBytes(data, () => 0);
            WriteBytes(sink, data);
        }

        public void GenerateSequnce(Stream sink, long numberOfBytes)
        {
            byte i = 0;
            byte[] data = new byte[numberOfBytes];
            GenerateBytes(data, () => i++);
            WriteBytes(sink, data);
        }

        public void GenerateValue(Stream sink, long numberOfBytes, byte value)
        {
            byte[] data = new byte[numberOfBytes];
            GenerateBytes(data, () => value);
            WriteBytes(sink, data);
        }


        protected void GenerateBytes(byte[] bytes, Func<byte> fn)
        {
            byte[] data = new byte[bytes.Length];
            for (int i = 0; i < bytes.Length; i++)
            {
                data[i] = fn();
            }
        }

        protected void WriteBytes(Stream sink, byte[] bytes)
        {
            sink.Write(bytes, 0, bytes.Length);
            sink.Flush();
        }

        public void Generate(Stream sink, long numberOfBytes)
        {
            throw new NotImplementedException();
        }
    }
}
