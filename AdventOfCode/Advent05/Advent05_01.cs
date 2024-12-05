public static class Advent05_01{
    public static string GetResult(string[] input){
        Dictionary<int, List<int>> Continuity = new();
        return CountGoodMids(Continuity, LoadPairs(ref Continuity, input)).ToString();
    }
    private static string[] LoadPairs(ref Dictionary<int, List<int>> Continuity, string[] input){
        for(int i = 0; i < input.Length; i++){
            if (input[i] == "") {
                return input[(i+1)..];
            }
            ProcessOnePair(ref Continuity, Array.ConvertAll(input[i].Split("|"), x => int.Parse(x)));
        }
        return Array.Empty<string>();
    }
    private static void ProcessOnePair(ref Dictionary<int, List<int>> Continuity, int[]Pair){
            if(Continuity.ContainsKey(Pair[0]) && !Continuity[Pair[0]].Contains(Pair[1])){
                Continuity[Pair[0]].Add(Pair[1]);
            } 
            else {
                Continuity.Add(Pair[0], new List<int>());
                Continuity[Pair[0]].Add(Pair[1]);
            }
    }
    private static int CountGoodMids(Dictionary<int, List<int>> Continuity, string[] input){
        int Count = 0;
        for(int i = 0; i < input.Length; i++){
            int[] Line = Array.ConvertAll(input[i].Split(","), x => int.Parse(x));
            if (ValidateOneLine(Continuity, Line)){
                Count += Line[Line.Length/2];
            }
        }
        return Count;
    }

    private static bool ValidateOneLine(Dictionary<int, List<int>> Continuity, int[] Line)
    {
        for(int i = 0; i < Line.Length; i++){
            if(!Continuity.ContainsKey(Line[i])) continue;
            foreach(var IllegalNumber in Continuity[Line[i]]){
                if (Line[..i].Contains(IllegalNumber)) return false;
            }
        }
        return true;
    }
}