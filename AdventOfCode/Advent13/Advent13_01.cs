public static class Advent13_01{
    public static string GetResult(string[] input){
        int Sum = 0;
        for(int i = 0; i < input.Length; i+=4){
            int First = GetCheapestWay(ReadButton(input[i]), ReadButton(input[i+1]), ReadPrize(input[i+2]), false);
            int Second = GetCheapestWay(ReadButton(input[i+1]), ReadButton(input[i]), ReadPrize(input[i+2]), true);
            Console.WriteLine( $"F:{First}   S:{Second}");
        }
        return Sum.ToString();
    }

    public static (int,int) ReadButton(string line){
        int[] OnlyInts = Array.ConvertAll(line[12..].Split(", Y+"), x => int.Parse(x));
        return (OnlyInts[0], OnlyInts[1]);
    }
    public static (int,int) ReadPrize(string line){
        int[] OnlyInts = Array.ConvertAll(line[9..].Split(", Y="), x => int.Parse(x));
        return (OnlyInts[0], OnlyInts[1]);
    }

    public static int GetCheapestWay((int X, int Y) A, (int X, int Y) B, (int X, int Y) Prize, bool reversed){
        (int X, int Y) LowestSum = (0,0);
        int CountA = 0;
        int CountB = 0;
        while (LowestSum.X < Prize.X && LowestSum.Y < Prize.Y){
            if((Prize.X - LowestSum.X) % B.X == 0 && (Prize.Y - LowestSum.Y) % B.Y == 0){
                CountB = (Prize.X - LowestSum.X) / B.X;
                break; 
            } else {
                LowestSum.X+=A.X;
                LowestSum.Y+=A.Y;
                CountA++;
            }
        }
        if (reversed) return LowestSum.X < Prize.X ? CountA + 3 * CountB : 0;
        return LowestSum.X < Prize.X ? 3 * CountA + CountB : 0;
    }
}