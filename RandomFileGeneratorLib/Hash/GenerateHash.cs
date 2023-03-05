using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace RandomFileGeneratorLib.Hash
{
    public class GenerateHash
    {
        private readonly HashAlgorithm _algorithm;

        public GenerateHash(HashAlgorithm algorithm) 
        { 
            _algorithm = algorithm;
        }
        

        public string Hash(Stream stream)
        {
            using (var bufferedStream = new BufferedStream(stream, Constants.MaxBlockSize))
            {
                byte[] checksum = _algorithm.ComputeHash(bufferedStream);
                return BitConverter.ToString(checksum).Replace("-", String.Empty);
            }
        }




    }
}
