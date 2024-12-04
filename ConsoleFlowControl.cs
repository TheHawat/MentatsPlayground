
public static class ConsoleFlowControl
{
    //-----------FlowControlText-----------//
    //const string HelloMessage = "Chose program to run. Type ? for command list.";
    //const Dictionary<string,string> Flow = new Dictionary<string,string>(){{"?", "?"}};
    //----------------Fonts----------------//
    //const string NL          = Environment.NewLine; // shortcut
    const string NORMAL = "\x1b[39m";
    const string RED = "\x1b[91m";
    const string GREEN = "\x1b[92m";
    const string YELLOW = "\x1b[93m";
    const string BLUE = "\x1b[94m";
    const string MAGENTA = "\x1b[95m";
    const string CYAN = "\x1b[96m";
    const string GREY = "\x1b[97m";
    const string BOLD = "\x1b[1m";
    const string NOBOLD = "\x1b[22m";
    const string UNDERLINE = "\x1b[4m";
    const string NOUNDERLINE = "\x1b[24m";
    const string REVERSE = "\x1b[7m";
    const string NOREVERSE = "\x1b[27m";
    internal static void Init(string[] args)
    {
        Stopwatch Timer = new();
        Timer.Start();
        Console.WriteLine($"{BLUE}{DateTime.Now} - Starting execution");
        Console.WriteLine($"{BLUE}Results:");
        Console.WriteLine($"{BLUE}---------------------------------------");
        Console.WriteLine($"{GREEN}{AssignmentInitializer.Run(args)}");
        Timer.Stop();
        Console.WriteLine($"{BLUE}---------------------------------------");
        Console.WriteLine($"{CYAN}{DateTime.Now} - Ending execution");
        Console.WriteLine($"{CYAN}Time Used: {Timer.Elapsed}");
    }
}