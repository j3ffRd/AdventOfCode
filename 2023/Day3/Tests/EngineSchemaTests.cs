using NFluent;
using Xunit;

namespace Day3.Tests
{
    public class EngineSchemaTests
    {
        [Fact]
        public void A_Schema_With_No_Number_Returns_zero()
        {
            string[] schema = { "." };

            var result = GetSumOfPartNumbers(schema);

            Check.That(result).IsEqualTo(0);
        }

        [Fact]
        public void A_Schema_With_One_Number_And_No_Symbol_Returns_0()
        {
            string[] schema = { "5" };

            var result = GetSumOfPartNumbers(schema);

            Check.That(result).IsEqualTo(0);
        }

        [Theory]
        [InlineData("5$")]
        [InlineData("$5")]
        public void A_Schema_With_One_Number_Adjacent_To_A_Symbol_Returns_The_Number(string line)
        {
            string[] schema = { line };

            var result = GetSumOfPartNumbers(schema);

            Check.That(result).IsEqualTo(5);
        }

        [Fact]
        public void A_Schema_With_A_Symbol_Alone_is_Ignored()
        {
            string[] schema = { ".$.5" };

            var result = GetSumOfPartNumbers(schema);

            Check.That(result).IsEqualTo(0);
        }

        [Theory]
        [InlineData(".$.")]
        [InlineData("$..")]
        [InlineData("..$")]
        public void A_Schema_With_One_Number_below_A_Symbol_Returns_The_Number(string upperLine)
        {
            string[] schema = { upperLine, ".5." };

            var result = GetSumOfPartNumbers(schema);

            Check.That(result).IsEqualTo(5);
        }

        [Theory]
        [InlineData(".$.")]
        [InlineData("$..")]
        [InlineData("..$")]
        public void A_Schema_With_One_Number_above_A_Symbol_Returns_The_Number(string bottomLine)
        {
            string[] schema = { ".5.", bottomLine };

            var result = GetSumOfPartNumbers(schema);

            Check.That(result).IsEqualTo(5);
        }

        [Fact]
        public void Part1_Example()
        {
            string[] schema =
                {
                    "467..114..",
                    "...*......",
                    "..35..633.",
                    "......#...",
                    "617*......",
                    ".....+.58.",
                    "..592.....",
                    "......755.",
                    "...$.*....",
                    ".664.598..",
                };

            var result = GetSumOfPartNumbers(schema);

            Check.That(result).IsEqualTo(4361);
        }

        [Fact(Skip = "Input file is not provided according to the will of the adventOfCode author")]
        public void Part1_Input()
        {
            string[] schema = File.ReadAllLines("./Resources/Input.txt");

            var result = GetSumOfPartNumbers(schema);

            Check.That(result).IsEqualTo(535078);
        }

        [Fact]
        public void Part2_Example()
        {
            string[] schema =
                {
                    "467..114..",
                    "...*......",
                    "..35..633.",
                    "......#...",
                    "617*......",
                    ".....+.58.",
                    "..592.....",
                    "......755.",
                    "...$.*....",
                    ".664.598..",
                };

            var result = GetSumOfStarSymbolAdjacentToTwoNumbers(schema);

            Check.That(result).IsEqualTo(467835);
        }

        [Fact(Skip = "Input file is not provided according to the will of the adventOfCode author")]
        public void Part2_Input()
        {
            string[] schema = File.ReadAllLines("./Resources/Input.txt");

            var result = GetSumOfStarSymbolAdjacentToTwoNumbers(schema);

            Check.That(result).IsEqualTo(75312571);
        }

        private int GetSumOfPartNumbers(string[] schema)
        {
            return new EngineSchematic(schema).GetSumOfAllPartNumbers();
        }

        private int GetSumOfStarSymbolAdjacentToTwoNumbers(string[] schema)
        {
            return new EngineSchematic(schema).GetSumOfAllGearRatios();
        }
    }
}
