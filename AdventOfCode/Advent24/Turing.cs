public class Turing {
    Dictionary<string, bool> States = [];
    List<string[]> Instructions = [];

    public void SetState(string Addr, bool Flag) {
        if (States.ContainsKey(Addr)) States[Addr] = Flag;
        else States.Add(Addr, Flag);
    }

    public void AddInstruction(string line) {
        string NewLine = line.Replace("-> ", "");
        string[] SplitLine = NewLine.Split(" ");
        Instructions.Add(SplitLine);
    }

    private bool CheckInstruction(int x) {
        if (!States.ContainsKey(Instructions[x][0]) || !States.ContainsKey(Instructions[x][2])) return false;
        if (!States.ContainsKey(Instructions[x][3])) States.Add(Instructions[x][3], false);
        if (Instructions[x][1] == "XOR") States[Instructions[x][3]] = States[Instructions[x][0]] ^ States[Instructions[x][2]];
        else if (Instructions[x][1] == "AND") States[Instructions[x][3]] = States[Instructions[x][0]] && States[Instructions[x][2]];
        else if (Instructions[x][1] == "OR") States[Instructions[x][3]] = States[Instructions[x][0]] || States[Instructions[x][2]];
        return true;
    }

    public void ProcessAllInstructions() {
        int i = 0;
        while (Instructions.Count > 0) {
            if (CheckInstruction(i)) Instructions.RemoveAt(i);
            i++;
            if (i >= Instructions.Count) i = 0;
        }
    }

    public string GetValue() {
        string Binary = string.Concat(
            States
                .Where(x => x.Key.StartsWith('z'))
                .OrderByDescending(x => x.Key)
                .Select(x => x.Value ? "1" : "0")
        );
        return Convert.ToInt64(Binary, 2).ToString();
    }

    public string GetValue(char C) {
        string Binary = string.Concat(
            States
                .Where(x => x.Key.StartsWith(C))
                .OrderByDescending(x => x.Key)
                .Select(x => x.Value ? "1" : "0")
        );
        return Binary;
    }

    public void PrintAllStates() {
        foreach (var kvp in States.OrderByDescending(x => x.Key)) {
            int value = kvp.Value ? 1 : 0;
            Console.WriteLine($"{kvp.Key}:   {value}");
        }
    }
}