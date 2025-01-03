public static class Advent23_01 {
    public static string GetResult(string[] input) {
        LanGraph Graph = new(input);
        Graph.SetAllConnections();
        Graph.PrintAllConnections();
        return Graph.GetConnectedCount().ToString();
    }
}