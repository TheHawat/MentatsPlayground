public class Turing {
    Dictionary<string, bool> _states = [];
    List<string[]> _instructions = [];

    public void SetState(string Addr, bool Flag) {
        if (_states.ContainsKey(Addr)) _states[Addr] = Flag;
        else _states.Add(Addr, Flag);
    }

    public void AddInstruction(string line) {
        string NewLine = line.Replace("-> ", "");
        string[] SplitLine = NewLine.Split(" ");
        _instructions.Add(SplitLine);
    }

    private bool CheckInstruction(int x) {
        if (!_states.ContainsKey(_instructions[x][0]) || !_states.ContainsKey(_instructions[x][2])) return false;
        if (!_states.ContainsKey(_instructions[x][3])) _states.Add(_instructions[x][3], false);
        if (_instructions[x][1] == "XOR") _states[_instructions[x][3]] = _states[_instructions[x][0]] ^ _states[_instructions[x][2]];
        else if (_instructions[x][1] == "AND") _states[_instructions[x][3]] = _states[_instructions[x][0]] && _states[_instructions[x][2]];
        else if (_instructions[x][1] == "OR") _states[_instructions[x][3]] = _states[_instructions[x][0]] || _states[_instructions[x][2]];
        return true;
    }

    public void ProcessAllInstructions() {
        int i = 0;
        while (_instructions.Count > 0) {
            if (CheckInstruction(i)) _instructions.RemoveAt(i);
            i++;
            if (i >= _instructions.Count) i = 0;
        }
    }

    public string GetValue() {
        string Binary = string.Concat(
            _states
                .Where(x => x.Key.StartsWith('z'))
                .OrderByDescending(x => x.Key)
                .Select(x => x.Value ? "1" : "0")
        );
        return Convert.ToInt64(Binary, 2).ToString();
    }

    public string GetValue(char C) {
        string Binary = string.Concat(
            _states
                .Where(x => x.Key.StartsWith(C))
                .OrderByDescending(x => x.Key)
                .Select(x => x.Value ? "1" : "0")
        );
        return Binary;
    }

    public void PrintAllStates() {
        foreach (var kvp in _states.OrderByDescending(x => x.Key)) {
            int value = kvp.Value ? 1 : 0;
            Console.WriteLine($"{kvp.Key}:   {value}");
        }
    }
}