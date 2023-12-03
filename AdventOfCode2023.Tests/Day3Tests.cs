using AdventOfCode2023Day3;

namespace AdventOfCode2023.Tests
{
    public class Day3Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Should_return_an_array_of_two_elements_when_input_contains_2_integer_seperates_by_symbols()
        {
            Engine engine = new Engine();

            string[] input = { "467..114..", "...*......" };
            Dictionary<Coordinate,int> numbers = engine.FindNumbers(input);

            Assert.That(numbers.Count,Is.EqualTo(2));
        }


        [Test]
        public void Should_return_an_array_containing_the_correct_coordinates_of_the_number_in_the_input()
        {
            Engine engine = new Engine();

            string[] input = { "467.......", "...*......" };
            Dictionary<Coordinate, int> numbers = engine.FindNumbers(input);

            Assert.That(numbers.First().Key.Length, Is.EqualTo(3));
            Assert.That(numbers.First().Key.PositionX, Is.EqualTo(0));
            Assert.That(numbers.First().Key.PositionY, Is.EqualTo(0));
            Assert.That(numbers.First().Key.Length,Is.EqualTo(3));
        }

        [Test]
        public void Should_return_an_array_of_three_elements_when_input_contains_3_integer_seperates_by_symbols_and_in_differents_rows()
        {
            Engine engine = new Engine();

            string[] input = { "467..114..", "...*.....5" };
            Dictionary<Coordinate, int> numbers = engine.FindNumbers(input);

            Assert.That(numbers.Count, Is.EqualTo(3));
        }

        [Test]
        public void Should_return_an_array_of_two_symbols_when_input_contains_two_symbols_seperates_by_dot()
        {
            Engine engine = new Engine();

            string[] input = { "467..114..", "...*.....5" };
            Dictionary<Coordinate,int> symbols = engine.FindSymbols(input);

            Assert.That(symbols.Count, Is.EqualTo(1));
        }

        [Test]
        public void Should_return_a_total_when_there_is_numbers_adjacent_to_a_symbol_in_the_input()
        {
            Engine engine = new Engine();

            string[] input = { "467..114..", "...*.....5" };
            int total = engine.CalculateATotalOfAllNumbersAdjacentToASymbol(input);

            Assert.That(total,Is.EqualTo(467));
        }

        [Test]
        public void Should_not_return_a_total_when_there_is_no_numbers_adjacent_to_a_symbol_in_the_input()
        {
            Engine engine = new Engine();

            string[] input = { "467..114..", "...*......" };
            int total = engine.CalculateATotalOfAllNumbersAdjacentToASymbol(input);

            Assert.That(total, Is.EqualTo(467));
        }

        [Test]
        public void Should_return_a_total_when_there_is_pairs_of_numbers_adjacent_to_a_symbol_in_the_input()
        {
            Engine engine = new Engine();

            string[] input = { "467.114...", "...*.....5" };
            int total = engine.CalculateATotalMultiplicationOfAllPairsOfNumbersAdjacentToTheSameSymbol(input);

            Assert.That(total, Is.EqualTo(53238));
        }

        [Test]
        public void Should_return_true_when_coordinate_A_is_neighbor_of_coordinate_B()
        {
            Coordinate a = new Coordinate(2, 3, 4);

            Coordinate b = new Coordinate(1, 5);
            bool isNeighbor = a.IsNeighbor(b);

            Assert.That(isNeighbor, Is.True);
        }

        [Test]
        public void Should_return_true_when_coordinate_A_is_neighbor_of_coordinate_B_even_by_adjacency()
        {
            Coordinate a = new Coordinate(0, 0, 3);

            Coordinate b = new Coordinate(1, 3,1);
            bool isNeighbor = a.IsNeighbor(b);

            Assert.That(isNeighbor, Is.True);
        }
    }
}