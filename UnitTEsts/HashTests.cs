using NUnit.Framework;
using RandomFileGeneratorLib;
using RandomFileGeneratorLib.Hash;
using System.IO;
using System.Text;

namespace UnitTests
{
    public class HashTests
    {
        ParsingTarget _target = new ParsingTarget();

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void NoHashSelected()
        {
            ParsingTarget target = new ParsingTarget();
            target.HashType = "none";
            var gen = HashFactory.Create(target);
            Assert.That(gen, Is.Not.Null);
            Assert.That(gen.HasValue, Is.False);
        }

        [Test]
        public void Sha1HashTest()
        {
            ParsingTarget target = new ParsingTarget();
            target.HashType = "sha1";
            string text = "Value to be hashed";
            var stream1 = new MemoryStream(Encoding.UTF8.GetBytes(text ?? ""));
            var stream2 = new MemoryStream(Encoding.UTF8.GetBytes(text ?? ""));
            var gen = HashFactory.Create(target);
            if (gen != null && gen.HasValue)
            {
                string hash1 = gen.Value.Hash(stream1);
                string hash2 = gen.Value.Hash(stream2);

                Assert.That(hash1, Is.EqualTo(hash2));
            } else
            {
                Assert.Fail("Factory failed to produce hash generator");
            }
        }

        [Test]
        public void Sha256HashTest()
        {
            ParsingTarget target = new ParsingTarget();
            target.HashType = "sha256";
            string text = "Value to be hashed";
            var stream1 = new MemoryStream(Encoding.UTF8.GetBytes(text ?? ""));
            var stream2 = new MemoryStream(Encoding.UTF8.GetBytes(text ?? ""));
            var gen = HashFactory.Create(target);
            if (gen != null && gen.HasValue)
            {
                string hash1 = gen.Value.Hash(stream1);
                string hash2 = gen.Value.Hash(stream2);

                Assert.That(hash1, Is.EqualTo(hash2));
            }
            else
            {
                Assert.Fail("Factory failed to produce hash generator");
            }
        }

        [Test]
        public void Sha384HashTest()
        {
            ParsingTarget target = new ParsingTarget();
            target.HashType = "sha384";
            string text = "Value to be hashed";
            var stream1 = new MemoryStream(Encoding.UTF8.GetBytes(text ?? ""));
            var stream2 = new MemoryStream(Encoding.UTF8.GetBytes(text ?? ""));
            var gen = HashFactory.Create(target);
            if (gen != null && gen.HasValue)
            {
                string hash1 = gen.Value.Hash(stream1);
                string hash2 = gen.Value.Hash(stream2);

                Assert.That(hash1, Is.EqualTo(hash2));
            }
            else
            {
                Assert.Fail("Factory failed to produce hash generator");
            }
        }

        [Test]
        public void Sha512HashTest()
        {
            ParsingTarget target = new ParsingTarget();
            target.HashType = "sha512";
            string text = "Value to be hashed";
            var stream1 = new MemoryStream(Encoding.UTF8.GetBytes(text ?? ""));
            var stream2 = new MemoryStream(Encoding.UTF8.GetBytes(text ?? ""));
            var gen = HashFactory.Create(target);
            if (gen != null && gen.HasValue)
            {
                string hash1 = gen.Value.Hash(stream1);
                string hash2 = gen.Value.Hash(stream2);

                Assert.That(hash1, Is.EqualTo(hash2));
            }
            else
            {
                Assert.Fail("Factory failed to produce hash generator");
            }
        }

    }
}