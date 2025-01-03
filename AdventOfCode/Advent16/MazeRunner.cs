public class MazeRunner {
    public int[][] Maze;
    public (int X, int Y) Pos;
    public (int X, int Y) End;

    public MazeRunner(string[] input) {
        Maze = new int[input.Length][];
        for (int i = 0; i < input.Length; i++) {
            Maze[i] = Array.ConvertAll(input[i].ToCharArray(), x => x == '#' ? -1 : 0);
        }
        Console.WriteLine("dasdads");
        for (int i = 0; i < input.Length; i++) {
            for (int j = 0; j < input[i].Length; j++) {
                if (input[i][j] == 'S') Pos = (i, j);
                if (input[i][j] == 'E') End = (i, j);
                Console.Write(Maze[i][j] + "    ");
            }
            Console.WriteLine();
        }
    }

    private void Run(int X, int Y, int Dir) {
        Console.WriteLine($"{X}     {Y}");
        for (int i = 0; i < 4; i++) {
            int CheckingX = X + Sapho.FourWayRight[i].X;
            int CheckingY = Y + Sapho.FourWayRight[i].Y;
            if (!Sapho.InArrayRange(CheckingX, CheckingY, Maze)) continue;
            if (Maze[CheckingX][CheckingY] < 0) continue;
            int Mod = Dir == i ? 1 : Dir + 2 == i || i + 2 == Dir ? 2001 : 1001;
            if (Maze[CheckingX][CheckingY] == 0 || Maze[CheckingX][CheckingY] > Maze[X][Y] + Mod) {
                Maze[CheckingX][CheckingY] = Maze[X][Y] + Mod;
                Run(CheckingX, CheckingY, i);
            }
        }
    }
    public int GetLowestPath() {
        Run(Pos.X, Pos.Y, 0);
        for (int i = 0; i < Maze.Length; i++) {
            for (int j = 0; j < Maze[i].Length; j++) {
                if (Maze[i][j] == 'S') Pos = (i, j);
                if (Maze[i][j] == 'E') End = (i, j);
                string MazeVal = Maze[i][j] != -1 ? Maze[i][j].ToString() : "[][]";
                while (MazeVal.Length < 4) MazeVal = '.' + MazeVal;
                Console.Write(MazeVal + "   ");
            }
            Console.WriteLine();
        }
        return Maze[End.X][End.Y];
    }

    public int GetCountOfLowestPath() {
        int Total = 0;
        CountAround(End.X, End.Y, ref Total);
        return Total;
    }

    private void CountAround(int x, int y, ref int total) {
        total++;
        Maze[x][y] = -1;
        if (x == Pos.X && y == Pos.Y) return;
        List<(int X, int Y, int Value)> Possibilities = [];
        for (int i = 0; i < 4; i++) {
            int CheckingX = x + Sapho.FourWayRight[i].X;
            int CheckingY = y + Sapho.FourWayRight[i].Y;
            if (!Sapho.InArrayRange(CheckingX, CheckingY, Maze)) continue;
            if (Maze[CheckingX][CheckingY] < 0) continue;
            Possibilities.Add((CheckingX, CheckingY, Maze[CheckingX][CheckingY]));
        }
        var Low = Possibilities.FirstOrDefault(p => p.Value == Possibilities.Min(p => p.Value));
        CountAround(Low.X, Low.Y, ref total);
    }
}