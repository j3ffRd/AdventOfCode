namespace Day5
{
    internal record Map
    {
        private IList<Convertor> _convertors = new List<Convertor>();
        public IEnumerable<Convertor> Convertors { get { return _convertors;} }

        public void Add(Convertor convertor)
        {
            _convertors.Add(convertor);
            _convertors = _convertors.OrderBy(x => x.SourceRange.Min).ToList();
        }
    };
}
