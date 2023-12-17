namespace Day8
{
    internal class Parser
    {
        public string[] _map { get; set; }

        public Parser(string[] map)
        {
            _map = map;
        }

        public string GetInstruction()
        {
            return _map[0];
        }

        public IDictionary<string, NetworkStep> GetSteps()
        {
            var list = _map.Skip(2).Select(elm =>
            {
                var name = elm.Substring(0, 3);
                var left = elm.Substring(7, 3);
                var right = elm.Substring(12, 3);

                return new NetworkStep(name, left, right);
            });

            return list.ToDictionary(x => x.Name);
        }
    }
}
