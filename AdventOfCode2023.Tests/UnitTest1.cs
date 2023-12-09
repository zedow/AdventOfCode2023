using System.Linq;
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

        [Test]
        public void Should_return_an_array_of_integers_when_there_is_negative_integers()
        {
            string input = "-10 -20 30";

            List<int> integers = MyFileReader.ParseIntegersFromStringInputUsingRegex(input);

            Assert.That(integers.Count, Is.EqualTo(3));
            Assert.That(integers.First(),Is.EqualTo(-10));
            Assert.That(integers.ElementAt(1), Is.EqualTo(-20));
            Assert.That(integers.ElementAt(2), Is.EqualTo(30));
        }
    }
}