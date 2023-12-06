namespace Day2
{
    internal class GameBoard
    {
        private readonly Dictionary<string, int> _rules;
        private string[] _games;

        public GameBoard(Dictionary<string, int> rules, string[] games)
        {
            _rules = rules;
            _games = games;
        }

        internal int GetSumOfPossibleGamesIds()
        {
            return _games.Select(GameRecordParser.Parse)
                         .Where(game => game.IsValid(_rules))
                         .Sum(x => x.Id);
        }

        internal int GetSumOfSetsPower()
        {
            return _games.Select(GameRecordParser.Parse)
                         .Select(game => game.GetMinimumColorCounts())
                         .Sum(cubes => cubes.Aggregate(1, (total, next) => total * next.Count));
        }
    }
}
