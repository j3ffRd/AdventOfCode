namespace Day3
{
    internal static class SymbolDetector
    {
        public static Symbol? GetAdjacentSymbol(string[] schema, int i, int j)
        {
            return GetSymbolAfter(schema, i, j)
                ?? GetSymbolBefore(schema, i, j)
                ?? GetSymbolUpperLeft(schema, i, j)
                ?? GetSymbolUpper(schema, i, j)
                ?? GetSymbolUpperRight(schema, i, j)
                ?? GetSymbolBelow(schema, i, j)
                ?? GetSymbolBelowLeft(schema, i, j)
                ?? GetSymbolBelowRight(schema, i, j);
        }

        private static Symbol? GetSymbolAfter(string[] schema, int i, int j)
        {
            return (j < schema[i].Length - 1) && IsSymbol(schema[i][j + 1]) 
                 ? new Symbol(schema[i][j + 1], i, j+1) 
                 : null;
        }

        private static Symbol? GetSymbolBefore(string[] schema, int i, int j)
        {
            return (j > 0) && IsSymbol(schema[i][j - 1]) 
                 ? new Symbol(schema[i][j - 1], i, j-1) 
                 : null;
        }

        private static Symbol? GetSymbolUpper(string[] schema, int i, int j)
        {
            return (i > 0) && IsSymbol(schema[i - 1][j]) 
                 ? new Symbol(schema[i-1][j], i-1, j) 
                 : null;
        }

        private static Symbol? GetSymbolUpperLeft(string[] schema, int i, int j)
        {
            return (i > 0 && j > 0) && IsSymbol(schema[i - 1][j - 1]) 
                 ? new Symbol(schema[i - 1][j-1], i-1, j-1) 
                 : null;
        }

        private static Symbol? GetSymbolUpperRight(string[] schema, int i, int j)
        {
            return (i > 0 && j < schema[i].Length - 1) && IsSymbol(schema[i - 1][j + 1]) 
                 ? new Symbol(schema[i - 1][j + 1], i-1, j+1) 
                 : null;
        }

        private static Symbol? GetSymbolBelow(string[] schema, int i, int j)
        {
            return (i < schema.Length - 1) && IsSymbol(schema[i + 1][j]) 
                 ? new Symbol(schema[i + 1][j], i+1, j) 
                 : null;
        }

        private static Symbol? GetSymbolBelowLeft(string[] schema, int i, int j)
        {
            return (i < schema.Length - 1 && j > 0) && IsSymbol(schema[i + 1][j - 1]) 
                 ? new Symbol(schema[i + 1][j - 1], i+1, j-1) 
                 : null;
        }

        private static Symbol? GetSymbolBelowRight(string[] schema, int i, int j)
        {
            return (i < schema.Length - 1 && j < schema[i].Length - 1) && IsSymbol(schema[i + 1][j + 1]) 
                 ? new Symbol(schema[i + 1][j + 1], i+1, j+1) 
                 : null;
        }

        private static bool IsSymbol(char character)
        {
            return character != '.' && !int.TryParse(character.ToString(), out int _);
        }
    }
}
