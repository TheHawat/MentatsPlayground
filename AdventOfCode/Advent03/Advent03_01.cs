public static class Advent03_01{
    public static string GetResult(string[] input)
    {
        return TotalSumOfMuls(input);
    }

    private static string TotalSumOfMuls(string[] input)
    {
        string SingleLine = "";
        int Sum = 0;
        foreach(var line in input) SingleLine+=line;
        string[] AllPossibleMuls = SingleLine.Split("mul(");
        foreach(var line in AllPossibleMuls) Sum += MulValue(line);
        return Sum.ToString();
    }

    private static int MulValue(string line)
    {
        int Sum = GetNextNumber(ref line, ',');
        if (Sum == 0) return 0; 
        Sum *= GetNextNumber(ref line, ')');
        return Sum;
    }

    private static int GetNextNumber(ref string line, char ExitCharacter)
    {
        string Numbers = "0123456789";
        bool NumberFound = false;
        string Result = "";
        foreach(var c in line){
            if (NumberFound && c == ExitCharacter){
                line = line[(Result.Length+1)..];
                return int.Parse(Result);
            } 
            if (Numbers.Contains(c)) {
                Result += c;
                NumberFound = true;
                continue;
            }
            return 0;
        }
        return 0;
    }
}