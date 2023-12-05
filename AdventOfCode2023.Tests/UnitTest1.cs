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

        [Test]
        public void Should_return_an_array_of_number_from_an_input_string_when_the_string_contains_any_integer()
        {
            string input = "seed-to-soil map:\r\n50 98 2\r\n52 50 486";

            List<int> integers = MyFileReader.ParseIntegersFromStringInputUsingRegex(input);

            Assert.That(integers.Count, Is.EqualTo(6));
        }
    }
}