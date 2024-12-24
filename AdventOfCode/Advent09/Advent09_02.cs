
public static class Advent09_02{
    public static string GetResult(string[] input){
        List<int> EncodedLine = EncodeInput(input[0]);
        TranformLine(ref EncodedLine);
        return GetChecksum(EncodedLine).ToString();
    }
    private static List<int> EncodeInput(string v){
        List<int> EncodedResult = new();
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
                EncodedResult.Add(Adder);
            }
        }
        //while (EncodedResult[^1] == -1) EncodedResult.RemoveAt;
        foreach (var l in EncodedResult) Console.Write(l + " ");
        return EncodedResult;
    }
    private static void TranformLine(ref List<int> encodedLine){
        //foreach (var l in encodedLine) Console.WriteLine(l);
        List<(int,int)> Holes = GetHoles(encodedLine);
        for (int i = 1; i < encodedLine.Count(); i++){
            int Counter = 0;
            int CurrentNumber = encodedLine[^i];
            while (CurrentNumber == encodedLine[^i] && i < encodedLine.Count()){
                i++; Counter++;
            }
            for (int j = 0; j < Holes.Count; j++){
                if (Holes[j].Item2 >= Counter && encodedLine.Count - i > Holes[j].Item1){
                    //insert
                    for (int x = 0; x < Counter; x++){
                        encodedLine[x+Holes[j].Item1] = CurrentNumber;
                        encodedLine[^(i-x)] = -1;
                    }
                    Holes[j] = (Holes[j].Item1, Holes[j].Item2-Counter);
                    break;
                }
            }
        }
    }
    private static List<(int,int)> GetHoles(List<int> input){
        List<(int,int)> Holes = [];
        for (int i = 0; i < input.Count(); i++){
            if(input[i] != -1) continue;
            int CurrentNumber = input[i];
            int Counter = 0;
            while(CurrentNumber == input[i] && i < input.Count()){
                i++; Counter++;
            }
            Holes.Add((i - Counter, Counter));
            Console.WriteLine(i-Counter + "     " + Counter);
        }
        return Holes;
    }
    private static double GetChecksum(List<int> transformedLine){
        int Multiplier = 0;
        double Sum = 0;
        foreach (var l in transformedLine) {
            Console.Write(" " + (l==-1? '.' : l));
            if (l == -1) continue;
            Sum+=Multiplier * l; Multiplier++;
        }
        return Sum;
    }
}