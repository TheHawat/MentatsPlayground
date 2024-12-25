public static class Advent23_02{
    public static string GetResult(string[] input){
        LanGraphTwo Graph = new(input);
        Graph.SetAllConnections();
        Graph.PrintAllConnections();
        return Graph.GetConnectedCount().ToString();
    }
}