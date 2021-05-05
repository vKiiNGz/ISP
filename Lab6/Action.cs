using System;
using System.Collections.Generic;
using System.Text;

namespace LR_6
{
    sealed class Action : Game, IShowInfo
    {
        private bool story;
        private bool multiplayer;
        private bool coop;

        public override void Info()
        {
            base.Info();
            if (story)
            {
                Console.WriteLine("This game has a plot");
            }
            else
            {
                Console.WriteLine("This game has no plot");
            }
            if (multiplayer)
            {
                Console.WriteLine("This game has a multiplayer");
            }
            else
            {
                Console.WriteLine("This game has no multiplayer");
            }
            if (coop)
            {
                Console.WriteLine("This game has a co-op");
            }
            else
            {
                Console.WriteLine("This game has no co-op");
            }

        }
        public Action()
        : base()
        {
            int i;
            string x;
            do
            {
                Console.WriteLine("Does this game have a storyline?: 1 - Yes, 0 - No");
                x = Console.ReadLine();
                if (!int.TryParse(x, out i) || (i < 0 || i > 1))
                {
                    Console.WriteLine("Incorect answer, try again");
                }
            }
            while (!int.TryParse(x, out i) || (i < 0 || i > 1));
            if (i == 1)
            {
                story = true;
            }
            else
            {
                story = false;
            }
            do
            {
                Console.WriteLine("Does this game have a multiplayer?: 1 - Yes, 0 - No");
                x = Console.ReadLine();
                if (!int.TryParse(x, out i) || (i < 0 || i > 1))
                {
                    Console.WriteLine("Incorect answer, try again");
                }
            }
            while (!int.TryParse(x, out i) || (i < 0 || i > 1));
            if (i == 1)
            {
                multiplayer = true;
            }
            else
            {
                multiplayer = false;

            }
            do
            {
                Console.WriteLine("Does this game have a co-op?: 1 - Yes, 0 - No");
                x = Console.ReadLine();
                if (!int.TryParse(x, out i) || (i < 0 || i > 1))
                {
                    Console.WriteLine("Incorect answer, try again");
                }
            }
            while (!int.TryParse(x, out i) || (i < 0 || i > 1));
            if (i == 1)
            {
                coop = true;
            }
            else
            {
                coop = false;
            }
        }
    }
}
