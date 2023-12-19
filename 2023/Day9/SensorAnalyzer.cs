namespace Day9
{
    internal class SensorAnalyzer
    {
        private readonly List<string> _input;

        public SensorAnalyzer(List<string> input)
        {
            _input = input;
        }

        internal int GetSumOfNextExtrapolatedValues()
        {
            var values = GetSequences();
            return values.Sum(GetNextValue);
        }

        internal int GetSumOfFirstExtrapolatedValues()
        {
            var values = GetSequences();
            return values.Sum(GetFirstValue);
        }

        private int GetNextValue(int[] sequence)
        {
            if(sequence.All(x => x == 0))
            {
                return 0;
            }

            var newSequence = GenerateNewSequence(sequence);

            return sequence[sequence.Length - 1] + GetNextValue(newSequence);
        }

        private int GetFirstValue(int[] sequence)
        {
            if (sequence.All(x => x == 0))
            {
                return 0;
            }

            var newSequence = GenerateNewSequence(sequence);

            return sequence[0] - GetFirstValue(newSequence);
        }

        private int[] GenerateNewSequence(int[] sequence)
        {
            var newSequence = new int[sequence.Length - 1];

            for (int i = 0; i < sequence.Length - 1; i++)
            {
                newSequence[i] = sequence[i + 1] - sequence[i];
            }

            return newSequence;
        }

        private int[][] GetSequences()
        {
            return _input.Select(line => line.Split(' ').Select(num => int.Parse(num)).ToArray()).ToArray();
        }
    }
}
