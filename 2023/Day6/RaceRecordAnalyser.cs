namespace Day6
{
    internal partial class RaceRecordAnalyser
    {
        private readonly RaceRecordParser _parser;

        public RaceRecordAnalyser(string[] raceRecord)
        {
            _parser = new RaceRecordParser(raceRecord);
        }

        internal long GetNumberOfWaysToWinPart1()
        {
            return _parser.GetRaceRecords()
                          .Select(GetGetNumberOfWaysToWinARace)
                          .Aggregate(1L, (total, next) => total * next);
        }

        internal long GetNumberOfWaysToWinforPart2()
        {
            return _parser.GetRaceRecordsPart2()
                          .Select(GetGetNumberOfWaysToWinARace)
                          .Aggregate(1L, (total, next) => total * next);
        }

        private long GetGetNumberOfWaysToWinARace((long Time, long Distance) record)
        {
            var holdTime = 0;
            var wayOfWinCount = 0;

            while (holdTime < record.Time)
            {
                var distance = (record.Time - holdTime) * holdTime;

                if (distance > record.Distance)
                {
                    wayOfWinCount++;
                }

                holdTime++;
            }

            return wayOfWinCount;
        }
    }
}
