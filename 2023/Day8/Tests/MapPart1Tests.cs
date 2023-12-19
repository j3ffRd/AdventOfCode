using NFluent;
using Xunit;

namespace Day8.Tests
{
    public class MapPart1Tests
    {
        [Fact]
        public void Should_navigate_left_in_the_network()
        {
            var input = new string[]
            {
                "L",
                "",
                "AAA = (ZZZ, CCC)",
                "ZZZ = (ZZZ, ZZZ)"
            };

            var count = new Map(input).GetStepCountPart1();

            Check.That(count).IsEqualTo(1);
        }

        [Fact]
        public void Should_navigate_right_in_the_network()
        {
            var input = new string[]
            {
                "R",
                "",
                "AAA = (CCC, ZZZ)",
                "ZZZ = (ZZZ, ZZZ)"
            };

            var count = new Map(input).GetStepCountPart1();

            Check.That(count).IsEqualTo(1);
        }

        [Fact]
        public void Should_navigate_with_instructions_until_the_ZZZ()
        {
            var input = new string[]
            {
                "RL",
                "",
                "AAA = (GGG, BBB)",
                "BBB = (ZZZ, CCC)",
                "ZZZ = (ZZZ, ZZZ)"
            };

            var count = new Map(input).GetStepCountPart1();

            Check.That(count).IsEqualTo(2);
        }

        [Fact]
        public void Should_navigate_until_the_ZZZ_direction_is_not_found()
        {
            var input = new string[]
            {
                "RL",
                "",
                "AAA = (GGG, BBB)",
                "BBB = (CCC, HHH)",
                "CCC = (HHH, ZZZ)",
                "ZZZ = (ZZZ, ZZZ)"
            };

            var count = new Map(input).GetStepCountPart1();

            Check.That(count).IsEqualTo(3);
        }


        [Fact]
        public void Example_Part_1()
        {
            var input = new string[]
            {
                "LLR",
                "",
                "AAA = (BBB, BBB)",
                "BBB = (AAA, ZZZ)",
                "ZZZ = (ZZZ, ZZZ)",
            };

            var count = new Map(input).GetStepCountPart1();

            Check.That(count).IsEqualTo(6);
        }

        [Fact(Skip = "Input file is not provided according to the will of the adventOfCode author")]
        public void Input_Part_1()
        {
            var input = File.ReadAllLines("./Resources/Input.txt");

            var count = new Map(input).GetStepCountPart1();

            Check.That(count).IsEqualTo(20093);
        }
    }
}
