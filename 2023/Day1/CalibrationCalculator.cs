namespace Day1
{
    internal class CalibrationCalculator
    {
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

        protected virtual bool IsADigit(string input, out int digit)
        {
            return IsADigit(input.First(), out digit);           
        }

        protected virtual bool IsADigit(char character, out int digit)
        {
            return int.TryParse(character.ToString(), out digit);
        }        
    }
}
