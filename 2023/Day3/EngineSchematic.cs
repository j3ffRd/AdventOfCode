namespace Day3
{
    internal class EngineSchematic
    {
        private SchemaParser _parser;

        public EngineSchematic(string[] schema)
        {
            _parser = new SchemaParser(schema);
        }

        internal int GetSumOfAllPartNumbers()
        {
            return _parser.GetAllSymlbols()
                          .SelectMany(x => x.AdjacentNumbers)
                          .Sum();
        }

        internal int GetSumOfAllGearRatios()
        {
            return _parser.GetSymbols('*')
                          .Where(symbol => symbol.AdjacentNumbers.Count() == 2)
                          .Select(symbol => symbol.AdjacentNumbers.ElementAt(0) * symbol.AdjacentNumbers.ElementAt(1))
                          .Sum();
        }
    }
}
