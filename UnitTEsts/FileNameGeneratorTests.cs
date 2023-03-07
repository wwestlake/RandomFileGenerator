using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using RandomFileGeneratorLib.Utilities;

namespace UnitTests
{
    public class FileNameGeneratorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void File_name_generator_creates_dated_filename()
        {
            var today = DateTime.Now.ToString("MMddyy");
            var filename = $"test_{today}.dat";
            FileNameGenerator gen = new FileNameGenerator();
            Assert.IsNotNull(gen);
            var result = gen.Dated("test", "dat");
            Assert.AreEqual(filename, result);

        }

        [Test]
        public void File_name_generator_creates_filename_with_ticks()
        {
            // TODO: fild a way to validate this
            FileNameGenerator gen = new FileNameGenerator();
            Assert.IsNotNull(gen);
            var result = gen.Ticks("test", "dat");
            Assert.IsNotNull(result);
        }

        [Test]
        public void File_name_generator_creates_filenames_with_sequential_numbers()
        {
            var exemplar1 = $"test_0.dat";
            var exemplar2 = $"test_1.dat";

            FileNameGenerator gen = new FileNameGenerator();
            Assert.IsNotNull(gen);
            var result1 = gen.Sequence("test", "dat");
            var result2 = gen.Sequence("test", "dat");

            Assert.IsNotNull(result1);
            Assert.IsNotNull(result2);
            Assert.AreEqual(exemplar1, result1);
            Assert.AreEqual(exemplar2, result2);
        }

        [Test]
        public void File_name_generator_creates_filenames_with_guid()
        {
            FileNameGenerator gen = new FileNameGenerator();
            Assert.IsNotNull(gen);
            var result1 = gen.UseGuid("test","dat");
            Assert.IsNotNull(result1);
        }



    }
}
