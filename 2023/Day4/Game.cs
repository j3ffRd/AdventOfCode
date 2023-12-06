using NFluent;

namespace Day4
{
    internal class Game
    {
        private readonly IList<string> _scratchcards;

        internal Game(IList<string> scratchcards)
        {
            _scratchcards = scratchcards;
        }

        internal int GetScore()
        {
            return GetMatchingNumbers().Select(number => (int)Math.Pow(2D, number - 1))
                                       .Sum();           
        }

        internal int GetTotalScratchCardsCount()
        {
            var matchingNumbers = GetMatchingNumbers();

            var counts = new int[matchingNumbers.Count];

            Array.Fill(counts, 1);

            for (int i = 0; i < matchingNumbers.Count; i++)
            {
                var copyCount = counts[i];

                while(copyCount > 0)
                {
                    var matchingNumber = matchingNumbers[i];

                    while (matchingNumber > 0)
                    {
                        counts[matchingNumber + i]++;
                        matchingNumber--;
                    }

                    copyCount--;
                }                
            }

            return counts.Sum();
        }

        private IList<int> GetMatchingNumbers()
        {
            return _scratchcards.Select((string card, int i) =>
            {
                var allItems = card.Replace($"Card {i + 1}: ", "")
                                   .Replace(" | ", " ")
                                   .Trim()
                                   .Split(' ')
                                   .Where(x => x != string.Empty);

                var uniqueItems = new HashSet<string>(allItems);

                return allItems.Count() - uniqueItems.Count;
            }).ToList();
        }
    }
}
