using System;

namespace LR_2_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---Task with digit---");
            string Str = Console.ReadLine();
            bool WholePart = true;
            double Digit = 0.0;
            int Counter = 1, CounterDigit = 0;
            byte Dote = 0;
            int First = 0;
            //double x = 0.1111111111111111111111111111111;
           // Console.WriteLine(x);
                
            
            if (Str.Length > 0 && Str.Length < 308)
            {   
                if (!((Str[0] >= '0') && (Str[0] <= '9')) && Str.Length == 1)
                {
                    Console.WriteLine("incorect input");
                    Environment.Exit(0);
                }
                if (Str[0] == '-' || Str[0] == '+' || ((Str[0] >= '0') && (Str[0] <= '9')))
                {
                    if (Str[0] == '-')
                    {
                        First = -1;
                    }
                    else
                    {
                        if (Str[0] == '+' || ((Str[0] >= '0') && (Str[0] <= '9')))
                        {
                            First = 1;
                            if((Str[0] >= '0') && (Str[0] <= '9'))
                            {
                                Digit = Str[0] - '0';
                            }
                        }
                        else
                        {
                            if (Str.Length == 1 && Str[0] == '0')
                            {
                                Console.WriteLine(Digit);
                                Environment.Exit(0);
                            }
                            else
                            {
                                if (Str.Length > 1 && Str[0] == '0' && Str[1] == '.')
                                {
                                    First = 0;
                                }
                            }
                        }

                    }
                }    
                for (int i = 1; i < Str.Length; i++)
                {
                    if(Str[i] == '.' && WholePart)
                    {
                        WholePart = false;
                        Dote++;
                        Digit *= First; 
                    }
                    else
                    {   if (!((Str[i] >= '0') && (Str[i] <= '9')))
                        {
                            Console.WriteLine("incorect input");
                            Environment.Exit(0);
                        }
                    }
                    if (WholePart && ((Str[i] >= '0') && (Str[i] <= '9')))
                    {
                        Digit = Digit * 10 + (Str[i] - '0');
                    }
                    else
                    {
                        if (Str[i] == '.' && Dote > 1)
                        {
                            Console.WriteLine("incorect input");
                            Environment.Exit(0);
                        }
                    }
                    if (!WholePart && ((Str[i] >= '0') && (Str[i] <= '9')))
                    {
                        if (First == 1)
                        {
                            Digit = Digit + ((Str[i] - '0') / (Math.Pow(10.0, Counter)));
                            Counter++;
                        }
                        if (First == -1)
                        {
                            Digit = Digit - ((Str[i] - '0') / (Math.Pow(10.0, Counter)));
                            Counter++;
                        }
                    }
                    else
                    {
                        if (Str[i] == '.' && Dote > 1)
                        {
                            Console.WriteLine("C");
                            Environment.Exit(0);
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("number is missing");
                Environment.Exit(0);
            }
            if (WholePart)
            {
                Digit *= First;
            }
            Console.WriteLine(Digit);
        }
    }
}
