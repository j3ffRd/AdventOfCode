using NFluent;
using Xunit;

namespace Day6
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
        public void Part_1_Example_returns_288()
        {
            var raceRecord = new string[]
            {
                $"Time:     7  15   30",
                $"Distance: 9  40  200"
            };

            var count = new RaceRecordAnalyser(raceRecord).GetNumberOfWaysToWinPart1();

            Check.That(count).IsEqualTo(288);
        }

        [Fact]
        public void Part_1_Input_returns_140220()
        {
            var raceRecord = new string[]
            {
                $"Time:     53     83     72     88",
                $"Distance: 333   1635   1289   1532"
            };

            var count = new RaceRecordAnalyser(raceRecord).GetNumberOfWaysToWinPart1();

            Check.That(count).IsEqualTo(140220);
        }

        [Fact]
        public void Part_2_Example_returns_71503()
        {
            var raceRecord = new string[]
            {
                $"Time:     71530",
                $"Distance: 940200"
            };

            var count = new RaceRecordAnalyser(raceRecord).GetNumberOfWaysToWinPart1();

            Check.That(count).IsEqualTo(71503);
        }

        [Fact]
        public void Part_2_Input_returns_39570185()
        {
            var raceRecord = new string[]
            {
                $"Time:     53     83     72     88",
                $"Distance: 333   1635   1289   1532"
            };

            var count = new RaceRecordAnalyser(raceRecord).GetNumberOfWaysToWinforPart2();

            Check.That(count).IsEqualTo(39570185);
        }
    }
}
