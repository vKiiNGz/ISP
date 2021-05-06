using System;

namespace LR_5
{
    class Program
    {
        static void FoundAgeReating(int numberOfGames, ref Game[] gameArr)
        {
            float reatingFirst;
            int age;
            Console.WriteLine("Enter what age rating do you belong to: ");
            age = ValidationAgeRating();
            Console.WriteLine("Enter minimum rating(player or press): ");
            reatingFirst = Validationfloat();
            Console.WriteLine("Games suitable for you: ");
            for (int i = 0; i < numberOfGames; i++)
            {
                for (int j = 0; j <= age; j++)
                {
                    if (gameArr[i].ReatingSearch(reatingFirst) == 1 && (gameArr[i])[j] == 1)
                    {
                        gameArr[i].ShortInfo();
                        Console.WriteLine("");
                    }
                }
            }
        }

        static void FoundDoubleReating(int numberOfGames, ref Game[] gameArr)
        {
            float reatingFirst, reatingSecond;
            Console.WriteLine("Enter the minimum player rating: ");
            reatingFirst = Validationfloat();
            Console.WriteLine("Enter the minimum press rating: ");
            reatingSecond = Validationfloat();
            Console.WriteLine("Games suitable for you: ");
            for (int i = 0; i < numberOfGames; i++)
            {
                if (gameArr[i].DoubleReatingSearch(reatingFirst, reatingSecond) == 1)
                {
                    gameArr[i].ShortInfo();
                    Console.WriteLine("");
                }
            }
        }

        static void StarLine()
        {
            int i;
            for (i = 0; i < 100; i++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }

        static void FoundTime(int numberOfGames, ref Game[] gameArr)
        {
            int time;
            Console.WriteLine("Enter how much time you are willing to spend on the game : ");
            time = ValidationInt();
            Console.WriteLine("Games suitable for you: ");
            for (int i = 0; i < numberOfGames; i++)
            {
                if (gameArr[i].TimeSearch(time) == 1)
                {
                    gameArr[i].Info();
                    Console.WriteLine("");
                }
            }
        }

        static int ValidationAgeRating()
        {
            int r;
            string x;
            do
            {
                Console.WriteLine("(3 years - 0, 7 years - 1, 12 years - 2, 16 years - 3, 18+ years - 4): ");
                x = Console.ReadLine();
                if (!int.TryParse(x, out r) || (r > 4 || r < 0))
                {
                    Console.WriteLine("Incorect rating, try again");
                }
            }
            while (!int.TryParse(x, out r) || (r > 4 || r < 0));
            return r;
        }

        static float Validationfloat()
        {
            string inp;
            float outp;
            do
            {
                inp = Console.ReadLine();
                if (!float.TryParse(inp, out outp))
                {
                    Console.WriteLine("Incorect input, try again");
                }
            }
            while (!float.TryParse(inp, out outp));
            return outp;
        }

        static int ValidationInt()
        {
            string inp;
            int outp;
            do
            {
                inp = Console.ReadLine();
                if (!int.TryParse(inp, out outp))
                {
                    Console.WriteLine("Incorect input, try again");
                }
            }
            while (!int.TryParse(inp, out outp));
            return outp;
        }

        public enum Search
        {
            AR = 1,
            RR = 2,
            T = 3
        }
        static void Main(string[] args)
        {
            string inStr;
            int i, numberOfGames, answ, found;
            Console.WriteLine("Enter the number games: ");
            numberOfGames = ValidationInt();
            Game[] gameArr = new Game[numberOfGames];
            for (i = 0; i < numberOfGames; i++)
            {
                int r;
                string x;
                do
                {
                    Console.WriteLine("Enter the kind of this game Strategy-0, Action - 1, RPG - 2: ");
                    x = Console.ReadLine();
                    if (!int.TryParse(x, out r) || (r < 0 || r > 2))
                    {
                        Console.WriteLine("Incorect kind of game, try again");
                    }
                }
                while (!int.TryParse(x, out r) || (r < 0 || r > 2));
                switch(r)
                {
                    case 0:
                        gameArr[i] = new Strategy();
                        break;
                    case 1:
                        gameArr[i] = new Action();
                        break;
                    case 2:
                        gameArr[i] = new RPG();
                        break;
                    default:
                        break;
                }
                Console.WriteLine("Enter the age rating of the game: ");
                r = ValidationAgeRating();
                (gameArr[i])[r] = 1;
            }
            StarLine();
            do
            {
                Console.WriteLine("0 - Exit");
                Console.WriteLine("1 - Found game");
                Console.WriteLine("2 - display all strategies");
                Console.WriteLine("3 - display all action");
                Console.WriteLine("4 - display all RPG");
                Console.WriteLine("Enter what you want to do: ");
                inStr = Console.ReadLine();
                do
                {
                    if (!int.TryParse(inStr, out answ))
                    {
                        Console.WriteLine("Incorect input, try again");
                    }
                }
                while (!int.TryParse(inStr, out answ) && (answ >= 0) && (answ < 5));
                StarLine();
                switch (answ)
                {
                    case 1:
                        Console.WriteLine("1 - Search by age rating and rating (players or press) ");
                        Console.WriteLine("2 - Search by player ratings and press");
                        Console.WriteLine("3 - Search by the time you need to pass");
                        Console.WriteLine("Enter search type : ");
                        inStr = Console.ReadLine();
                        do
                        {
                            if (!int.TryParse(inStr, out found))
                            {
                                Console.WriteLine("Incorect input, try again");
                            }
                        }
                        while (!int.TryParse(inStr, out found) && (found >= 1) && (found < 4));
                        switch (found)
                        {
                            case (int)Search.AR:
                                FoundAgeReating(numberOfGames, ref gameArr);
                                break;
                            case (int)Search.RR:
                                FoundDoubleReating(numberOfGames, ref gameArr);
                                break;
                            case (int)Search.T:
                                FoundTime(numberOfGames, ref gameArr);
                                break;
                            default:
                                break;
                        }
                        break;
                    case 2:
                        for (i = 0; i < numberOfGames; i++)
                        {
                            if(gameArr[i] is Strategy)
                            {
                                gameArr[i].Info();
                                StarLine();
                            }
                        }
                        break;
                    case 3:
                        for (i = 0; i < numberOfGames; i++)
                        {
                            if (gameArr[i] is Action)
                            {
                                gameArr[i].Info();
                                StarLine();
                            }   
                        }
                        break;
                    case 4:
                        for (i = 0; i < numberOfGames; i++)
                        {
                            if (gameArr[i] is RPG)
                            {
                                gameArr[i].Info();
                                StarLine();
                            }
                        }
                        break;
                    default:
                        break;
                }
                StarLine();

            }
            while (answ != 0);
        }
    }
}
