public static class Advent11_02 {
    public static string GetResult(string[] input) {
        return GetStonesAfterBlinks(input, 7500).ToString();
    }

    private static double GetStonesAfterBlinks(string[] input, int blinkAmount) {
        GraphOfStones Galaxy = new(input[0]);
        for (int i = 0; i < blinkAmount; i++) {
            Galaxy.BlinkOnce();
            //Console.WriteLine(Galaxy.AmountOfGrainsOfSandInUniverese());
        }
        return Galaxy.AmountOfGrainsOfSandInUniverese();
    }
}