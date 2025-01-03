public static class AssignmentInitializer {
    public static string Run(string[] args) {
        if (args.Length == 1) return RunWithConsole(args);
        if (args.Length > 1) return RunWithFile(args);
        return "Unimplemented for arguments";
    }
    private static string RunWithConsole(string[] args) {
        List<string> input = [];
        Console.WriteLine("Add input lines. End with 'e'.");
        while (true) {
            string nextLine = Console.ReadLine();
            if (nextLine == "e") break;
            input.Add(nextLine);
        }
        return CompleteTask(input.ToArray(), args[0]);
    }
    private static string RunWithFile(string[] args) {
        //string filestring = File.ReadAllText($"/Users/Hawat/Projects/MentatsPlaygroud/AdventOfCode/{args[1]}.txt");
        string filestring = File.ReadAllText($"{args[1]}");
        string[] lines = filestring.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
        return CompleteTask(lines, args[0]);
    }
    private static string CompleteTask(string[] input, string ClassName) {
        Assembly assembly = Assembly.GetExecutingAssembly();
        Type type = assembly.GetTypes().FirstOrDefault(t => t.Name.Equals(ClassName, StringComparison.OrdinalIgnoreCase));
        MethodInfo runMethod = type.GetMethod("GetResult", BindingFlags.Static | BindingFlags.Public, null, new[] { typeof(string[]) }, null);
        return runMethod.Invoke(null, [input]).ToString();
    }
}