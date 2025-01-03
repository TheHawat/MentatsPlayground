public class GraphOfStones {
    public Dictionary<string, Stone> GraphNodes = [];
    public GraphOfStones(string input) {
        foreach (var stone in input.Split(" ")) {
            if (!GraphNodes.ContainsKey(stone)) GraphNodes.Add(stone, new Stone(stone));
            else GraphNodes[stone].Counter += 1;
        }
    }

    public void BlinkOnce() {
        List<string> NodeList = [];
        foreach (var node in GraphNodes) {
            NodeList.Add(node.Key);
        }
        foreach (var node in NodeList) {
            GraphNodes[node].SetNextSteps();
            foreach (var nextStep in GraphNodes[node].NextSteps) {
                if (!GraphNodes.ContainsKey(nextStep)) GraphNodes.Add(nextStep, new Stone(nextStep));
                GraphNodes[nextStep].NextCounter += GraphNodes[node].Counter;
            }
        }
        ConfirmBlink();
    }

    public double AmountOfGrainsOfSandInUniverese() {
        double Sum = 0;
        foreach (var node in GraphNodes) {
            Sum += node.Value.Counter;
        }
        return Sum;
    }

    private void ConfirmBlink() {
        foreach (var node in GraphNodes) {
            node.Value.Counter = node.Value.NextCounter;
            node.Value.NextCounter = 0;
        }
    }
}

public class Stone {
    public string[] NextSteps = [];
    public double Counter = 1;
    public double NextCounter = 0;
    public string MyName;

    public Stone(string stone) {
        MyName = stone;
    }

    public void SetNextSteps() {
        if (NextSteps.Length > 0) return;
        if (MyName == "0") { NextSteps = ["1"]; return; }
        if (MyName.Length % 2 == 1) { NextSteps = [(double.Parse(MyName) * 2024).ToString()]; return; }
        int Halfsies = MyName.Length / 2;
        string SecondHalf = MyName[Halfsies..].TrimStart('0');
        NextSteps = [MyName[..Halfsies], SecondHalf == "" ? "0" : SecondHalf];
    }
}