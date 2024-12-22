
class Keypad
{
    public Key[][] Keys = [];
    char[][] Board = [];
    public Dictionary<char, (int,int)> KeyAddress = [];
    public Dictionary<string, int> Distances = [];
    public (int X, int Y, char Dir)[] DirectedFourWay = [];
    public Keypad(string[] input, bool makingArrows){
        Keys = new Key[input.Length][];
        Board = new char[input.Length][];
        for (int i = 0; i < input.Length; i++){
            Keys[i] = new Key[input[i].Length];
            Board[i] = new char[input[i].Length];
            for (int j = 0; j < input[i].Length; j++){
                Keys[i][j] = new Key(input[i][j], input.Length, input[i].Length);
                Board[i][j] = input[i][j];
                KeyAddress.Add(Board[i][j], (i,j));
            }
        }
        InitDistances();
        if (!makingArrows){
            DirectedFourWay = [ (-1, 0, '^'), (0, 1, '>'), (1, 0, 'v'), (0, -1, '<')];
        } else {
            DirectedFourWay = [ (1, 0, 'v'), (0, -1, '<'), (0, 1, '>'), (-1, 0, '^')];
        }
        DirectedFourWay = [ (-1, 0, '^'), (0, 1, '>'), (1, 0, 'v'), (0, -1, '<')];
    }

    private void InitDistances(){
        string AllArrows = "v<>^A";
        string Ones = "v^A>v<   <v>A^v";
        string Twos = "<^><  vAv  <>^<";
        string Threes = "<A<";
        foreach(char F in AllArrows){
            foreach(char S in AllArrows){
                string line = ""+F+S;
                if(F == S) { Distances.Add(line, 0); continue; }
                if(Ones.Contains(line)) { Distances.Add(line, 1); continue; }
                if(Twos.Contains(line)) { Distances.Add(line, 2); continue; }
                if(Threes.Contains(line)) { Distances.Add(line, 3); continue; }
            }
        }
    }

    public void SetPaths(){
        for (int i = 0; i < Keys.Length; i++){
            for (int j = 0; j < Keys[i].Length; j++){
                SetOnePath(i, j);
                //SetOnePath(i, j);
            }
        }
    }

    public void PrintPaths(){
        Sapho.IterateTwoD(Keys, x => {
        Console.WriteLine($"I Am Key: {x.value}"); 
            for (int i = 0; i < x.paths.Length; i++){
                for (int j = 0; j < x.paths[i].Length; j++){
                    Console.Write(x.paths[i][j] + "     ");
                }
                Console.WriteLine();
            }
        }
        );
    }

    private int GetNormalisedPath(string line){
        //if (line.Length == 0) return 0;
        if (line.Length == 1) return 1;
        if (line[..2] == "AX") return 10000;
        int Total = 0;
        for (int i = 0; i < line.Length-1; i++){
            Console.WriteLine($"{line[i..(i+2)]}         {Distances[line[i..(i+2)]]}");
            Total += Distances[line[i..(i+2)]];
        }
        Console.WriteLine($"{line}    {Total}");
        return Total;
    }

    private void SetOnePath( int i, int j){
        Run(i,j,i,j,"");
    }
    private void Run(int X, int Y, int KeyX, int KeyY, string CurrentPath){
        //Console.Error.WriteLine($"{X}     {Y}     {CurrentPath}");
        Keys[KeyX][KeyY].paths[X][Y] = CurrentPath;
        for (int i = 0; i < 4; i++ ){
            //Console.WriteLine($" {X} {Y}  {i}        {CurrentPath}");
            int CheckingX = X + DirectedFourWay[i].X;
            int CheckingY = Y + DirectedFourWay[i].Y;
            if (!Sapho.InArrayRange(CheckingX, CheckingY, Keys[KeyX][KeyY].paths) || Keys[CheckingX][CheckingY].value == 'X') continue;
            //Console.WriteLine($"{Keys[KeyX][KeyY].paths[CheckingX][CheckingY]}         {CurrentPath}");
            //if (Keys[KeyX][KeyY].paths[CheckingX][CheckingY].Length < CurrentPath.Length + 1) continue;
            if (GetNormalisedPath("A" + Keys[KeyX][KeyY].paths[CheckingX][CheckingY]) < GetNormalisedPath("A" + CurrentPath+Sapho.DirectedFourWay[i].Dir)) continue;
            Run(CheckingX, CheckingY, KeyX, KeyY, CurrentPath+DirectedFourWay[i].Dir);
        }
    }
    public string GetPath (string input){
        string Result = "";
        for (int i = 1; i < input.Length; i++){
            (int X, int Y) First = KeyAddress[input[i-1]];
            (int X, int Y) Second = KeyAddress[input[i]];
            Result += Keys[First.X][First.Y].paths[Second.X][Second.Y] + "A";
        }
        return Result;
    }
}

struct Key{
    public string[][] paths = [];
    public char value;
    public int CurrentTotal;
    public Key(char val, int x, int y){
        value = val;
        paths = new string[x][];
        for (int i = 0; i < x; i++){
            paths[i] = new string[y];
            for (int j = 0; j < y; j++){
                paths[i][j] = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
            }
        }
    }
}