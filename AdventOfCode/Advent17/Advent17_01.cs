public static class Advent17_01{
    public static string GetResult(string[] input){
        string Result = ProcessCommands(input);
        return "Bla!";
    }


    public static int ReadReg(string line){
        return int.Parse(line[11..]);
    }
    public static int[] ReadProg(string line){
        return Array.ConvertAll(line[8..].Split(','), x => int.Parse(x));
    }
    private static string ProcessCommands(string[] input){
        string Result = "";
        int[] Regs = {ReadReg(input[0]), ReadReg(input[1]), ReadReg(input[2])};
        int[] Commands = ReadProg(input[4]);
        Computor Comp = new (Regs);
        Comp.Execute(2, 2);
        return Result;
    }

    
}