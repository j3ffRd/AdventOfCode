namespace Day7
{
    internal class HandComparerPart1 : HandComparer
    {
        private static readonly IDictionary<char, int> _cardRanks = new Dictionary<char, int>
        {
           {'2', 2}, {'3', 3}, {'4', 4}, {'5', 5}, {'6', 6}, {'7', 7},
           {'8', 8}, {'9', 9}, {'T', 10}, {'J', 11}, {'Q', 12}, {'K', 13}, {'A', 14}
        };

        public HandComparerPart1() : base(_cardRanks)
        {                
        }
    }

    internal class HandComparerPart2 : HandComparer
    {
        private static readonly IDictionary<char, int> _cardRanks = new Dictionary<char, int>
        {
           {'J', 1}, {'2', 2}, {'3', 3}, {'4', 4}, {'5', 5}, {'6', 6}, {'7', 7},
           {'8', 8}, {'9', 9}, {'T', 10}, {'Q', 11}, {'K', 12}, {'A', 13}
        };

        public HandComparerPart2() : base(_cardRanks)
        {
        }
    }

    internal class HandComparer(IDictionary<char, int> CardRanks) : IComparer<Hand>
    {
        public int Compare(Hand handA, Hand handB)
        {
            var result = handA.Type.CompareTo(handB.Type);                
            return result == 0 ? CompareHandValues(handA.Value, handB.Value) : result;
        }

        private int CompareHandValues(string handA, string handB)
        {
            if(handA == string.Empty)
            {
                return 0;
            }

            if (CardRanks[handA[0]] == CardRanks[handB[0]])
            {
                return CompareHandValues(handA.Substring(1), handB.Substring(1));
            }

            return CardRanks[handA[0]] > CardRanks[handB[0]] ? 1 : -1;
        }
    }
}
