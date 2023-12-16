namespace Day5
{
    internal record Convertor
    {
        public Range SourceRange { get; private set; }
        public Range DestinationRange { get; private set; }

        public Convertor(long destination, long source, long rangeLength)
        {
            SourceRange = new Range(source, source + rangeLength - 1);
            DestinationRange = new Range(destination, destination + rangeLength - 1);
        }

        public long Convert(long source)
        {
            var gap = source - SourceRange.Min;
            return DestinationRange.Min + gap;
        }

        public Range Convert(Range sourceRange)
        {
            var min = Math.Max(SourceRange.Min, sourceRange.Min);
            var max = Math.Min(SourceRange.Max, sourceRange.Max);

            var destinationMin = Convert(min);
            var destinationMax = Convert(max);

            return new Range(destinationMin, destinationMax);
        }

        public bool Contains(long seed)
        {
            return SourceRange.Contains(seed);
        }

        public bool Contains(Range sourceRange)
        {
            return Contains(sourceRange.Min) || Contains(sourceRange.Max);
        }
    };
}
