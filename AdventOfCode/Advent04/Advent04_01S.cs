public static class Advent04_01S{

    public static string GetResult(string[] input){
        return CountAllWords(input).ToString();
    }

    private static int CountAllWords(string[] input){
        string WordToLocate = "XMAS";
        int WordCount = 0;
        for(int i = 0; i < input.Length; i++){
            for(int j = 0; j < input[i].Length; j++){
                if(input[i][j] == WordToLocate[0]) CountFromHere(ref WordCount, i, j, input, WordToLocate[1..]);
            }
        }
        return WordCount;
    }

    private static void CountFromHere(ref int WordCount, int x, int y, string[] input, string ShortenedWord){
        if (ShortenedWord == "") {WordCount++; return;}
        (int DX, int DY)[] Modifier = { (1, 0), (-1, 0), (0, 1), (0, -1), (1, -1), (-1, 1), (-1, -1), (1, 1) }; 
        foreach(var D in Modifier){
            int CurrentX = x+D.DX;
            if (CurrentX < 0 || CurrentX >= input.Length) continue;
            int CurrentY = y+D.DY;
            if (CurrentY < 0 || CurrentY >= input.Length) continue;
            if (input[CurrentX][CurrentY] == ShortenedWord[0]) CountFromHere(ref WordCount, CurrentX, CurrentY, input, ShortenedWord[1..]);
        }
    }
}