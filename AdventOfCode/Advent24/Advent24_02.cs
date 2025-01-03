public static class Advent24_02 {
    public static string GetResult(string[] input) {
        Turing Task = new();
        int Break = Array.IndexOf(input, "");
        for (int i = 0; i < Break; i++) {
            string[] OneInput = input[i].Split(": ");
            Task.SetState(OneInput[0], OneInput[1] == "1" ? true : false);
        }
        for (int i = Break + 1; i < input.Length; i++) {
            Task.AddInstruction(input[i]);
        }
        Task.ProcessAllInstructions();
        Task.PrintAllStates();
        Console.Write(" "); Console.WriteLine(Task.GetValue('x'));
        Console.Write(" "); Console.WriteLine(Task.GetValue('y'));
        Console.WriteLine(Task.GetValue('z'));

        Console.WriteLine(Convert.ToInt64(Task.GetValue('x'), 2).ToString());
        Console.WriteLine(Convert.ToInt64(Task.GetValue('y'), 2).ToString());
        Console.WriteLine(Convert.ToInt64(Task.GetValue('z'), 2).ToString());

        return Task.GetValue();
    }
}