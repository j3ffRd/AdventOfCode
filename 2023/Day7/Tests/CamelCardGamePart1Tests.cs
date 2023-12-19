using NFluent;
using Xunit;

namespace Day7.Tests
{
    public class CamelCardGamePart1Tests
    {
        [Fact]
        public void A_one_hand_game_return_the_bid()
        {
            var hands = new string[]
            {
                "12345 2",
            };

            var total = new CamelCardGame(hands).GetTotalWinPart1();

            Check.That(total).IsEqualTo(2);
        }

        [Fact]
        public void Two_hands_of_same_type_are_ranked_by_the_first_card()
        {
            var hands = new string[]
            {
                "23456 100000000",
                "34567 50000000",
                "45678 10000000",
                "59234 5000000",
                "69234 1000000",
                "79234 500000",
                "89234 100000",
                "99234 50000",
                "T9234 10000",
                "J9234 5000",
                "Q9234 1000",
                "K9234 500",
                "A9234 10",
            };

            var total = new CamelCardGame(hands).GetTotalWinPart1();

            Check.That(total).IsEqualTo(259490620);
        }

        [Fact]
        public void Two_hands_of_same_type_are_ranked_by_the_next_card_when_first_cards_are_equal()
        {
            var hands = new string[]
            {
                "13345 10",
                "12345 2",
            };

            var total = new CamelCardGame(hands).GetTotalWinPart1();

            Check.That(total).IsEqualTo(22);
        }

        [Fact]
        public void A_pair_has_higher_rank_than_a_highCard()
        {
            var hands = new string[]
            {
                "A234A 1",
                "K1345 10",
            };

            var total = new CamelCardGame(hands).GetTotalWinPart1();

            Check.That(total).IsEqualTo(12);
        }

        [Fact]
        public void A_two_pairs_has_higher_rank_than_one_pair()
        {
            var hands = new string[]
            {
                "A224A 1",
                "KK345 10",
            };

            var total = new CamelCardGame(hands).GetTotalWinPart1();

            Check.That(total).IsEqualTo(12);
        }

        [Fact]
        public void A_three_of_kind_has_higher_rank_than_two_pair()
        {
            var hands = new string[]
            {
                "A2221 1",
                "KK335 10",
            };

            var total = new CamelCardGame(hands).GetTotalWinPart1();

            Check.That(total).IsEqualTo(12);
        }

        [Fact]
        public void A_full_house_has_higher_rank_than_three_of_kind()
        {
            var hands = new string[]
            {
                "AA222 1",
                "KKK35 10",
            };

            var total = new CamelCardGame(hands).GetTotalWinPart1();

            Check.That(total).IsEqualTo(12);
        }

        [Fact]
        public void A_four_of_kind_has_higher_rank_than_full_house()
        {
            var hands = new string[]
            {
                "A2222 1",
                "KKK33 10",
            };

            var total = new CamelCardGame(hands).GetTotalWinPart1();

            Check.That(total).IsEqualTo(12);
        }

        [Fact]
        public void A_five_of_kind_has_higher_rank_than_four_of_kind()
        {
            var hands = new string[]
            {
                "22222 1",
                "KKKK3 10",
            };

            var total = new CamelCardGame(hands).GetTotalWinPart1();

            Check.That(total).IsEqualTo(12);
        }

        [Fact]
        public void Part1_Example()
        {
            var hands = new string[]
            {
                "32T3K 765",
                "T55J5 684",
                "KK677 28",
                "KTJJT 220",
                "QQQJA 483",
            };

            var total = new CamelCardGame(hands).GetTotalWinPart1();

            Check.That(total).IsEqualTo(6440);
        }

        [Fact(Skip = "Input file is not provided according to the will of the adventOfCode author")]
        public void Part1_Input()
        {
            var hands = File.ReadAllLines("./Resources/Input.txt");

            var total = new CamelCardGame(hands).GetTotalWinPart1();

            Check.That(total).IsEqualTo(247815719);
        }
    }
}
