using NFluent;
using Xunit;

namespace Day5.Tests
{
    public class AlmanacAnalyzerPart2Tests
    {
        [Fact]
        public void Should_returns_the_first_value_mapped()
        {
            var almanac = new string[]{
                "seeds: 1 10",
                "",
                "seed-to-soil map:",
                "50 1 10",
            };

            var soilLocation = new AlmanacAnalyzerPart2(almanac).GetLowestDestinationRange();

            Check.That(soilLocation).IsEqualTo(50);
        }

        [Fact]
        public void Should_returns_the_first_value_not_mapped_after_the_last_convertor()
        {
            var almanac = new string[]{
                "seeds: 1 10",
                "",
                "seed-to-soil map:",
                "50 1 9",
            };

            var soilLocation = new AlmanacAnalyzerPart2(almanac).GetLowestDestinationRange();

            Check.That(soilLocation).IsEqualTo(10);
        }

        [Fact]
        public void Should_returns_the_first_value_not_mapped_before_the_first_convertor()
        {
            var almanac = new string[]{
                "seeds: 1 10",
                "",
                "seed-to-soil map:",
                "50 2 10",
            };

            var soilLocation = new AlmanacAnalyzerPart2(almanac).GetLowestDestinationRange();

            Check.That(soilLocation).IsEqualTo(1);
        }

        [Fact]
        public void Should_returns_the_first_value_not_mapped_that_is_between_two_converters()
        {
            var almanac = new string[]{
                "seeds: 12 10",
                "",
                "seed-to-soil map:",
                "50 2 10",
                "60 15 10",
            };

            var soilLocation = new AlmanacAnalyzerPart2(almanac).GetLowestDestinationRange();

            Check.That(soilLocation).IsEqualTo(12);
        }

        [Fact]
        public void Should_returns_the_lowest_destination_mapped_between_two_converters()
        {
            var almanac = new string[]{
                "seeds: 1 10",
                "",
                "seed-to-soil map:",
                "50 20 10",
                "5 1 10",
            };

            var soilLocation = new AlmanacAnalyzerPart2(almanac).GetLowestDestinationRange();

            Check.That(soilLocation).IsEqualTo(5);
        }

        [Fact]
        public void Should_returns_the_lowest_destination_mapped_between_three_convertors()
        {
            var almanac = new string[]{
                "seeds: 1 10 20 10",
                "",
                "seed-to-soil map:",
                "30 1 10",
                "60 10 10",
                "1 20 10"
            };

            var soilLocation = new AlmanacAnalyzerPart2(almanac).GetLowestDestinationRange();

            Check.That(soilLocation).IsEqualTo(1);
        }

        [Fact]
        public void Should_returns_the_lowest_destination_mapped_between_two_maps()
        {
            var almanac = new string[]{
                "seeds: 10 20 5 20",
                "",
                "seed-to-soil map:",
                "20 5 10",
                "60 15 10",
                "",
                "soil-to-fertilizer map:",
                "0 15 40"
            };

            var soilLocation = new AlmanacAnalyzerPart2(almanac).GetLowestDestinationRange();

            Check.That(soilLocation).IsEqualTo(5);
        }

        [Fact]
        public void Part2_Example()
        {
            var almanac = File.ReadAllLines("./Resources/Example.txt");

            var soilLocation = new AlmanacAnalyzerPart2(almanac).GetLowestDestinationRange();

            Check.That(soilLocation).IsEqualTo(46);
        }
    }
}
