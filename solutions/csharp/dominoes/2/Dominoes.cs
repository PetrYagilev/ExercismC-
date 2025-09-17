
public static class Dominoes
{
    public static bool CanChain(IReadOnlyCollection<(int, int)> dominoes) => 
        !dominoes.Any() || CanChain(dominoes, dominoes.First());
    private static bool CanChain(IEnumerable<(int, int)> dominoes, (int, int) firstDomino) => 
        CanChain(dominoes, firstDomino, firstDomino.Item1, firstDomino.Item2);
    private static bool CanChain(IEnumerable<(int, int)> originalDominoList, (int, int) lastDomino, int lastNumber, int goal)
    {
        var localDominoList = new List<(int,int)>(originalDominoList);
        localDominoList.Remove(lastDomino);
        return !localDominoList.Any()
            ? lastNumber == goal
            : localDominoList
                .Where(x => x.Item1 == lastNumber || x.Item2 == lastNumber)
                .Any(x => CanChain(localDominoList, x, x.Item1 == lastNumber ? x.Item2 : x.Item1, goal));
    }
}