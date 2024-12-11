public static class Advent11_02{
    public static string GetResult(string[] input){
        return GetStonesAfterBlinks(input, 75).ToString();
    }

    private static double GetStonesAfterBlinks(string[] input, int BlinkAmount){
        GraphOfStones Galaxy = new (input[0]);
        for (int i = 0; i < BlinkAmount; i++){
            Galaxy.BlinkOnce();
            //Console.WriteLine(Galaxy.AmountOfGrainsOfSandInUniverese());
        }
        return Galaxy.AmountOfGrainsOfSandInUniverese();
    }
}