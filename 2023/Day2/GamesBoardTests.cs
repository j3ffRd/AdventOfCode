using NFluent;
using Xunit;

namespace Day2
{
    public class GamesBoardTests
    {
        [Fact]
        public void A_GameBoard_With_No_Games_Returns_Zero()
        {
            var games = Array.Empty<string>();
            Check.That(GetSumOfPossibleGamesIds(games)).IsEqualTo(0);
        }

        [Fact]
        public void A_GameBoard_With_One_Valid_Game_Returns_The_Game_Id()
        {
            var games = new string[] { "Game 1: 3 blue;" };
            Check.That(GetSumOfPossibleGamesIds(games)).IsEqualTo(1);
        }

        [Fact]
        public void A_GameBoard_With_One_Invalid_Game_Returns_Zero()
        {
            var games = new string[] { "Game 1: 3 blue;" };
            var rules = new Dictionary<string, int> { { "blue", 2 } };
            Check.That(GetSumOfPossibleGamesIds(games, rules)).IsEqualTo(0);
        }

        [Fact]
        public void A_GameBoard_With_A_Game_With_Two_Valid_Sets_Returns_The_Game_Id()
        {
            var games = new string[] { "Game 1: 3 blue; 4 red" };
            var rules = new Dictionary<string, int> { { "blue", 4 }, { "red", 5 } };
            Check.That(GetSumOfPossibleGamesIds(games, rules)).IsEqualTo(1);
        }

        [Fact]
        public void A_GameBoard_With_Two_Valid_Games_Returns_The_Sum_Of_The_Game_Ids()
        {
            var games = new string[] { "Game 1: 3 blue;" , "Game 2: 3 blue;" };
            var rules = new Dictionary<string, int> { { "blue", 4 }};
            Check.That(GetSumOfPossibleGamesIds(games, rules)).IsEqualTo(3);
        }

        [Fact]
        public void A_GameBoard_With_One_Valid_Game_And_One_Invalid_Game_Returns_The_Valid_Game_Id()
        {
            var games = new string[] { "Game 1: 5 blue;", "Game 2: 3 blue;" };
            var rules = new Dictionary<string, int> { { "blue", 4 } };
            Check.That(GetSumOfPossibleGamesIds(games, rules)).IsEqualTo(2);
        }

        [Fact]
        public void Day2_Part_One_Example_Returns_Eight()
        {
            var games = new string[] 
            {
                "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green",
                "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue",
                "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red",
                "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red",
                "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green"
            };

            Check.That(GetSumOfPossibleGamesIds(games)).IsEqualTo(8);
        }

        [Fact]
        public void Day2_Part_Two_Example_Returns_2286()
        {
            var games = new string[]
           {
                "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green",
                "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue",
                "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red",
                "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red",
                "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green"
           };

            Check.That(GetMaxPower(games)).IsEqualTo(2286);
        }

        private int GetSumOfPossibleGamesIds(string[] games, Dictionary<string, int>? rules = null)
        {
            rules = rules != null ? rules : new Dictionary<string, int> { { "red", 12 }, { "green", 13 }, { "blue", 14 } };
            return new GameBoard(rules, games).GetSumOfPossibleGamesIds();
        }

        private int GetMaxPower(string[] games)
        {
            var rules = new Dictionary<string, int> { { "red", 12 }, { "green", 13 }, { "blue", 14 } };
            return new GameBoard(rules, games).GetSumOfSetsPower();
        }
    }
}
