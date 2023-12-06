using NFluent;
using Xunit;

namespace Day4
{
    public class CardDeskTests
    {
        [Fact]
        public void A_Card_returns_Zero_When_No_Numbers_are_Wining_Numbers()
        {
            var cards = new List<string> { "Card 1: 41 | 10" };
            Check.That(GetScore(cards)).IsEqualTo(0);
        }

        [Fact]
        public void A_Card_returns_One_When_One_Numbers_is_Wining_Number()
        {
            var cards = new List<string> { "Card 1: 41 | 41" };
            Check.That(GetScore(cards)).IsEqualTo(1);
        }

        [Fact]
        public void A_Card_returns_Two_When_Two_Numbers_are_Wining_Numbers()
        {
            var cards = new List<string> { "Card 1: 41 42 | 41 42" };
            Check.That(GetScore(cards)).IsEqualTo(2);
        }

        [Fact]
        public void A_Card_returns_Four_When_Three_Numbers_are_Wining_Numbers()
        {
            var cards = new List<string> { "Card 1: 41 42 43 | 41 42 43" };
            Check.That(GetScore(cards)).IsEqualTo(4);
        }

        [Fact]
        public void A_Card_returns_Eight_When_Four_Numbers_are_Wining_Numbers()
        {
            var cards = new List<string> { "Card 1: 41 42 43 44 | 41 42 43 44" };
            Check.That(GetScore(cards)).IsEqualTo(8);
        }

        [Fact]
        public void Should_Sum_All_Cards_Score()
        {
            var cards = new List<string> 
            { 
                "Card 1: 41 42 43 44 | 41 42 43 44" ,
                "Card 2: 41 42 43 01 | 41 42 43 02" ,
            };

            Check.That(GetScore(cards)).IsEqualTo(12);
        }

        [Fact]
        public void Part1_Example_Returns_13()
        {
            var cards = new List<string>
            {
                "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53",
                "Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19",
                "Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1",
                "Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83",
                "Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36",
                "Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11",
            };

            Check.That(GetScore(cards)).IsEqualTo(13);
        }

        [Fact]
        public void A_List_Of_Two_Cards_With_One_Matching_Number_Returns_three()
        {
            var cards = new List<string> 
            {
                "Card 1: 41 | 41",
                "Card 2: 41 | 10",
            };

            Check.That(GetTotalScratchCardsCount(cards)).IsEqualTo(3);
        }

        [Fact]
        public void A_List_Of_Three_Cards_With_Two_Matching_Number_Returns_six()
        {
            var cards = new List<string>
            {
                "Card 1: 41 | 41",
                "Card 2: 41 | 41",
                "Card 3: 41 | 10",
            };

            Check.That(GetTotalScratchCardsCount(cards)).IsEqualTo(6);
        }

        [Fact]
        public void Part2_Example_Returns_30()
        {
            var cards = new List<string>
            {
                "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53",
                "Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19",
                "Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1",
                "Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83",
                "Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36",
                "Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11",
            };

            Check.That(GetTotalScratchCardsCount(cards)).IsEqualTo(30);
        }

        private int GetScore(IList<string> cards)
        {
            return new Game(cards).GetScore();
        }

        private int GetTotalScratchCardsCount(IList<string> cards)
        {
            return new Game(cards).GetTotalScratchCardsCount();
        }        
    }
}
