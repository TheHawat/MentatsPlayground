public static class Advent24_01{
    public static string GetResult(string[] input){
        Turing Task = new();
        int Break = Array.IndexOf(input, "");
        for (int i = 0; i < Break; i++){
            string[] OneInput = input[i].Split(": ");
            Task.SetState(OneInput[0], OneInput[1] == "1" ? true : false);
        }
        for (int i = Break+1; i < input.Length; i++){
            Task.AddInstruction(input[i]);
        }
        Task.ProcessAllInstructions();
        return Task.GetValue();
    }
}