namespace Day7
{
    internal class HandParser
    {
        private string[] _hands;

        public HandParser(string[] hands)
        {
            _hands = hands;
        }

        public IList<Hand> GetHands(IHandDeterminator handDeterminator)
        {
            return _hands.Select(hand =>
            {
                var split = hand.Split(' ');
                return new Hand(split[0], int.Parse(split[1]), handDeterminator.GetHandType(split[0]));
            }).ToList();
        }
    }
}
