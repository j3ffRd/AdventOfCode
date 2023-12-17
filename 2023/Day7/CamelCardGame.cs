namespace Day7
{
    internal class CamelCardGame
    {
        private HandParser _parser;

        public CamelCardGame(string[] hands)
        {
            _parser = new HandParser(hands);
        }

        internal int GetTotalWinPart1()
        {
            return _parser.GetHands(new HandDeterminator())
                  .OrderBy(hand => hand, new HandComparerPart1())
                  .Select((hand, i) => hand.Bid * (i + 1))
                  .Sum();
        }

        internal int GetTotalWinPart2()
        {
            return _parser.GetHands(new HandDeterminatorPart2())
                  .OrderBy(hand => hand, new HandComparerPart2())
                  .Select((hand, i) => hand.Bid * (i + 1))
                  .Sum();
        }
    }
}
