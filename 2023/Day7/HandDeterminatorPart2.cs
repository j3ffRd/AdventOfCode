namespace Day7
{
    internal class HandDeterminatorPart2 : IHandDeterminator
    {
        private IHandDeterminator _handDeterminator { get; set; }

        public HandDeterminatorPart2()
        {
            _handDeterminator = new HandDeterminator();
        }

        public HandType GetHandType(string value)
        {
            var hand = value.Contains('J') && !value.All(x => x == 'J') ? GetNewValue(value) : value;           

            return _handDeterminator.GetHandType(hand);
        }

        private string GetNewValue(string value)
        {
            var cardToReplace = value.GroupBy(x => x)
                                     .Where(y => y.Key != 'J')
                                     .MaxBy(g => g.Count())
                                     !.First();

            return value.Replace('J', cardToReplace);
        }
    }
}
