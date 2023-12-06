internal record GameCube(string Color, int Count);

internal record GameSet(IEnumerable<GameCube> Cubes);

internal record GameRecord(int Id, IEnumerable<GameSet> Sets)
{
    public bool IsValid(Dictionary<string, int> rules)
    {
        return Sets.All(gameSet =>
        {
            return gameSet.Cubes.All(cube =>
            {
                var rule = rules[cube.Color];
                return cube.Count <= rule;
            });
        });
    }

    public IEnumerable<GameCube> GetMinimumColorCounts()
    {
        return Sets.SelectMany(set => set.Cubes)
                   .GroupBy(cube => cube.Color)
                   .Select(group => group.MaxBy(x => x.Count));
    }
};
