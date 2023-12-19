using NFluent;
using Xunit;

namespace Day7.Tests
{
    public class CamelCardGamePart2Tests
    {
        [Fact]
        public void A_Joker_should_be_the_weakest_card()
        {
            var hands = new string[]
            {
                "J25K6 10",
                "225K6 1",
            };

            var total = new CamelCardGame(hands).GetTotalWinPart2();

            Check.That(total).IsEqualTo(12);
        }

        [Fact]
        public void Should_Replace_a_Joker_to_get_two_pairs()
        {
            var hands = new string[]
            {
                "J5277 10",
                "KQ277 1",
            };

            var total = new CamelCardGame(hands).GetTotalWinPart2();

            Check.That(total).IsEqualTo(21);
        }

        [Fact]
        public void Should_Replace_a_Joker_to_get_three_of_kind()
        {
            var hands = new string[]
            {
                "J5582 10",
                "K8877 1",
            };

            var total = new CamelCardGame(hands).GetTotalWinPart2();

            Check.That(total).IsEqualTo(21);
        }

        [Fact]
        public void Should_Replace_a_Joker_to_get_full_house()
        {
            var hands = new string[]
            {
                "J5588 10",
                "88872 1",
            };

            var total = new CamelCardGame(hands).GetTotalWinPart2();

            Check.That(total).IsEqualTo(21);
        }

        [Fact]
        public void Should_Replace_a_Joker_to_get_four_of_kind()
        {
            var hands = new string[]
            {
                "J5558 10",
                "88877 1",
            };

            var total = new CamelCardGame(hands).GetTotalWinPart2();

            Check.That(total).IsEqualTo(21);
        }

        [Fact]
        public void Should_Replace_a_Joker_to_get_five_of_kind()
        {
            var hands = new string[]
            {
                "J5555 10",
                "88887 1",
            };

            var total = new CamelCardGame(hands).GetTotalWinPart2();

            Check.That(total).IsEqualTo(21);
        }

        [Fact]
        public void Part2_Example()
        {
            var hands = new string[]
            {
                "32T3K 765",
                "T55J5 684",
                "KK677 28",
                "KTJJT 220",
                "QQQJA 483",
            };

            var total = new CamelCardGame(hands).GetTotalWinPart2();

            Check.That(total).IsEqualTo(5905);
        }

        [Fact(Skip = "Input file is not provided according to the will of the adventOfCode author")]
        public void Part2_Input()
        {
            var hands = File.ReadAllLines("./Resources/Input.txt");

            var total = new CamelCardGame(hands).GetTotalWinPart2();

            Check.That(total).IsEqualTo(248747492);
        }
    }
}
