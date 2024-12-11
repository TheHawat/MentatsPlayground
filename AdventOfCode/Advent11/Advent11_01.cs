public static class Advent11_01{
    public static string GetResult(string[] input){
        return GetStonesAfterBlinks(input, 25).ToString();
    }

    private static int GetStonesAfterBlinks(string[] input, int BlinkAmount){
        Queue<string> Lines = new();
        foreach(var stone in input[0].Split(" ")) Lines.Enqueue(stone);
        for (int i = 0; i < BlinkAmount; i++){
            Lines = BlinkOnce(Lines);
        }
        return Lines.Count();
    }

    private static Queue<string> BlinkOnce(Queue<string> lines) {
        Queue<string> State = new();
        while(lines.Count>0){
            string CurrentStone = lines.Dequeue();
            if(CurrentStone == "0") {State.Enqueue("1"); continue;}
            if(CurrentStone.Length % 2 == 1){
                State.Enqueue((double.Parse(CurrentStone)*2024).ToString());
                continue;
            }
            int Halfsies = CurrentStone.Length/2;
            State.Enqueue(CurrentStone[..Halfsies]);
            string SecondHalf = CurrentStone[Halfsies..].TrimStart('0');
            State.Enqueue(SecondHalf == "" ? "0" : SecondHalf); 
        }
        return State;
    }
}