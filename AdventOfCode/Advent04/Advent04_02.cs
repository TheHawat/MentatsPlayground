
public static class Advent04_02{

    public static string GetResult(string[] input){
        return CountAllWords(input).ToString();
    }

    private static int CountAllWords(string[] input){
        int WordCount = 0;
        (int DX, int DY)[] ModifierL = { (-1, -1), (1, 1) };
        (int DX, int DY)[] ModifierR = { (1, -1), (-1, 1) };
        for(int i = 0; i < input.Length; i++){
            for(int j = 0; j < input[i].Length; j++){
                if(input[i][j] == 'A'){
                    string One = "";
                    string Two = "";
                    foreach(var D in ModifierL){
                        One += GetDiagonal( i+D.DX, j+D.DY, input);
                    }
                    foreach(var D in ModifierR){
                        Two += GetDiagonal( i+D.DX, j+D.DY, input);
                    }
                    if (One.Contains('M') && One.Contains('S') && Two.Contains('M') && Two.Contains('S')) WordCount++;
                }
            }
        }
        return WordCount;
    }

    private static string GetDiagonal(int x, int y, string[] input){
        if( x < 0 || x >= input.Length) return "";
        if( y < 0 || y >= input[x].Length) return "";
        return "" + input[x][y];
    }
}