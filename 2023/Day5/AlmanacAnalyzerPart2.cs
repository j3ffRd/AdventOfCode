namespace Day5
{
    internal class AlmanacAnalyzerPart2
    {
        private readonly AlmanacParser _parser;

        public AlmanacAnalyzerPart2(string[] almanac)
        {
            _parser = new AlmanacParser(almanac);
        }

        internal long GetLowestDestinationRange()
        {
            var seeds = _parser.GetRangeSeed();

            var allMaps = _parser.GetAllMaps();

            var destinationRanges =  GetAllDestinationRanges(seeds, allMaps);

            return destinationRanges.MinBy(x => x.Min).Min;
        }  
        
        private IEnumerable<Range> GetAllDestinationRanges(IEnumerable<Range> sourceRanges, IEnumerable<Map> allMaps) 
        {
            if (allMaps.Count() == 0)
            {
                return sourceRanges;
            }

            var newRanges = sourceRanges.SelectMany(range => GetDestinationRanges(allMaps.First().Convertors.ToList(), range));

            return GetAllDestinationRanges(newRanges, allMaps.Skip(1));
        }

        private IList<Range> GetDestinationRanges(IList<Convertor> convertors, Range sourceRange)
        {
            var convertedRanges = GetConvertedRanges(convertors, sourceRange);

            var boundaryRanges = GetBoundaryRanges(convertors, sourceRange);

            var intermediaryRanges = GetIntermediaryRanges(convertors, sourceRange);

            if (convertedRanges.Count == 0)
            {
                convertedRanges.Add(new Range(sourceRange.Min, sourceRange.Max));
            }

            return convertedRanges.Concat(boundaryRanges).Concat(intermediaryRanges).ToList();
        }

        private IList<Range> GetConvertedRanges(IList<Convertor> convertors, Range sourceRange)
        {
            var ranges = new List<Range>();

            foreach (var convertor in convertors)
            {
                if (convertor.Contains(sourceRange))
                {
                    ranges.Add(convertor.Convert(sourceRange));
                }
            }

            return ranges;
        }

        private IList<Range> GetBoundaryRanges(IList<Convertor> convertors, Range sourceRange)
        {
            var ranges = new List<Range>();

            if (convertors.Last().SourceRange.IsOverlappedRight(sourceRange))
            {
                var range = new Range(convertors.Last().SourceRange.Max + 1, sourceRange.Max);
                ranges.Add(range);
            }

            if (convertors.First().SourceRange.IsOverlappedLeft(sourceRange))
            {
                var range = new Range(sourceRange.Min, convertors.First().SourceRange.Min - 1);
                ranges.Add(range);
            }

            return ranges;
        }

        private IList<Range> GetIntermediaryRanges(IList<Convertor> convertors, Range sourceRange)
        {
            var ranges = new List<Range>();

            for (int i = 0; i < convertors.Count - 1; i++)
            {
                if (AreNotContiguous(convertors[i], convertors[i + 1]))
                {
                    var gap = new Range(convertors[i].SourceRange.Max + 1, convertors[i + 1].SourceRange.Min - 1);

                    if (gap.Contains(sourceRange.Min) || gap.Contains(sourceRange.Max))
                    {
                        var min = Math.Max(gap.Min, sourceRange.Min);
                        var max = Math.Min(gap.Max, sourceRange.Max);

                        var range = new Range(min, max);
                        ranges.Add(range);
                    }
                }
            }

            return ranges;
        }

        private bool AreNotContiguous(Convertor convertor1, Convertor convertor2)
        {
            return convertor1.SourceRange.Max != convertor2.SourceRange.Min - 1;
        }
    }
}
