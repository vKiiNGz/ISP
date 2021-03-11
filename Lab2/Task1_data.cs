using System;

namespace LR_2_1
{
    class Program
    {
        static void Task(string Str, int[] Arr)
        {
            for (int i = 0; i < 10; i++)
            {
                Arr[i] = 0;
            }
            for (int i = 0; i < Str.Length; i++)
            {
                if (Str[i] != ':' && Str[i] != '.')
                {
                    Arr[Str[i] - '0']++;
                }
            }
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Еhe number of " + i + " in this record is " + Arr[i]);
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            Console.WriteLine("---Task with data---");
            string Date1 = DateTime.UtcNow.ToString("hh:mm:ss");
            string Date2 = DateTime.Now.ToString("MM.dd.yyyy");
            int[] DateArr = new int[10];
            Console.WriteLine();
            Console.WriteLine("Utc time is " + Date1);
            Console.WriteLine();
            Task(Date1, DateArr);
            Console.WriteLine();
            Console.WriteLine("The local date is " + Date2);
            Console.WriteLine();
            Task(Date2, DateArr);
        }
    }
}
