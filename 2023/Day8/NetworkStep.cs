namespace Day8
{
    internal record NetworkStep(string Name, string Left, string Right)
    {
        public string GetDirection(char c)
        {
            return c == 'R' ? Right : Left;
        }
    }
}
