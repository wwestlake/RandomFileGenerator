using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using RandomFileGeneratorLib;

namespace RandomFileGeneratorLib.Hash
{
    public static class HashFactory
    {
        public static Maybe<GenerateHash> Create(ParsingTarget options)
        {
            switch (options.HashType)
            {
                case "none": return Maybe<GenerateHash>.None();
                case "sha1": return Maybe<GenerateHash>.Some( new GenerateHash(SHA1.Create()) );
                case "sha256": return Maybe<GenerateHash>.Some( new GenerateHash(SHA256.Create()) );
                case "sha384": return Maybe<GenerateHash>.Some(new GenerateHash(SHA384.Create()));
                case "sha512": return Maybe<GenerateHash>.Some(new GenerateHash(SHA512.Create()));
            }
            return Maybe<GenerateHash>.None();
        }
    }
}
