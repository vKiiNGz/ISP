using System;
using System.Collections.Generic;
using System.Text;

namespace LR_6
{
    class Game : IComparable<Game>
    {
        protected string name;
        protected float playerRating;
        protected float pressRating;
        protected int timeToPass;
        protected string developer;
        protected int[] ageRating = new int[5] { 0, 0, 0, 0, 0 };
        static protected int countRPG = 0;
        static protected int countStrategy = 0;
        static protected int countAction = 0;
        static protected int countMMO = 0;

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
        public int CompareTo(Game compar)
        {
            if (playerRating > compar.playerRating)
            {
                return 1;
            }
            else
            {
                if (playerRating == compar.playerRating)
                {
                    return 0;
                }
                else
                {
                    return -1;
                }
            }
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

        public virtual void Info()
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

        public void GenreDefine(int x)
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
}
