
public class LanGraphTwo{
    Dictionary<string, List<string>> Nodes = [];
    List<string[]> Connections = [];
    string[] BiggestLan = [];
    List<string[]> Checked = [];
    public LanGraphTwo (string[] input){
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

    private void FindConnection(string node, string[] CurrentLan){
        if (CurrentLan.Contains(node)) return;
        if (CurrentLan.Length > BiggestLan.Length) BiggestLan = CurrentLan;
        Array.Sort(CurrentLan);
        if (Checked.Contains(CurrentLan)) return;
        if(CurrentLan.Length > 0 )Checked.Add(CurrentLan);
        foreach(var computer in CurrentLan){
            if (!Nodes[node].Contains(computer)) return;
        }
        string[] NextLan = CurrentLan.Concat(new string[] {node}).ToArray();
        foreach(var comp in NextLan) Console.Write(comp + "   ");
        Console.WriteLine();
        foreach(var computer in Nodes[node]){
            FindConnection(computer, NextLan);
        }
    }

    public void SetAllConnections(){
        var Seen = new HashSet<string>(StringComparer.Ordinal);
        var Result = new List<string[]>();
        foreach(var node in Nodes) FindConnection(node.Key, []);
        foreach(var con in Connections){
            Array.Sort(con);
            string identifier = string.Join("", con);
            if(Seen.Add(identifier)){
                Result.Add(con); 
            }
        }
        Connections = Result;
    }

    public void PrintAllConnections(){
        foreach(var con in Connections){
            Console.WriteLine($"{con[0]}, {con[1]}, {con[2]}");
        }
        foreach(var nod in Nodes){
            Console.WriteLine($"NodeCount:  {nod.Key}  {nod.Value.Count}");
        }
        Console.WriteLine(BiggestLan.Length);
        foreach(var comp in BiggestLan) Console.Write(comp + ",");
    }

    public int GetConnectedCount(){
        return Connections.Count();
    }
}