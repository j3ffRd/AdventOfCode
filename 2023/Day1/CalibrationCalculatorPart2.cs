namespace Day1
{
    internal class CalibrationCalculatorPart2 : CalibrationCalculator
    {
        private readonly Dictionary<string, int> _dico = new Dictionary<string, int>{
            {"one", 1}, {"two", 2},{"three", 3}, {"four", 4}, 
            {"five", 5}, {"six", 6}, {"seven", 7}, {"eight", 8}, {"nine", 9}
        };

        protected override bool IsADigit(string input, out int digit)
        {
            return IsADigit(input.First(), out digit) || StartsWithDigitSpelledInLetters(input, out digit);           
        }

        private bool StartsWithDigitSpelledInLetters(string input, out int digit)
        {
            var digitInLetters = _dico.Keys.FirstOrDefault(input.StartsWith) ?? "";
            return _dico.TryGetValue(digitInLetters, out digit);
        }
    }
}
