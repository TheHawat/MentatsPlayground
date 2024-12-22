
public static class Advent21_01{
    public static string GetResult(string[] input){
        Keypad KeyMap = new(input[..4], false);    
        KeyMap.SetPaths();
        Keypad Arrows = new(input[4..6], true);
        Arrows.SetPaths();
        //Arrows.PrintPaths();
        int TotalVal = 0;
        foreach(var line in input[6..]){
            string PathLol = KeyMap.GetPath(line);
            string PathLolTwo = SortedKeypath(PathLol);
            Console.WriteLine(PathLolTwo);
            string KeyPathOne = Arrows.GetPath("A"+PathLolTwo);
           // KeyPathOne = SortedKeypath(KeyPathOne);
            string KeyPathTwo = Arrows.GetPath("A"+KeyPathOne);
            Console.WriteLine(PathLol);
            Console.WriteLine(KeyPathOne);
            Console.WriteLine(KeyPathTwo);
            Console.WriteLine(KeyPathTwo.Length + "     " + line);
            int LineVal = int.Parse(line[1..^1].TrimStart('0'));
            Console.WriteLine(LineVal);
            TotalVal += KeyPathTwo.Length * LineVal;
        }
        //Console.WriteLine(KeyMap.KeyAddress['9'].Item1);
        return TotalVal.ToString();
    }

    private static string SortedKeypath(string keyPathOne){
        while(keyPathOne[1..].Contains("^^<<")){ keyPathOne = keyPathOne.Replace("^^<<", "<<^^");};
        while(keyPathOne[1..].Contains("A>vA")){ keyPathOne = keyPathOne.Replace("A>vA", "Av>A");};
        //while(keyPathOne.Contains("<>")) keyPathOne = keyPathOne.Replace("<>", "><");
        //while(keyPathOne.Contains("<v")) keyPathOne = keyPathOne.Replace("<v", "v<");
        return keyPathOne;
    }
}