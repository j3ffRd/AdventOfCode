namespace Day3
{
    internal class SchemaParser
    {
        private readonly string[] _schema;

        public SchemaParser(string[] schema)
        {
            _schema = schema;
        }

        public IEnumerable<Symbol> GetAllSymlbols()
        {
            return ParseSchema().SelectMany(x => x.Value);
        }

        public IList<Symbol> GetSymbols(char character)
        {
            var dico = ParseSchema();
            dico.TryGetValue(character, out IList<Symbol>? symbols);
            return symbols ?? new List<Symbol>();
        }

        private Dictionary<char, IList<Symbol>> ParseSchema()
        {
            Dictionary<char, IList<Symbol>> dico = new();

            for (int i = 0; i < _schema.Length; i++)
            {
                int currentNumber = 0;
                Symbol? adjacentSymbol = null;

                for (int j = 0; j < _schema[i].Length; j++)
                {
                    if (IsDigit(_schema[i][j], out int digit))
                    {
                        currentNumber = currentNumber * 10 + digit;
                        adjacentSymbol = adjacentSymbol ?? SymbolDetector.GetAdjacentSymbol(_schema, i, j);
                    }

                    if (EndOfLine(i, j) || NextCharacterNotADigit(i, j))
                    {
                        if (currentNumber != 0 && adjacentSymbol != null)
                        {
                            adjacentSymbol.AddNumber(currentNumber);
                            AddOrUpdateSymbol(dico, adjacentSymbol);
                        }

                        currentNumber = 0;
                        adjacentSymbol = null;
                    }
                }
            }

            return dico;
        }

        private void AddOrUpdateSymbol(Dictionary<char, IList<Symbol>> dico, Symbol adjacent)
        {
            if (dico.ContainsKey(adjacent.Character))
            {
                var symbol = dico[adjacent.Character].FirstOrDefault(s => s.Equals(adjacent));
                
                if (symbol != null)
                {
                    symbol.AddNumber(adjacent.AdjacentNumbers.First());
                }
                else
                {
                    dico[adjacent.Character].Add(adjacent);
                }
            }
            else
            {
                dico.Add(adjacent.Character, new List<Symbol> { adjacent });
            }
        }

        private bool EndOfLine(int line, int index)
        {
            return index == _schema[line].Length - 1;
        }

        private bool IsDigit(char character, out int digit)
        {
            return int.TryParse(character.ToString(), out digit);
        }

        private bool NextCharacterNotADigit(int line, int index)
        {
            return !IsDigit(_schema[line][index + 1], out int _);
        }
    }
}
