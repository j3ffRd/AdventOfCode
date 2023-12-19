using NFluent;
using Xunit;

namespace Day6.Tests
{
    public class RacesAnalyserTests
    {

        [Theory]
        [InlineData(3, 1, 2)]
        [InlineData(4, 3, 1)]
        public void Should_get_the_number_of_way_I_can_beat_the_record_for_one_race(int time, int distance, int expectedCount)
        {
            var raceRecord = new string[]
            {
                $"Time:     {time}",
                $"Distance: {distance}"
            };

            var count = new RaceRecordAnalyser(raceRecord).GetNumberOfWaysToWinPart1();

            Check.That(count).IsEqualTo(expectedCount);
        }

        [Fact]
        public void Should_get_the_number_of_way_I_can_beat_the_record_for_two_race()
        {
            var raceRecord = new string[]
            {
                $"Time:     3 4",
                $"Distance: 1 3"
            };

            var count = new RaceRecordAnalyser(raceRecord).GetNumberOfWaysToWinPart1();

            Check.That(count).IsEqualTo(2);
        }

        [Fact]
        public void Part_1_Example()
        {
            var raceRecord = new string[]
            {
                $"Time:     7  15   30",
                $"Distance: 9  40  200"
            };

            var count = new RaceRecordAnalyser(raceRecord).GetNumberOfWaysToWinPart1();

            Check.That(count).IsEqualTo(288);
        }

        [Fact(Skip = "Input file is not provided according to the will of the adventOfCode author")]
        public void Part_1_Input()
        {
            var raceRecord = File.ReadAllLines("./Resources/Input.txt");

            var count = new RaceRecordAnalyser(raceRecord).GetNumberOfWaysToWinPart1();

            Check.That(count).IsEqualTo(140220);
        }

        [Fact]
        public void Part_2_Example()
        {
            var raceRecord = new string[]
            {
                $"Time:     71530",
                $"Distance: 940200"
            };

            var count = new RaceRecordAnalyser(raceRecord).GetNumberOfWaysToWinPart1();

            Check.That(count).IsEqualTo(71503);
        }

        [Fact(Skip = "Input file is not provided according to the will of the adventOfCode author")]
        public void Part_2_Input()
        {
            var raceRecord = File.ReadAllLines("./Resources/Input.txt");

            var count = new RaceRecordAnalyser(raceRecord).GetNumberOfWaysToWinforPart2();

            Check.That(count).IsEqualTo(39570185);
        }
    }
}
