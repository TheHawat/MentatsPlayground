
public class LanGraphTwo {
    Dictionary<string, List<string>> _nodes = [];
    List<string[]> _connections = [];
    string[] _biggestLan = [];
    List<string[]> _checked = [];
    public LanGraphTwo(string[] input) {
        foreach (var line in input) AddPair(line);
    }

    private void AddPair(string line) {
        string[] Pair = line.Split('-');
        foreach (var computer in Pair) {
            if (!_nodes.ContainsKey(computer)) _nodes.Add(computer, []);
        }
        if (!_nodes[Pair[0]].Contains(Pair[1])) _nodes[Pair[0]].Add(Pair[1]);
        if (!_nodes[Pair[1]].Contains(Pair[0])) _nodes[Pair[1]].Add(Pair[0]);
    }

    private void FindConnection(string node, string[] CurrentLan) {
        if (CurrentLan.Contains(node)) return;
        if (CurrentLan.Length > _biggestLan.Length) _biggestLan = CurrentLan;
        Array.Sort(CurrentLan);
        if (_checked.Contains(CurrentLan)) return;
        if (CurrentLan.Length > 0) _checked.Add(CurrentLan);
        foreach (var computer in CurrentLan) {
            if (!_nodes[node].Contains(computer)) return;
        }
        string[] NextLan = [.. CurrentLan, node];
        foreach (var comp in NextLan) Console.Write(comp + "   ");
        Console.WriteLine();
        foreach (var computer in _nodes[node]) {
            FindConnection(computer, NextLan);
        }
    }

    public void SetAllConnections() {
        var Seen = new HashSet<string>(StringComparer.Ordinal);
        var Result = new List<string[]>();
        foreach (var node in _nodes) FindConnection(node.Key, []);
        foreach (var con in _connections) {
            Array.Sort(con);
            string identifier = string.Join("", con);
            if (Seen.Add(identifier)) {
                Result.Add(con);
            }
        }
        _connections = Result;
    }

    public void PrintAllConnections() {
        foreach (var con in _connections) {
            Console.WriteLine($"{con[0]}, {con[1]}, {con[2]}");
        }
        foreach (var nod in _nodes) {
            Console.WriteLine($"NodeCount:  {nod.Key}  {nod.Value.Count}");
        }
        Console.WriteLine(_biggestLan.Length);
        foreach (var comp in _biggestLan) Console.Write(comp + ",");
    }

    public int GetConnectedCount() {
        return _connections.Count;
    }
}