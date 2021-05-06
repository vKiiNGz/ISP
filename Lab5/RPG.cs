using System;
using System.Collections.Generic;
using System.Text;

namespace LR_5
{
    sealed class RPG : Game
    {
        private bool story;

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
        }

        public RPG()
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
                    Console.WriteLine("Incorect rating, try again");
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
        }
    }
}
