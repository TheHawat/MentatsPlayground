public static class Advent07_02 {
    public static string GetResult(string[] input) { 
        return SumAllVialableSeries(input).ToString();
    }

    private static double SumAllVialableSeries(string[] input) {
        double SumOfVialableSeries = 0;
        foreach (var line in input) {
            if (GetValueIfVialable(line, out double value)) SumOfVialableSeries += value;
        }
        return SumOfVialableSeries;
    }

    private static bool GetValueIfVialable(string line, out double value) {
        string[] SumAndSeries = line.Split(": ");
        double Sum = double.Parse(SumAndSeries[0]);
        int[] Series = Array.ConvertAll(SumAndSeries[1].Split(' '), x => int.Parse(x));
        if (IsLineVialable(Series, Sum)) {
            value = Sum;
            return true;
        }
        value = -1;
        return false;
    }

    private static bool IsLineVialable(int[] series, double sum) {
        int NumbersToTry = 1 << (series.Length - 1);
        for (int i = 0; i < NumbersToTry; i++) {
            string Operators = Convert.ToString(i, 2);
            Operators = Operators.PadLeft(series.Length - 1, '0');
            if (sum == GetLineValue(Operators, series)) return true;
        }
        return false;
    }

    private static double GetLineValue(string operators, int[] series) {
        double Result = series[0];
        for (int i = 0; i < operators.Length; i++) {
            Result = operators[i] == '1' ? Result * series[i + 1] : Result + series[i + 1];
        }
        return Result;
    }

}