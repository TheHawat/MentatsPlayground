public static class Advent22_01
{
    public static string GetResult(string[] input){
        BigInteger Total = 0;
        for (int x = 0; x < input.Length; x++){
            BigInteger Result = SecretNumber.GetResult(input[x]);
            for (int i = 0; i < 1999; i++){
                Result = SecretNumber.GetNextNumber(Result);
            }
            Console.WriteLine(Result);
            Total += Result;
        }
        return Total.ToString();
    }
}