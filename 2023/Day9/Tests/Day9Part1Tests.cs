using NFluent;
using Xunit;

namespace Day9
{
    public class Day9Part1Tests
    {
        [Fact]
        public void Should_get_the_next_value_of_a_serie_of_equal_values()
        {
            var input = new List<string> 
            {   
                "3 3"
            };

            var result = new SensorAnalyzer(input).GetSumOfNextExtrapolatedValues();

            Check.That(result).IsEqualTo(3);
        }

        [Fact]
        public void Should_get_the_next_value_of_a_serie_of_equal_intervals()
        {
            var input = new List<string>
            {
                "3 4 5"
            };

            var result = new SensorAnalyzer(input).GetSumOfNextExtrapolatedValues();

            Check.That(result).IsEqualTo(6);
        }

        [Fact]
        public void Should_get_the_next_value_of_a_serie_of_non_equal_intervals()
        {
            var input = new List<string>
            {
                "1 2 4"
            };

            var result = new SensorAnalyzer(input).GetSumOfNextExtrapolatedValues();

            Check.That(result).IsEqualTo(7);
        }


        [Fact]
        public void Should_get_the_sum_of_the_next_values_of_two_series()
        {
            var input = new List<string>
            {
                "1 2 4",
                "3 4 5"
            };

            var result = new SensorAnalyzer(input).GetSumOfNextExtrapolatedValues();

            Check.That(result).IsEqualTo(13);
        }

        [Fact]
        public void Part_1_example()
        {
            var input = new List<string>
            {
                "0 3 6 9 12 15",
                "1 3 6 10 15 21",
                "10 13 16 21 30 45"
            };

            var result = new SensorAnalyzer(input).GetSumOfNextExtrapolatedValues();

            Check.That(result).IsEqualTo(114);
        }

        [Fact(Skip = "Input file is not provided according to the will of the adventOfCode author")]
        public void Part_1_input()
        {
            var input = File.ReadAllLines("./Resources/Input.txt").ToList();

            var result = new SensorAnalyzer(input).GetSumOfNextExtrapolatedValues();

            Check.That(result).IsEqualTo(1953784198);
        }    
    }
}
