using NFluent;
using Xunit;

namespace Day8.Tests
{
    public class MapPart2Tests
    {
        [Fact]
        public void Should_navigate_left_from_XXA_to_XXZ_with_one_starting_point()
        {
            var input = new string[]
            {
                "L",
                "",
                "11A = (22Z, XXX)",
                "22Z = (22Z, 22Z)",
            };

            var count = new Map(input).GetStepCountPart2();

            Check.That(count).IsEqualTo(1);
        }

        [Fact]
        public void Should_navigate_right_from_XXA_to_XXZ_with_one_starting_point()
        {
            var input = new string[]
            {
                "R",
                "",
                "11A = (XXX, 22Z)",
                "22Z = (22Z, 22Z)"
            };

            var count = new Map(input).GetStepCountPart2();

            Check.That(count).IsEqualTo(1);
        }

        [Fact]
        public void Should_navigate_from_XXA_to_XXZ_with_two_starting_points()
        {
            var input = new string[]
            {
                "R",
                "",
                "11A = (XXX, 22Z)",
                "22Z = (22Z, 22Z)",
                "22A = (XXX, 22Z)",
            };

            var count = new Map(input).GetStepCountPart2();

            Check.That(count).IsEqualTo(1);
        }

        [Fact]
        public void Should_continue_until_all_path_reach_end_simultaneously()
        {
            var input = new string[]
            {
                "R",
                "",
                "11A = (XXX, 22Z)",
                "22Z = (22Z, FFT)",
                "FFT = (22Z, 22Z)",
                "22A = (XXX, BBC)",
                "BBC = (XXX, 22Z)",
            };

            var count = new Map(input).GetStepCountPart2();

            Check.That(count).IsEqualTo(2);
        }

        [Fact]
        public void Example_Part_2_returns_6()
        {
            var input = new string[]
            {
                "LR",
                "",
                "11A = (11B, XXX)",
                "11B = (XXX, 11Z)",
                "11Z = (11B, XXX)",
                "22A = (22B, XXX)",
                "22B = (22C, 22C)",
                "22C = (22Z, 22Z)",
                "22Z = (22B, 22B)",
                "XXX = (XXX, XXX)",
            };

            var count = new Map(input).GetStepCountPart2();

            Check.That(count).IsEqualTo(6);
        }
    }
}
