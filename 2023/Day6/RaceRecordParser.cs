namespace Day6
{
    internal partial class RaceRecordAnalyser
    {
        internal class RaceRecordParser
        {
            private readonly string[] _raceRecord;

            public RaceRecordParser(string[] raceRecord)
            {
                _raceRecord = raceRecord;
            }

            public IList<(long Time, long Distance)> GetRaceRecords()
            {
               var distances = GetDistances();

               return GetTimes().Select((time, i) => (Time: time, Distance: distances[i])).ToList();
            }

            public IList<(long Time, long Distance)> GetRaceRecordsPart2()
            {
                var time = long.Parse(string.Join("", GetTimes()));
                var distance = long.Parse(string.Join("", GetDistances()));

                return new List<(long Time, long Distance)> { (Time: time, Distance: distance) };
            }

            private IEnumerable<long> GetTimes()
            {
                return _raceRecord[0].Replace("Time:", "")
                                     .Split(' ')
                                     .Where(x => x != string.Empty)
                                     .Select(long.Parse);
            }

            private IList<long> GetDistances()
            {
                return _raceRecord[1].Replace("Distance:", "")
                                     .Split(' ')
                                     .Where(x => x != string.Empty)
                                     .Select(long.Parse)
                                     .ToList();
            }
        }
    }
}
