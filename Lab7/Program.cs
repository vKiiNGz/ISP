using System;

namespace LR_7
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Frac n1 = new Frac(8, 10);
            Frac n2 = new Frac(7, 13);
            Frac n = n1 + n2;
            Console.WriteLine($"{n1} + {n2} = " + n);
            n = n1 - n2;
            Console.WriteLine($"{n1} - {n2} = " + n.ToString("."));
            n = n1 * n2;
            Console.WriteLine($"{n1} * {n2} = " + n);
            n = n1 / n2;
            Console.WriteLine($"{n1} / {n2} = " + n);
            Console.WriteLine($"{n1} > {n2} - " + (n1 > n2));
            Console.WriteLine($"{n1} < {n2} - " + (n1 < n2));
            Console.WriteLine($"{n1} == {n2} - " + (n1 == n2));
            Console.WriteLine($"{n1} != {n2} - " + (n1 != n2));
            Console.WriteLine($"(int){n} = " + (int)n);
            Console.WriteLine($"(double){n} = " + (double)n);
        }
    }
}
