using System;

namespace LR_1
{
    class Program
    {
        public static void Info()
        {
            System.Console.WriteLine("I created this game, inspired by the poker from the first part of The Witcher. Below are the rules of the game.");
            System.Console.WriteLine("The goal of the game is to collect a combination of dice of greater value than the opponent's. The game consists of three rounds and goes to two wins.");
            System.Console.WriteLine("The game is conventionally divided into two phases: in the first phase, the player receives a set of five dice, in the second, he rolls any number of dice or leaves the combination that fell on the first roll. ");
            System.Console.WriteLine("All possible combinations in this game: ");
            System.Console.WriteLine("-Poker - all five dice with the same number of points.");
            System.Console.WriteLine("-Four of a kind - four dice with the same number of points.");
            System.Console.WriteLine("-Full house - a pair and three dice of the same denomination.");
            System.Console.WriteLine("-Big Straight - five dice with different values in a sequence from 2 to 6.");
            System.Console.WriteLine("-Small Straight - five dice with different values in a sequence from 1 to 5.");
            System.Console.WriteLine("-Set - three dice of the same value.");
            System.Console.WriteLine("-Two pairs - two pairs of bones of the same value each.");
            System.Console.WriteLine("-Pair - two bones of the same value.");
        }
        public static void GenerateArr(int[] Arr)
        {
            Random Rnd = new Random();
            Arr[0] = Rnd.Next(1, 6);
            Arr[1] = Rnd.Next(1, 6);
            Arr[2] = Rnd.Next(1, 6);
            Arr[3] = Rnd.Next(1, 6);
            Arr[4] = Rnd.Next(1, 6);
        }
        public static int Combination(int[] Arr)
        {
            int res = 0;
            int[] Dice = new int[7];
            for (int i = 0; i < 7; i++)
            {
                Dice[i] = 0;
            }
            for (int i = 0; i < 5; i++)
            {
                Dice[Arr[i]]++;
            }
            if (Dice[1] == 5 || Dice[2] == 5 || Dice[3] == 5 || Dice[4] == 5 || Dice[5] == 5 || Dice[6] == 5)
            {
                res = 1;
            }
            else
            {
                if (Dice[1] == 4 || Dice[2] == 4 || Dice[3] == 4 || Dice[4] == 4 || Dice[5] == 4 || Dice[6] == 4)
                {
                    res = 2;
                }
                else
                {
                    for (int j = 1; j <= 6; j++)
                        for (int k = 1; k <= 6; k++)
                        {
                            if( j != k)
                            {
                                if(Dice[j] == 3 && Dice[k] == 2)
                                {
                                    res = 3;
                                }
                            }
                        }
                    if (res == 0)
                    {
                        if (Dice[2] == 1 && Dice[3] == 1 && Dice[4] == 1 && Dice[5] == 1 && Dice[6] == 1)
                        {
                            res = 4;
                        }
                        else
                        {
                            if (Dice[1] == 1 && Dice[2] == 1 && Dice[3] == 1 && Dice[4] == 1 && Dice[5] == 1)
                            {
                                res = 5;
                            }
                            else
                            {
                                if (Dice[1] == 3 || Dice[2] == 3 || Dice[3] == 3 || Dice[4] == 3 || Dice[5] == 3 || Dice[6] == 3)
                                {
                                    res = 6;
                                }
                                else
                                {
                                    for (int j = 1; j <= 6; j++)
                                        for (int k = 1; k <= 6; k++)
                                        {
                                            if (j != k)
                                            {
                                                if (Dice[j] == 2 && Dice[k] == 2)
                                                {
                                                    res = 7;
                                                }
                                            }
                                        }
                                    if(res == 0)
                                    {
                                        if (Dice[1] == 2 || Dice[2] == 2 || Dice[3] == 2 || Dice[4] == 2 || Dice[5] == 2 || Dice[6] == 2)
                                        {
                                            res = 8;
                                        }
                                        else
                                        {
                                            res = 9;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
                return res;
        }
        public static int Sum(int[] Arr)
        {
            int Answ = 0;
            for(int i = 0; i < 5; i++)
            {
                Answ += Arr[i]; 
            }
            return (Answ);
        }
        public static void Reroll(int[] Arr, int ValComputer, int SumComputer, int ValPlayer, int SumPlayer)
        {
            int[] Dice = new int[6];
            int FirstComb = 0, SecondComb = -1;
            Random Rnd = new Random();
            for (int i = 0; i < 6; i++)
            {
                Dice[i] = 0;
            }
            for (int i = 0; i < 5; i++)
            {
                Dice[Arr[i]]++;
            }
            if (ValComputer == 9 && ((ValPlayer < ValComputer) || ((ValComputer == ValPlayer) && (SumPlayer > SumComputer))))
            {
                GenerateArr(Arr);
            }
            else
            {
                if (ValComputer == 8 && ( (ValPlayer < ValComputer) || ((ValComputer == ValPlayer) && (SumPlayer > SumComputer) ) ) )
                {
                    for (int i = 0; i < 6; i++)
                    {
                        if(Dice[i] == 2)
                        {
                            FirstComb = i;
                        }
                    }
                    for (int i = 0; i < 5; i++)
                    {
                        if (Arr[i] != FirstComb)
                        {
                            Arr[i] = Rnd.Next(1, 6);
                        }
                    }

                }
                else
                {
                    if (ValComputer == 7 && ((ValPlayer < ValComputer) || ((ValComputer == ValPlayer) && (SumPlayer > SumComputer))))
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            if (Dice[i] == 2 && i != SecondComb)
                            {
                                FirstComb = i;
                            }
                            if (Dice[i] == 2 && i != FirstComb)
                            {
                                SecondComb = i;
                            }
                        }
                        for (int i = 0; i < 5; i++)
                        {
                            if (Arr[i] != FirstComb && i != SecondComb)
                            {
                                Arr[i] = Rnd.Next(1, 6);
                            }
                        }
                    }
                    else
                    {
                        if (ValComputer == 6 && ((ValPlayer < ValComputer) || ((ValComputer == ValPlayer) && (SumPlayer > SumComputer))))
                        {
                            for (int i = 0; i < 6; i++)
                            {
                                if (Dice[i] == 3)
                                {
                                    FirstComb = i;
                                }
                            }
                            for (int i = 0; i < 5; i++)
                            {
                                if (Arr[i] != FirstComb)
                                {
                                    Arr[i] = Rnd.Next(1, 6);
                                }
                            }
                        }
                        else
                        {
                            if (ValComputer == 5 && ((ValPlayer < ValComputer) || ((ValComputer == ValPlayer) && (SumPlayer > SumComputer))))
                            {
                                for (int i = 0; i < 5; i++)
                                {
                                    if (Arr[i] == 1)
                                    {
                                        Arr[i] = Rnd.Next(1, 6);
                                    }
                                }
                            }
                            else
                            {
                                if (ValComputer == 4 && ((ValPlayer < ValComputer) || ((ValComputer == ValPlayer) && (SumPlayer > SumComputer))))
                                {
                                    for (int i = 0; i < 5; i++)
                                    {
                                        if (Arr[i] != 6)
                                        {
                                            Arr[i] = Rnd.Next(1, 6);
                                        }
                                    }
                                }
                                else
                                {
                                    if (ValComputer == 3 && ((ValPlayer < ValComputer) || ((ValComputer == ValPlayer) && (SumPlayer > SumComputer))))
                                    {
                                        for (int i = 0; i < 6; i++)
                                        {
                                            if (Dice[i] == 2)
                                            {
                                                FirstComb = i;
                                            }
                                        }
                                        for (int i = 0; i < 5; i++)
                                        {
                                            if (Arr[i] == FirstComb)
                                            {
                                                Arr[i] = Rnd.Next(1, 6);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (ValComputer == 2 && ((ValPlayer < ValComputer) || ((ValComputer == ValPlayer) && (SumPlayer > SumComputer))))
                                        {
                                            for (int i = 0; i < 6; i++)
                                            {
                                                if (Dice[i] == 1)
                                                {
                                                    FirstComb = i;
                                                }
                                            }
                                            for (int i = 0; i < 5; i++)
                                            {
                                                if (Arr[i] == FirstComb)
                                                {
                                                    Arr[i] = Rnd.Next(1, 6);
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (ValComputer == 1 && ((ValPlayer < ValComputer) || ((ValComputer == ValPlayer) && (SumPlayer > SumComputer))))
                                            {
                                                GenerateArr(Arr);
                                            }
                                            else;
                                        }
                                    }
                                }
                            }
                        }

                    }
                }
            }
        }
        static void Main(string[] args)
        {
            System.Console.WriteLine("Would you like to know brief information about the game and familiarize yourself with the rules? 1/0 ");
            string Answ;
            bool CorrectAnsw = false;
            while (!CorrectAnsw)
            {
                Answ = Console.ReadLine();
                if (Answ.Length > 0)
                {
                    if ((Answ[0] == '1' || Answ[0] == '0') && (Answ.Length == 1))
                    {
                        if (Answ[0] == '1')
                        {
                            Info();
                            CorrectAnsw = true;
                        }
                        else
                        {
                            CorrectAnsw = true;
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("incorrect input, please try again.");
                    }
                }
                else
                {
                    System.Console.WriteLine("incorrect input, please try again.");
                }

            }
            int[] PackPlayer = new int[5];
            int[] PackComputer = new int[5];
            int NumbWinPlayer = 0, NumbWinComputer = 0, ValuePlayer = 10, ValueComputer = 10;
            int ChangeAmont = 0, SumComputer = 0, SumPlayer = 0;
            string ChangeStr;
            while (NumbWinPlayer < 2 && NumbWinComputer < 2)
            {
                GenerateArr(PackComputer);
                GenerateArr(PackPlayer);
                System.Console.WriteLine("Your pack: ");
                for (int i = 0; i < 5; i++)
                {
                    System.Console.Write(PackPlayer[i] + " ");
                }
                ValuePlayer = Combination(PackPlayer);
                System.Console.WriteLine();
                System.Console.WriteLine("Computer pack: ");
                for (int i = 0; i < 5; i++)
                {
                    System.Console.Write(PackComputer[i] + " ");
                }
                ValueComputer = Combination(PackComputer);
                System.Console.WriteLine();
                CorrectAnsw = false;
                while (!CorrectAnsw)
                {
                    System.Console.WriteLine("Want to reroll the dice? ? 1/0 ");
                    Answ = Console.ReadLine();
                    if (Answ.Length > 0)
                    {
                        if ((Answ[0] == '1' || Answ[0] == '0') && (Answ.Length == 1))
                        {
                            if (Answ[0] == '1')
                            {

                                System.Console.WriteLine("how many dice do you want to reroll ? 1-5");
                                ChangeStr = Console.ReadLine();
                                if (ChangeStr.Length > 0)
                                {
                                    if ((ChangeStr[0] == '1' || ChangeStr[0] == '2' || ChangeStr[0] == '3' || ChangeStr[0] == '4' || ChangeStr[0] == '5') && (ChangeStr.Length == 1))
                                    {
                                        if (ChangeStr[0] == '1')
                                        {
                                            ChangeAmont = 1;
                                            CorrectAnsw = true;
                                        }
                                        else
                                        {
                                            if (ChangeStr[0] == '2')
                                            {
                                                ChangeAmont = 2;
                                                CorrectAnsw = true;
                                            }
                                            else
                                            {
                                                if (ChangeStr[0] == '3')
                                                {
                                                    ChangeAmont = 3;
                                                    CorrectAnsw = true;
                                                }
                                                else
                                                {
                                                    if (ChangeStr[0] == '4')
                                                    {
                                                        ChangeAmont = 4;
                                                        CorrectAnsw = true;
                                                    }
                                                    else
                                                    {
                                                        if (ChangeStr[0] == '5')
                                                        {
                                                            ChangeAmont = 5;
                                                            CorrectAnsw = true;
                                                        }
                                                        else;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        System.Console.WriteLine("incorrect input, please try again.");
                                    }
                                }
                                else
                                {
                                    System.Console.WriteLine("incorrect input, please try again.");
                                }

                            }
                            else
                            {
                                CorrectAnsw = true;
                            }
                        }
                        else
                        {
                            System.Console.WriteLine("incorrect input, please try again.");
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("incorrect input, please try again.");
                    }

                }
                int[] PlayerReroll = new int[6];
                for (int i = 0; i < 6; i++)
                {
                    PlayerReroll[i] = 0;
                } 
                for (int i = 0; i < ChangeAmont; i++)
                {
                    CorrectAnsw = false;
                    while (!CorrectAnsw)
                    {
                        System.Console.WriteLine("You throw up " + (i + 1) + "/" + ChangeAmont + " dice");
                        for (int j = 0; j < 5; j++)
                        {
                            System.Console.Write(PackPlayer[j] + " ");
                        }
                        System.Console.WriteLine();
                        System.Console.WriteLine("Select the dice");
                        Answ = Console.ReadLine();
                        if (Answ.Length > 0)
                        {
                            if ((Answ[0] == '1' || Answ[0] == '2' || Answ[0] == '3' || Answ[0] == '4' || Answ[0] == '5') && (Answ.Length == 1))
                            {
                                if (Answ[0] == '1' && PlayerReroll[1] == 0)
                                {
                                    PlayerReroll[1] = 1;
                                    CorrectAnsw = true;
                                }
                                else
                                {
                                    if (Answ[0] == '2' && PlayerReroll[2] == 0)
                                    {
                                        PlayerReroll[2] = 1;
                                        CorrectAnsw = true;
                                    }
                                    else
                                    {
                                        if (Answ[0] == '3' && PlayerReroll[3] == 0)
                                        {
                                            PlayerReroll[3] = 1;
                                            CorrectAnsw = true;
                                        }
                                        else
                                        {
                                            if (Answ[0] == '4' && PlayerReroll[4] == 0)
                                            {
                                                PlayerReroll[4] = 1;
                                                CorrectAnsw = true;
                                            }
                                            else
                                            {
                                                if (Answ[0] == '5' && PlayerReroll[5] == 0)
                                                {
                                                    PlayerReroll[5] = 1;
                                                    CorrectAnsw = true;
                                                }
                                                else
                                                {
                                                    System.Console.WriteLine("incorrect input, please try again.");
                                                }
                                            }
                                        }
                                    }
                                }

                            }
                            else
                            {
                                System.Console.WriteLine("incorrect input, please try again.");
                            }
                        }
                        else
                        {
                            System.Console.WriteLine("incorrect input, please try again.");
                        }
                    }
                }
                for (int j = 1; j < 6; j++)
                {
                    if(PlayerReroll[j] == 1)
                    {
                        Random Rnd = new Random();
                        PackPlayer[j-1] = Rnd.Next(1, 6);
                    }
                }
                SumComputer = Sum(PackComputer);
                SumPlayer = Sum(PackPlayer);
                ValuePlayer = Combination(PackPlayer);
                ValueComputer = Combination(PackComputer);
                Reroll(PackComputer, ValueComputer, SumComputer, ValuePlayer, SumPlayer);
                System.Console.WriteLine("Your pack: ");
                for (int i = 0; i < 5; i++)
                {
                    System.Console.Write(PackPlayer[i] + " ");
                }
                System.Console.WriteLine();
                ValueComputer = Combination(PackComputer);
                System.Console.WriteLine("Computer pack: ");
                for (int i = 0; i < 5; i++)
                {
                    System.Console.Write(PackComputer[i] + " ");
                }
                System.Console.WriteLine();
                SumComputer = Sum(PackComputer);
                SumPlayer = Sum(PackPlayer);
                if ((ValueComputer < ValuePlayer) || ((ValueComputer == ValuePlayer) && (SumComputer > SumPlayer)))
                {
                    System.Console.WriteLine("Computer win this round ");
                    NumbWinComputer++;
                    System.Console.WriteLine("Your score: " + NumbWinPlayer);
                    System.Console.WriteLine("Computer score: " + NumbWinComputer);
                    System.Console.WriteLine();
                }
                if ((ValueComputer > ValuePlayer) || ((ValueComputer == ValuePlayer) && (SumComputer < SumPlayer)))
                {
                    System.Console.WriteLine("You win this round ");
                    NumbWinPlayer++;
                    System.Console.WriteLine("Your score: " + NumbWinPlayer);
                    System.Console.WriteLine("Computer score: " + NumbWinComputer);
                    System.Console.WriteLine();
                }
                if ((ValueComputer == ValuePlayer) && (SumComputer == SumPlayer))
                {
                    System.Console.WriteLine("Draw");
                    System.Console.WriteLine();
                }
                if(NumbWinPlayer == 2)
                {
                    System.Console.WriteLine("You win this game!!!");
                    System.Console.WriteLine("Want to play again? 1/0");
                    CorrectAnsw = false;
                    while (!CorrectAnsw)
                    {
                        Answ = Console.ReadLine();
                        if (Answ.Length > 0)
                        {
                            if ((Answ[0] == '1' || Answ[0] == '0') && (Answ.Length == 1))
                            {
                                if (Answ[0] == '1')
                                {
                                    NumbWinPlayer = 0;
                                    NumbWinComputer = 0;
                                    CorrectAnsw = true;
                                }
                                else
                                {
                                    CorrectAnsw = true;
                                }
                            }
                            else
                            {
                                System.Console.WriteLine("incorrect input, please try again.");
                            }
                        }
                        else
                        {
                            System.Console.WriteLine("incorrect input, please try again.");
                        }

                    }
                    System.Console.WriteLine();
                    System.Console.WriteLine();
                    System.Console.WriteLine();
                }
                if (NumbWinComputer == 2)
                {
                    System.Console.WriteLine("Computer win this game!!!");
                    System.Console.WriteLine("Want to play again? 1/0");
                    CorrectAnsw = false;
                    while (!CorrectAnsw)
                    {
                        Answ = Console.ReadLine();
                        if (Answ.Length > 0)
                        {
                            if ((Answ[0] == '1' || Answ[0] == '0') && (Answ.Length == 1))
                            {
                                if (Answ[0] == '1')
                                {
                                    NumbWinPlayer = 0;
                                    NumbWinComputer = 0;
                                    CorrectAnsw = true;
                                }
                                else
                                {
                                    CorrectAnsw = true;
                                }
                            }
                            else
                            {
                                System.Console.WriteLine("incorrect input, please try again.");
                            }
                        }
                        else
                        {
                            System.Console.WriteLine("incorrect input, please try again.");
                        }

                    }
                    System.Console.WriteLine();
                    System.Console.WriteLine();
                    System.Console.WriteLine();
                }
                
            }    
        }

    }
}
