
public class LanGraph {
    Dictionary<string, List<string>> _nodes = [];
    List<string[]> _connections = [];
    public LanGraph(string[] input) {
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

    private void FindConnection(string node) {
        foreach (var computer_two in _nodes[node]) {
            foreach (var computer_three in _nodes[computer_two]) {
                if (_nodes[computer_three].Contains(node)) _connections.Add([node, computer_two, computer_three]);
            }
        }
    }

    public void SetAllConnections() {
        var Seen = new HashSet<string>(StringComparer.Ordinal);
        var Result = new List<string[]>();
        foreach (var node in _nodes) FindConnection(node.Key);
        foreach (var con in _connections) {
            Array.Sort(con);
            string identifier = string.Join("", con);
            if (Seen.Add(identifier)) {
                if (IsValid(con)) Result.Add(con);
            }
        }
        _connections = Result;
    }

    static bool IsValid(string[] input) {
        return input.Distinct().Count() == 3 &&
               input.Any(s => s.StartsWith('t'));
    }

    public void PrintAllConnections() {
        foreach (var con in _connections) {
            Console.WriteLine($"{con[0]}, {con[1]}, {con[2]}");
        }
    }

    public int GetConnectedCount() {
        return _connections.Count;
    }
}