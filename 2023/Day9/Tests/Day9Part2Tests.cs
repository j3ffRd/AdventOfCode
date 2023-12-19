using NFluent;
using Xunit;

namespace Day9
{
    public class Day9Part2Tests
    {
        [Fact]
        public void Should_get_the_first_value_of_a_serie_of_equal_intervals()
        {
            var input = new List<string>
            {
                "4 5 6",
            };

            var result = new SensorAnalyzer(input).GetSumOfFirstExtrapolatedValues();

            Check.That(result).IsEqualTo(3);
        }

        [Fact]
        public void Should_get_the_sum_of_the_first_values_of_two_series()
        {
            var input = new List<string>
            {
                "4 5 6",
                "7 8 9"
            };

            var result = new SensorAnalyzer(input).GetSumOfFirstExtrapolatedValues();

            Check.That(result).IsEqualTo(9);
        }

        [Fact]
        public void Part2_example()
        {
            var input = new List<string>
            {
                "0 3 6 9 12 15",
                "1 3 6 10 15 21",
                "10 13 16 21 30 45"
            };

            var result = new SensorAnalyzer(input).GetSumOfFirstExtrapolatedValues();

            Check.That(result).IsEqualTo(2);
        }

        [Fact(Skip = "Input file is not provided according to the will of the adventOfCode author")]
        public void Part_2_input()
        {
            var input = File.ReadAllLines("./Resources/Input.txt").ToList();

            var result = new SensorAnalyzer(input).GetSumOfFirstExtrapolatedValues();

            Check.That(result).IsNotEqualTo(-914567838);
        }
    }
}
