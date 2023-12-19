using NFluent;
using Xunit;

namespace Day5.Tests
{
    public class AlmanacAnalyzerPart1Tests
    {
        [Fact]
        public void Should_return_the_seed_number_when_not_mapped()
        {
            var almanac = new string[]
            {
                "seeds: 10",
                "",
                "seed-to-soil map:",
                "20 30 2"
            };

            var soilLocation = new AlmanacAnalyzerPart1(almanac).GetLowestDestination();

            Check.That(soilLocation).IsEqualTo(10);
        }

        [Fact]
        public void Should_return_the_destination_number_when_the_seed_equals_the_convertor_source_range_start()
        {
            var almanac = new string[]
            {
                "seeds: 10",
                "",
                "seed-to-soil map:",
                "20 10 1"
            };

            var soilLocation = new AlmanacAnalyzerPart1(almanac).GetLowestDestination();

            Check.That(soilLocation).IsEqualTo(20);
        }

        [Fact]
        public void Should_return_the_lowest_destination_number_between_two_convertors()
        {
            var almanac = new string[]
            {
                "seeds: 11",
                "",
                "seed-to-soil map:",
                "10 20 1",
                "15 8 5"
            };

            var soilLocation = new AlmanacAnalyzerPart1(almanac).GetLowestDestination();

            Check.That(soilLocation).IsEqualTo(18);
        }

        [Fact]
        public void Should_return_the_lowest_destination_number_between_two_maps()
        {
            var almanac = new string[]
            {
                "seeds: 14",
                "",
                "seed-to-soil map:",
                "20 10 5",
                "",
                "soil-to-fertilizer map:",
                "30 20 5"
            };

            var soilLocation = new AlmanacAnalyzerPart1(almanac).GetLowestDestination();

            Check.That(soilLocation).IsEqualTo(34);
        }

        [Fact]
        public void Part1_Example()
        {
            var almanac = File.ReadAllLines("./Resources/Example.txt");

            var soilLocation = new AlmanacAnalyzerPart1(almanac).GetLowestDestination();

            Check.That(soilLocation).IsEqualTo(35);
        }

        [Fact(Skip = "Input file is not provided according to the will of the adventOfCode author")]
        public void Part1_Input()
        {
            var almanac = File.ReadAllLines("./Resources/Input.txt");

            var soilLocation = new AlmanacAnalyzerPart1(almanac).GetLowestDestination();

            Check.That(soilLocation).IsEqualTo(331445006);
        }
    }
}
