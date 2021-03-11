using System;
using System.Text;

namespace LR_2_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---Task with string---");
            const int ArrSize = 1000;
            StringBuilder Str = new StringBuilder(Console.ReadLine());
            StringBuilder[] StrArr = new StringBuilder[ArrSize];
            StringBuilder Word = new StringBuilder();
            int Counter = 0, CounterSpace = 0;
            for (int i = 0; i < ArrSize; i++)
            {
                StrArr[i] = new StringBuilder();
            }
            Str.Insert(Str.Length, ' ');
            for (int i = 0; i < Str.Length; i++)
            {
                if (Str[i] == ' ')
                {
                    CounterSpace++;
                    if (CounterSpace == 1)
                    {
                        StrArr[Counter].Insert(0, Word);
                        Word.Remove(0, Word.Length);
                        Counter++;
                    }
                    if(CounterSpace == 2)
                    {
                        Console.WriteLine("Wrong input");
                        Environment.Exit(0);
                    }
                }
                else
                {
                    CounterSpace = 0;
                    Word.Append(Str[i]);
                }

            }
            Str.Remove(0, Str.Length);
            for (int i = Counter-1; i >= 0; i--)
            {
                Str.Insert(Str.Length, StrArr[i]);
                Str.Insert(Str.Length, ' ');
            }
            Console.WriteLine(Str);
        }
    }
}
