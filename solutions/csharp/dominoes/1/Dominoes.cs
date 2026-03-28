
public static class Dominoes
{
    public static bool CanChain(IEnumerable<(int, int)> dominoes)
    {
        var dominoList = dominoes.ToList();
        
        
        if (dominoList.Count == 0) return true;
        
       
        if (dominoList.Count == 1)
        {
            return dominoList[0].Item1 == dominoList[0].Item2;
        }
        
        
        var graph = new Dictionary<int, List<int>>();
        var degree = new Dictionary<int, int>();
        
        foreach (var (a, b) in dominoList)
        {
            
            if (!graph.ContainsKey(a)) graph[a] = new List<int>();
            if (!graph.ContainsKey(b)) graph[b] = new List<int>();
            graph[a].Add(b);
            graph[b].Add(a);
            
            
            degree[a] = degree.GetValueOrDefault(a, 0) + 1;
            degree[b] = degree.GetValueOrDefault(b, 0) + 1;
        }
        
        
        if (!IsConnectedGraph(graph, dominoList)) return false;
        
        
        int oddCount = 0;
        foreach (var count in degree.Values)
        {
            if (count % 2 != 0) oddCount++;
        }
        
        
        return oddCount == 0;
    }
    
    private static bool IsConnectedGraph(Dictionary<int, List<int>> graph, List<(int, int)> dominoes)
    {
        if (graph.Count == 0) return true;
        
        var visited = new HashSet<int>();
        var startNode = graph.Keys.First();
        
        DFS(graph, startNode, visited);
        
        
        var allNumbers = new HashSet<int>(dominoes.SelectMany(d => new[] { d.Item1, d.Item2 }));
        return visited.SetEquals(allNumbers);
    }
    
    private static void DFS(Dictionary<int, List<int>> graph, int node, HashSet<int> visited)
    {
        visited.Add(node);
        if (graph.ContainsKey(node))
        {
            foreach (var neighbor in graph[node])
            {
                if (!visited.Contains(neighbor))
                {
                    DFS(graph, neighbor, visited);
                }
            }
        }
    }
}