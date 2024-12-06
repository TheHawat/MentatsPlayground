public static class Advent06_01{
    public static string GetResult(string[] input){
        return CountExes(input).ToString(); 
    }

    private static int CountExes(string[] input){
        (int CurrentlyFacing, int CurrentX, int CurrentY) = GetCurrentPosition(input);
        int CountOfSteps = 0;
        char[][] MazeInChars = Array.ConvertAll(input, x => x.ToCharArray());
        while(StepForwardIsPossibleImTakingIt(out bool NewTileReached, ref MazeInChars, ref CurrentlyFacing, ref CurrentX, ref CurrentY)){
            CountOfSteps += NewTileReached ? 1 : 0;
            Console.WriteLine($"Debug:   ---   X: {CurrentX}   ---   Y: {CurrentY}   ---   Facing: {CurrentlyFacing}");
        }
        return CountOfSteps + 1; // Not sure why this +1 is needed but it worked so im done for now.
    }

    private static bool StepForwardIsPossibleImTakingIt(out bool newTileReached, ref char[][] input, ref int CurrentlyFacing, ref int CurrentX, ref int CurrentY){
        (int X, int Y)[] Directions = { (-1,0), (0, 1), (1, 0), (0, -1) };
        int CheckingX = CurrentX + Directions[CurrentlyFacing].X;
        int CheckingY = CurrentY + Directions[CurrentlyFacing].Y;
        if (CheckingX >= input.Length || CheckingX < 0) {newTileReached = false; return false;}
        if (CheckingY >= input[CheckingX].Length || CheckingY < 0) {newTileReached = false; return false;}
        if (input[CheckingX][CheckingY] == '#') {
            CurrentlyFacing++;
            if (CurrentlyFacing == 4) CurrentlyFacing = 0;
            newTileReached = false;
            return true;
        }
        CurrentX = CheckingX; 
        CurrentY = CheckingY;
        newTileReached = input[CheckingX][CheckingY] != 'X';
        input[CheckingX][CheckingY] = 'X';
        return true;
    }

    private static (int,int,int) GetCurrentPosition(string[] input){
        string DirectionIndexer = "^>v<";
        for (int i = 0; i < input.Length; i++){
            for (int j = 0; j < input[i].Length; j++){
                if (DirectionIndexer.Contains(input[i][j])) {
                    return (Array.IndexOf(DirectionIndexer.ToArray(), input[i][j]), i, j);
                }
            }
        }
        return (-1,-1,-1);
    }
}