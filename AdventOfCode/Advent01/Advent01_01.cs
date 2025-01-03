public static class Advent01_01 {
    public static string GetResult(string[] input) {
        List<int> Left = [];
        List<int> Right = [];
        for (int i = 0; i < input.Length; i++) {
            int[] ints = Array.ConvertAll(input[i].Split("   "), x => int.Parse(x));
            Left.Add(ints[0]);
            Right.Add(ints[1]);
        }
        Left.Sort();
        Right.Sort();
        int sum = 0;
        for (int i = 0; i < Left.Count; i++) sum += Math.Abs(Left[i] - Right[i]);
        return sum.ToString();
    }
}