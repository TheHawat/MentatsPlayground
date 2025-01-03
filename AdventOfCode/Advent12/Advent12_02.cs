public static class Advent12_02 {
    public static string GetResult(string[] input) {
        Field Task = new(input);
        Task.SetTotalPrice();
        return Task.TotalPrice.ToString();
    }
}