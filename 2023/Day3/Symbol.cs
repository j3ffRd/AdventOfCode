namespace Day3
{
    public class Symbol 
    {
        private IList<int> _adjacentNumbers;

        public char Character { get; }
        public int LineIndex { get; }
        public int CharacterIndex { get; }
        public IEnumerable<int> AdjacentNumbers { get { return _adjacentNumbers; } }

        public Symbol(char character, int lineIndex, int characterIndex)
        {
            Character = character;
            LineIndex = lineIndex;
            CharacterIndex = characterIndex;
            _adjacentNumbers = new List<int>();
        }

        public void AddNumber(int number)
        {
            _adjacentNumbers.Add(number);
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || obj is not Symbol)
            {
                return false;
            }

            var symbol = (Symbol)obj;

            return symbol.Character == Character 
                && symbol.LineIndex == LineIndex 
                && symbol.CharacterIndex == CharacterIndex;  
        }

        public override int GetHashCode()
        {
            return Character.GetHashCode() ^ LineIndex.GetHashCode() ^ CharacterIndex.GetHashCode();
        }
    };
}
