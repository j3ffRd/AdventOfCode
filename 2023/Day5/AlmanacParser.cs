namespace Day5
{
    internal class AlmanacParser
    {
        private readonly string[] _almanac;

        public AlmanacParser(string[] almanac)
        {
            _almanac = almanac;
        }

        public IList<long> GetSeeds()
        {
            return _almanac.First().Replace("seeds: ", "").Split(" ").Select(long.Parse).ToList();
        }

        public IList<Map> GetAllMaps()
        {
            var allMaps = _almanac.Skip(1);

            var maps = new List<Map>();

            foreach (var mapLine in allMaps.Where(x=> x != string.Empty)) 
            {
                if (mapLine.Contains("map"))
                {
                    maps.Add(new Map());
                    continue;
                }

                var lineStr = mapLine.Split(" ").Select(long.Parse).ToList();

                var convertor = new Convertor(lineStr[0], lineStr[1], lineStr[2]); 

                maps.Last().Add(convertor);
            }

            return maps;
        }

        public IList<Range> GetRangeSeed()
        {
            var numbers = GetSeeds();

            var result = new List<Range>();

            for (int i = 0; i < numbers.Count; i = i + 2)
            {
                var rangeLength = numbers[i + 1] - 1;
                var range = new Range(numbers[i], numbers[i] + rangeLength);
                result.Add(range);
            }

            return result;
        }
    }
}
