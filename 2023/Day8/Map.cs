namespace Day8
{
    internal class Map
    {
        private IList<char> _instructions;
        private IDictionary<string, NetworkStep> _steps;

        public Map(string[] map)
        {
            var parser = new Parser(map);
            _instructions = parser.GetInstruction().ToList();
            _steps = parser.GetSteps();
        }

        internal long GetStepCountPart1()
        {
            return GetStepCount("AAA");
        }

        internal long GetStepCountPart2()
        {
            var steps = _steps.Where(x => x.Key.EndsWith("A")).Select(x => x.Value).ToList();

            var counts = steps.Select(step => GetStepCount(step.Name)).ToList();

            return GetLeastCommonMultiple(counts);
        }

        private long GetStepCount(string start)
        {
            long count = 0;

            var currentStep = _steps[start];

            while(!currentStep.Name.EndsWith("Z"))
            {
                for (var i = 0; i < _instructions.Count; i++)
                {
                    count = count + 1;

                    var direction = currentStep.GetDirection(_instructions[i]);

                    currentStep = _steps[direction];

                    if (currentStep.Name.EndsWith("Z"))
                    {
                        break;
                    }
                }
            }     

            return count;
        }

        private long GetLeastCommonMultiple(IList<long> counts)
        {
            var max = counts.Max();
            var result = max;

            while (!counts.All(count => result % count == 0))
            {
                result += max;
            }

            return result;
        }
    }
}
