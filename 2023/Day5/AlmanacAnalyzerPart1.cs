namespace Day5
{
    internal class AlmanacAnalyzerPart1
    {
        private readonly AlmanacParser _parser;

        public AlmanacAnalyzerPart1(string[] almanac)
        {
            _parser = new AlmanacParser(almanac);
        }

        internal long GetLowestDestination()
        {
            var seeds = _parser.GetSeeds();

            var allMaps = _parser.GetAllMaps();

            return seeds.Min(seed => GetLowestDestination(seed, allMaps));
        }    

        private long GetLowestDestination(long source, IList<Map> allMaps)
        {
            if (allMaps.Count() == 0)
            {
                return source;
            }

            var destination = GetDestination(allMaps.First().Convertors, source).First();

            return GetLowestDestination(destination, allMaps.Skip(1).ToList());         
        }

        private IEnumerable<long> GetDestination(IEnumerable<Convertor> convertors, long source)
        {
            foreach (var convertor in convertors)
            {
                if (convertor.Contains(source))
                {
                    yield return convertor.Convert(source);
                }
            }

            yield return source;
        }
    }
}
