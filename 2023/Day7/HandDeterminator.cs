namespace Day7
{
    internal interface IHandDeterminator
    {
        public HandType GetHandType(string value);
    }

    internal class HandDeterminator : IHandDeterminator
    {
        public HandType GetHandType(string value)
        {
            if (IsHighCard(value))
            {
                return HandType.HighCard;
            }

            if (IsOnePair(value))
            {
                return HandType.OnePair;
            }

            if (IsTwoPairs(value))
            {
                return HandType.TwoPairs;
            }

            if (IsThreeOfKind(value))
            {
                return HandType.ThreeOfKind;
            }

            if (IsFullHouse(value))
            {
                return HandType.FullHouse;
            }

            if (IsFourOfKind(value))
            {
                return HandType.FourOfKind;
            }

            if (IsFiveOfKind(value))
            {
                return HandType.FiveOfKind;
            }

            throw new InvalidOperationException($"Not expected handType: {value}");
        }

        private bool IsHighCard(string hand)
        {
            return hand.Distinct().Count() == hand.Length;
        }

        private bool IsOnePair(string hand)
        {
            return hand.Distinct().Count() == hand.Length - 1;
        }
        private bool IsTwoPairs(string hand)
        {
            var groups = hand.GroupBy(x => x);
            return groups.Count() == 3 && groups.Count(c => c.Count() == 2) == 2;
        }
        private bool IsThreeOfKind(string hand)
        {
            var groups = hand.GroupBy(x => x);
            return groups.Count() == 3 && groups.Count(c => c.Count() == 3) == 1;
        }
        private bool IsFullHouse(string hand)
        {
            var groups = hand.GroupBy(x => x);
            return groups.Count() == 2 && groups.Count(c => c.Count() == 3) == 1;
        }
        private bool IsFourOfKind(string hand)
        {
            var groups = hand.GroupBy(x => x);
            return groups.Count() == 2 && groups.Count(c => c.Count() == 4) == 1;
        }
        private bool IsFiveOfKind(string hand)
        {
           return hand.Distinct().Count() == 1;
        }
    }
}
