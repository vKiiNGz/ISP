using System;

namespace LR_3
{
    class Game
    {
        private string name;
        private float playerRating;
        private float pressRating;
        private int timeToPass;
        private string developer;
        private int[] ageRating = new int[5]  {0, 0, 0, 0, 0};
        static private int countRPG = 0;
        static private int countStrategy = 0;
        static private int countAction = 0;
        static private int countMMO = 0;
        public int this[int index]
        {
            get
            {
                return ageRating[index];
            }
            set
            {
                ageRating[index] = value;
            }
        }
        public Game()
        {
            int i;
            string x;
            Console.WriteLine("Enter the name of the game: ");
            name = Console.ReadLine();
            do
            {
                Console.WriteLine("Enter player rating of the game: ");
                x = Console.ReadLine();
                if (!float.TryParse(x, out playerRating) || (playerRating > 10 || playerRating < 0))
                {
                    Console.WriteLine("Incorect rating, try again");
                }
            }
            while (!float.TryParse(x, out playerRating) || (playerRating > 10 || playerRating < 0));
            do
            {
                Console.WriteLine("Enter press rating of the game: ");
                x = Console.ReadLine();
                if (!float.TryParse(x, out pressRating) || (pressRating > 10 || pressRating < 0))
                {
                    Console.WriteLine("Incorect rating, try again");
                }
            }
            while (!float.TryParse(x, out pressRating) || (pressRating > 10 || pressRating < 0));
            do
            {
                Console.WriteLine("Enter the time you need to spend to complete the game(in hours): ");
                x = Console.ReadLine();
                if (!int.TryParse(x, out timeToPass))
                {
                    Console.WriteLine("Incorect rating, try again");
                }
            }
            while (!int.TryParse(x, out timeToPass));
            Console.WriteLine("Enter the developer of the game: ");
            developer = Console.ReadLine();
        }

        public Game(string name, float playerRating, float pressRating, int timeToPass, string developer)
        {
            this.name = name;
            this.playerRating = playerRating;
            this.pressRating = pressRating;
            this.timeToPass = timeToPass;
            this.developer = developer;
        }
        
        public int ReatingSearch(float x)
        {
            if (playerRating >= x || pressRating >= x)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int DoubleReatingSearch(float x, float y)
        {
            if (playerRating >= x || pressRating >= y)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int TimeSearch(int x)
        {
            if (timeToPass <= x)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public void Info()
        {
            Console.WriteLine("Name of the game: " + name);
            Console.WriteLine("Сompany developer : " + developer);
            Console.WriteLine("Players rating of the game is " + playerRating);
            Console.WriteLine("Press rating of the game is " + pressRating);
            Console.WriteLine("The number of hours you need to complete the game :" + timeToPass);   
        }

        public void ShortInfo()
        {
            Console.WriteLine("Name of the game: " + name);
            Console.WriteLine("Players rating of the game is " + playerRating);
            Console.WriteLine("Press rating of the game is " + pressRating);
        }

        void GenreDefine(int x) 
        {
            switch (x)
            {
                case 0:
                    countRPG++;
                    break;
                case 1:
                    countStrategy++;
                    break;
                case 2:
                    countAction++;
                    break;
                case 3:
                    countMMO++;
                    break;
                default:
                    break;
            }
        }
    }

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
            for(int i = 0; i < numberOfGames; i++)
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

        static void Main(string[] args)
        {
            string inStr;
            int i, numberOfGames, answ, found;
            Console.WriteLine("Enter the number games: ");
            numberOfGames = ValidationInt();
            Game[] gameArr = new Game[numberOfGames];
            for(i = 0; i < numberOfGames; i++)
            {
                int r;
                gameArr[i] = new Game();
                Console.WriteLine("Enter the age rating of the game: ");
                r = ValidationAgeRating();
                (gameArr[i])[r] = 1;
            }
            StarLine();
            do
            {
                Console.WriteLine("0 - Exit");
                Console.WriteLine("1 - Found game");
                Console.WriteLine("Enter what you want to do: ");
                inStr = Console.ReadLine();
                do
                {
                    if (!int.TryParse(inStr, out answ))
                    {
                        Console.WriteLine("Incorect input, try again");
                    }
                }
                while (!int.TryParse(inStr, out answ) && (answ >= 0) && (answ < 2));
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
                        switch(found)
                        {
                            case 1:
                                FoundAgeReating(numberOfGames, ref gameArr);
                                break;
                            case 2:
                                FoundDoubleReating(numberOfGames, ref gameArr);
                                break;
                            case 3:
                                FoundTime(numberOfGames, ref gameArr);
                                break;
                            default:
                                break;
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
