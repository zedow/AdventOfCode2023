using System.Reflection.PortableExecutable;
using Kernel;

namespace AdventOfCode2023.Tests
{
    public class Tests
    {
        MyFileReader reader;

        [SetUp]
        public void Setup()
        {
            reader = new MyFileReader();
        }

        [Test]
        public void Should_return_array_containing_all_lines_when_file_path_is_correct()
        {
            var filePath = AppDomain.CurrentDomain.BaseDirectory + ("../../../input.txt");

            string[] fileContent = reader.ReadFile(filePath);

            Assert.That(fileContent.Length, Is.EqualTo(10));
        }
    }
}