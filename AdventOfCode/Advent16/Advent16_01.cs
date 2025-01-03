public static class Advent16_01 {
    public static string GetResult(string[] input) {
        MazeRunner TestCase = new MazeRunner(input);
        string Low = TestCase.GetLowestPath().ToString();
        return Low;
    }
}