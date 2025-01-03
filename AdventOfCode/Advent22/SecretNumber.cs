public class SecretNumber {
    public static BigInteger GetResult(string input) {
        BigInteger Number = BigInteger.Parse(input);
        //Console.WriteLine(GetNextNumber(Number));
        return GetNextNumber(Number);
    }
    public static BigInteger GetNextNumber(BigInteger num) {
        BigInteger Result = Mix(num, num * 64);
        Result = Prune(Result);
        Result = Mix(Result, FloorDivide(Result, 32));
        Result = Prune(Result);
        Result = Mix(Result, Result * 2048);
        //Console.WriteLine(Result);
        Result = Prune(Result);
        return Result;
    }

    private static BigInteger Mix(BigInteger based, BigInteger mix) {
        return based ^ mix;
    }
    private static BigInteger Prune(BigInteger based) {
        return based % 16777216;
    }
    private static BigInteger FloorDivide(BigInteger dividend, BigInteger divisor) {
        //if (dividend % divisor != 0)return (dividend / divisor) - 1;
        return dividend / divisor;
    }
}