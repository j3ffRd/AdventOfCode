namespace Day1
{
    internal class CalibrationCalculator
    {
        private readonly Dictionary<string, int> _dico = new Dictionary<string, int>{
            {"one", 1}, {"two", 2},{"three", 3}, {"four", 4}, 
            {"five", 5}, {"six", 6}, {"seven", 7}, {"eight", 8}, {"nine", 9}
        };

        internal int GetSumOfCalibration(string input)
        {
            var lines = input.Split("\r\n");
            return lines.Sum(GetCalibration);
        }

        private int GetCalibration(string input)
        {
            return GetDigitsFromStart(input).FirstOrDefault() * 10 + GetDigitsFromEnd(input).FirstOrDefault();
        }

        private IEnumerable<int> GetDigitsFromStart(string input)
        {
            for (int index = 0; index < input.Length; index++)
            {
                if (IsADigit(input.Substring(index), out int digit))
                {
                    yield return digit;
                }
            }
        }

        private IEnumerable<int> GetDigitsFromEnd(string input)
        {
            for (int index = input.Length-1; index >= 0; index--)
            {
                if (IsADigit(input.Substring(index), out int digit))
                {
                    yield return digit;
                }
            }
        }

        private bool IsADigit(string input, out int digit)
        {
            return IsADigit(input.First(), out digit) || StartsWithDigitSpelledInLetters(input, out digit);           
        }

        private bool IsADigit(char character, out int digit)
        {
            return int.TryParse(character.ToString(), out digit);
        }

        private bool StartsWithDigitSpelledInLetters(string input, out int digit)
        {
            var digitInLetters = _dico.Keys.FirstOrDefault(input.StartsWith) ?? "";
            return _dico.TryGetValue(digitInLetters, out digit);
        }
    }
}
