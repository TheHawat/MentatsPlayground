
public class LanGraph{
    Dictionary<string, List<string>> Nodes = [];
    List<string[]> Connections = [];
    public LanGraph (string[] input){
        foreach (var line in input) AddPair(line);
    }

    private void AddPair(string line){
        string[] Pair = line.Split('-');
        foreach (var computer in Pair){
            if (!Nodes.ContainsKey(computer)) Nodes.Add(computer, new List<string>());
        }
        if (!Nodes[Pair[0]].Contains(Pair[1])) Nodes[Pair[0]].Add(Pair[1]);
        if (!Nodes[Pair[1]].Contains(Pair[0])) Nodes[Pair[1]].Add(Pair[0]);
    }

    private void FindConnection(string node){
        foreach(var computer_two in Nodes[node]){
            foreach(var computer_three in Nodes[computer_two]){
                if (Nodes[computer_three].Contains(node)) Connections.Add(new string[]{node, computer_two, computer_three});
            }
        }
    }

    public void SetAllConnections(){
        var Seen = new HashSet<string>(StringComparer.Ordinal);
        var Result = new List<string[]>();
        foreach(var node in Nodes) FindConnection(node.Key);
        foreach(var con in Connections){
            Array.Sort(con);
            string identifier = string.Join("", con);
            if(Seen.Add(identifier)){
                if (IsValid(con)) Result.Add(con); 
            }
        }
        Connections = Result;
    }

    static bool IsValid(string[] input){
        return input.Distinct().Count() == 3 &&
               input.Any(s => s.StartsWith("t"));
    }

    public void PrintAllConnections(){
        foreach(var con in Connections){
            Console.WriteLine($"{con[0]}, {con[1]}, {con[2]}");
        }
    }

    public int GetConnectedCount(){
        return Connections.Count();
    }
}