public static class Advent05_02 {
    public static string GetResult(string[] input) {
        Dictionary<int, List<int>> Continuity = [];
        return CountGoodMids(Continuity, LoadPairs(ref Continuity, input)).ToString();
    }
    private static string[] LoadPairs(ref Dictionary<int, List<int>> Continuity, string[] input) {
        for (int i = 0; i < input.Length; i++) {
            if (input[i] == "") {
                return input[(i + 1)..];
            }
            ProcessOnePair(ref Continuity, Array.ConvertAll(input[i].Split("|"), x => int.Parse(x)));
        }
        return Array.Empty<string>();
    }
    private static void ProcessOnePair(ref Dictionary<int, List<int>> Continuity, int[] Pair) {
        if (Continuity.ContainsKey(Pair[0]) && !Continuity[Pair[0]].Contains(Pair[1])) {
            Continuity[Pair[0]].Add(Pair[1]);
        }
        else {
            Continuity.Add(Pair[0], []);
            Continuity[Pair[0]].Add(Pair[1]);
        }
    }
    private static int CountGoodMids(Dictionary<int, List<int>> Continuity, string[] input) {
        int Count = 0;
        for (int i = 0; i < input.Length; i++) {
            int[] Line = Array.ConvertAll(input[i].Split(","), x => int.Parse(x));
            if (!ValidateOneLine(Continuity, Line)) {
                int[] FixedLine = GetFixedLine(Continuity, Line);
                Count += FixedLine[FixedLine.Length / 2];
            }
        }
        return Count;
    }

    private static int[] GetFixedLine(Dictionary<int, List<int>> Continuity, int[] Line) {
        while (!ValidateOneLine(Continuity, Line, out int FailedIndexOne, out int FailedIndexTwo)) {
            int Swap = Line[FailedIndexOne];
            Line[FailedIndexOne] = Line[FailedIndexTwo];
            Line[FailedIndexTwo] = Swap;
        }
        return Line;
    }

    private static bool ValidateOneLine(Dictionary<int, List<int>> Continuity, int[] Line) {
        for (int i = 0; i < Line.Length; i++) {
            if (!Continuity.ContainsKey(Line[i])) continue;
            foreach (var IllegalNumber in Continuity[Line[i]]) {
                if (Line[..i].Contains(IllegalNumber)) return false;
            }
        }
        return true;
    }
    private static bool ValidateOneLine(Dictionary<int, List<int>> Continuity, int[] Line, out int FailedIndexOne, out int FailedIndexTwo) {
        for (int i = 0; i < Line.Length; i++) {
            if (!Continuity.ContainsKey(Line[i])) continue;
            foreach (var IllegalNumber in Continuity[Line[i]]) {
                if (Line[..i].Contains(IllegalNumber)) {
                    FailedIndexOne = i;
                    FailedIndexTwo = Array.IndexOf(Line, IllegalNumber);
                    return false;
                }
            }
        }
        FailedIndexOne = -1;
        FailedIndexTwo = -1;
        return true;
    }
}