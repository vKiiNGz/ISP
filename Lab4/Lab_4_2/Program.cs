using System;
using System.Runtime.InteropServices;

namespace Task2
{

    static class Task
    {
        [DllImport("D:\\programm\\053502\\sem_2\\ISP\\DLL\\x64\\Debug\\Dll.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double FirstCount(int num, double[] A, int n, int i);

        [DllImport("D:\\programm\\053502\\sem_2\\ISP\\DLL\\x64\\Debug\\Dll.dll", CallingConvention = CallingConvention.StdCall)]

        public static extern double SecondCount(int num, double[] A, int n, int i);
    }

    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            Console.WriteLine("Enter the number of massive: ");
            bool checkParse = Byte.TryParse(Console.ReadLine(), out byte N);
            while (!checkParse)
            {
                Console.WriteLine("Wrong input, please try again.");
                checkParse = Byte.TryParse(Console.ReadLine(), out N);
            }
            double[] arr = new double[N];
            for (int i = 0; i < N; i++)
            {
                arr[i] = rnd.Next(-5, 5) / 2;
                Console.WriteLine(arr[i]);
            }
            double result = Task.FirstCount(0, arr, 0, (N / 2) - 1) + Task.SecondCount(0, arr, (N / 2) - 1, N - 1);
            Console.WriteLine(result);
        }
    }
}