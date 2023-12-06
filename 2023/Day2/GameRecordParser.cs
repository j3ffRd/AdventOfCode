public static class GameRecordParser
{
    internal static GameRecord Parse(string game)
    {
        var parts = game.Split(':');

        var gameIdString = parts[0].Replace("Game", "").Trim();

        var gameSets = GetGameSet(parts[1].Trim());        

        return new GameRecord(int.Parse(gameIdString), gameSets);
    }

    private static IEnumerable<GameSet> GetGameSet(string setsString)
    {
        var sets = setsString.Split(';').Where(x => x != string.Empty);
        
        return sets.Select(set =>
        {
            var cubes = GetGameCubes(set);
            return new GameSet(cubes);
        });
    }

    private static IEnumerable<GameCube> GetGameCubes(string set)
    {
        var setParts = set.Split(',');

        return setParts.Select(part => {
            var p = part.Split(' ').Where(x => x != string.Empty).ToList();

            return new GameCube(p[1], int.Parse(p[0]));
        });
    }
}
