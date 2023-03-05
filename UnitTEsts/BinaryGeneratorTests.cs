using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RandomFileGeneratorLib;
using System.IO;

namespace UnitTests
{
    public class BinaryGeneratorTests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GenerateBlock()
        {
            byte[] zeros = new byte[1024];
            byte[] data = new byte[1024];
            MemoryStream mem = new MemoryStream(data, true);
            var gen = new BinaryGenerator();
            gen.Generate(mem, data.Length);
            Assert.That(zeros.SequenceEqual(data), Is.False);
        }


    }
}
