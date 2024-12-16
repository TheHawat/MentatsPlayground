

public static class Advent07_01{
    public static string GetResult(string[] input){return SumAllVialableSeries(input).ToString();}

    private static int SumAllVialableSeries(string[] input){
        int SumOfVialableSeries = 0;
        foreach(var line in input){
            if (CheckOneLineVialability(line, out int value)) SumOfVialableSeries+=value; 
        }
        return SumOfVialableSeries;
    }

    private static bool CheckOneLineVialability(string line, out int value){
        string[] SumAndSeries = line.Split(": ");
        double Sum = double.Parse(SumAndSeries[0]);
        int[] Series = Array.ConvertAll(SumAndSeries[1].Split(' '), x => int.Parse(x));
        //Array.Sort(Series);
        value = DoTheMagic(Sum, Series);
        //foreach(var num in Series) Console.WriteLine(num);
        //Console.WriteLine(SumAndSeries[1]);
        return false;
    }

    private static int DoTheMagic(double sum, int[] series){
        int[] Operators = [];
        Array.Fill(Operators, 0);
        
        return -1;
    }
    private static void AddOne(ref int[] Ops){
        
    }
}