namespace Day5
{
    internal class Range
    {
        readonly long _min;
        readonly long _max;
        
        public long Min { get { return _min; } }
        public long Max { get { return _max; } }

        public Range(long min, long max)
        {
            _min = min;
            _max = max;
        }

        public bool Contains(long number)
        {
            return Min <= number && Max >= number;
        }

        public bool IsOverlappedRight(Range range)
        {
            return (range.Max > Max && range.Min <= Max);
        }

        public bool IsOverlappedLeft(Range range)
        {
            return range.Min < Min && range.Max >= Min;
        }
    }
}
