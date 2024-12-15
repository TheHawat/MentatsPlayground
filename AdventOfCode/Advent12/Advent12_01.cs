public static class Advent12_01{

    public static string GetResult(string[] input){
        return TheRealPriceWillBeThreeTimesAsMuch(input).ToString();}

    private static int TheRealPriceWillBeThreeTimesAsMuch(string[] input){
        int TotalPrice = 0;
        bool[][] Visited = new bool[input.Length][];
        for (int i = 0; i < input.Length; i++) Visited[i] = new bool[input[i].Length];
        for (int i = 0; i < Visited.Length; i++){
            for (int j = 0; j < Visited[i].Length; j++){
                if(!Visited[i][j]) TotalPrice += GetFencePriceOfThisField(ref input, ref Visited, i, j);
            }
        }
        return TotalPrice;
    }

    private static int GetFencePriceOfThisField(ref string[] input, ref bool[][] visited, int x, int y){
        char CurrentProduce = input[x][y];
        int FenceOfThisField = 0;
        int CountOfThisField = 0;
        FenceOfThisField += MoveAroundTheField(ref input, ref visited, x, y, CurrentProduce, ref CountOfThisField);
        return CountOfThisField * FenceOfThisField;
    }

    private static int MoveAroundTheField(ref string[] input, ref bool[][] visited, int x, int y, char CurrentProduce, ref int Counter){
        visited[x][y] = true;
        int MyValue = 0;
        Counter++;
        foreach (var mod in Sapho.FourWay){
            int CheckinX = x + mod.X;
            int CheckinY = y + mod.Y;
            if (Sapho.InArrayRange(CheckinX, CheckinY, input)){
                if (visited[CheckinX][CheckinY]) {
                    if (input[CheckinX][CheckinY] != CurrentProduce) MyValue += 1;
                    continue;
                }
                MyValue += input[CheckinX][CheckinY] == CurrentProduce ?
                MoveAroundTheField(ref input, ref visited, CheckinX, CheckinY, CurrentProduce, ref Counter) : 1;
            } else MyValue += 1;
        }
        return MyValue;
    }
}