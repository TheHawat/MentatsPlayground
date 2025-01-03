public static class Advent14_01 {
    public static string GetResult(string[] input) {
        return HandleRobots(input).ToString();
    }

    public static int[] ReadPosition(string line) {
        string NormalizedLine = line[2..];
        NormalizedLine = NormalizedLine.Replace(" v=", ",");
        return Array.ConvertAll(NormalizedLine.Split(','), x => int.Parse(x));
    }

    public static int HandleRobots(string[] input) {
        int Sum = 0, BoardX = 103, BoardY = 101;
        List<Robot> AllTheCrazyOnes = [];
        for (int i = 0; i < input.Length; i++) {
            int[] ConvertedLine = ReadPosition(input[i]);
            AllTheCrazyOnes.Add(new(ConvertedLine[1], ConvertedLine[0], ConvertedLine[3], ConvertedLine[2]));
            AllTheCrazyOnes[i].Move(100);
            AllTheCrazyOnes[i].Adjust(BoardX, BoardY);
        }
        Sum += QuadrantSums(AllTheCrazyOnes, BoardX, BoardY);
        return Sum;
    }

    private static int QuadrantSums(List<Robot> allTheCrazyOnes, int boardX, int boardY) {
        Queue<int[]> Ranges = [];
        int Sum = 1;
        Ranges.Enqueue([0, boardX / 2, 0, boardY / 2]);
        Ranges.Enqueue([boardX / 2 + 1, boardX, 0, boardY / 2]);
        Ranges.Enqueue([0, boardX / 2, boardY / 2 + 1, boardY]);
        Ranges.Enqueue([boardX / 2 + 1, boardX, boardY / 2 + 1, boardY]);
        while (Ranges.Count > 0) {
            int[] Quadrant = Ranges.Dequeue();
            int Quad = allTheCrazyOnes.Count(robot =>
                robot.PosX >= Quadrant[0] && robot.PosX < Quadrant[1] &&
                robot.PosY >= Quadrant[2] && robot.PosY < Quadrant[3]);
            Console.WriteLine($"{Quadrant[2]}  {Quadrant[3]}  {Quadrant[0]}  {Quadrant[1]}      {Quad}");
            Sum *= Quad;
        }
        return Sum;
    }
}