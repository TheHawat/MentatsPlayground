
public static class Advent09_01{
    public static string GetResult(string[] input){
        LinkedList<int> EncodedLine = EncodeInput(input[0]);
        Queue<int> TransformedLine = TranformLine(EncodedLine);
        return GetChecksum(TransformedLine).ToString();
    }
    private static LinkedList<int> EncodeInput(string v)
    {
        LinkedList<int> EncodedResult = new();
        int[] TempInts = Array.ConvertAll(v.ToCharArray(), x => int.Parse(x+""));
        bool IdBlock = true;
        int Id = 0;
        int Adder;
        for(int i = 0; i < TempInts.Length; i++){
            if(IdBlock){
                IdBlock = false;
                Adder = Id;
                Id++;
            }
            else{
                IdBlock = true;
                Adder = -1;
            }
            for(int j = 0; j < TempInts[i]; j++){
                EncodedResult.AddLast(Adder);
            }
        }
        return EncodedResult;
    }
    private static Queue<int> TranformLine(LinkedList<int> encodedLine)
    {
        Queue<int> Result = new();
        int MinusCounter = 0;
        do{
            int Next = encodedLine.First(); 
            encodedLine.RemoveFirst();
            while (Next == -1 && encodedLine.Count > 0){
                MinusCounter++;
                Next = encodedLine.First(); 
                encodedLine.RemoveFirst();
            }
            while (MinusCounter > 0 && encodedLine.Count > 0){
                int Last = encodedLine.Last(); 
                encodedLine.RemoveLast();
                while (Last == -1 && encodedLine.Count > 0){
                    Last = encodedLine.Last(); 
                    encodedLine.RemoveLast();
                }
                Result.Enqueue(Last);
                MinusCounter--;
            }
            Result.Enqueue(Next);
        }
        while(encodedLine.Count > 0);
        return Result;
    }
    private static double GetChecksum(Queue<int> transformedLine)
    {
        int Multiplier = 0;
        double Sum = 0;
        foreach (var l in transformedLine) {
            if (l == -1 ) break; // I hate this line. It can be done better for sure.
            Sum+=Multiplier * l; Multiplier++;
            }
        return Sum;
    }
}