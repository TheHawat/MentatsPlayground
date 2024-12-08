public static class Advent01_02
{
    public static string GetResult(string[] input)
    {
        Dictionary<int, int> LeftDic = new Dictionary<int, int>();
        Dictionary<int, int> RightDic = new Dictionary<int, int>();
        for (int i = 0; i < input.Length; i++)
        {
            int[] ints = Array.ConvertAll(input[i].Split("   "), x => int.Parse(x));
            if (LeftDic.ContainsKey(ints[0])) LeftDic[ints[0]]++;
            else LeftDic.Add(ints[0], 1);
            if (RightDic.ContainsKey(ints[1])) RightDic[ints[1]]++;
            else RightDic.Add(ints[1], 1);
        }
        int sum = 0;
        foreach (var item in LeftDic)
        {
            if (RightDic.ContainsKey(item.Key)) sum += RightDic[item.Key] * item.Value * item.Key;
        }  
        return sum.ToString(); 
    }
}

