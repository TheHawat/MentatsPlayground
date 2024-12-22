public class Computor
{
    public double A = 0;
    public int B = 0;
    public int C = 0;
    private readonly Action[] _methodArray;
    public Computor(int[] input){
        A = input[0];
        B = input[1];
        C = input[2];
//        _methodArray = new Action<double>[]{
//            adv,
//            bxl,
//            bst,
//            jnz,
//           bxc,
//            outc,
//            bdv,
//            cdv
//        };
    }

    private double ReadMem(int Addr){
        return Addr switch{
            0 or 1 or 2 or 3 => Addr,
            4 => A,
            5 => B,
            6 => C,
            _ => -1
        };
    }

    public void Execute(int literal, double combo){
        Console.WriteLine("ASDASDASDSDA");
        Console.WriteLine(ReadMem(literal));
        //_methodArray[0](combo);
    }
    private void adv(double combo){
        A = A / Math.Pow(2,combo);        
    }
    private void bxl(double combo) => Console.WriteLine("Method 1 executed");
    private void bst(double combo) => Console.WriteLine("Method 2 executed");
    private void jnz(double combo) => Console.WriteLine("Method 3 executed");
    private void bxc(double combo) => Console.WriteLine("Method 4 executed");
    private void outc(double combo) => Console.WriteLine("Method 5 executed");
    private void bdv(double combo) => Console.WriteLine("Method 6 executed");
    private void cdv(double combo) => Console.WriteLine("Method 7 executed");
}