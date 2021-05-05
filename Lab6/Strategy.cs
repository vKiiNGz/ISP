using System;
using System.Collections.Generic;
using System.Text;

namespace LR_6
{
    sealed class Strategy : Game, IShowInfo
    {
        private int[] ganre = new int[3] { 0, 0, 0 }; //4X realtime step_by_step   

        public Strategy()
        : base()
        {
            int i;
            string x;
            do
            {
                Console.WriteLine("Enter the rating of this game 4X-0, realtime - 1, step by step - 2: ");
                x = Console.ReadLine();
                if (!int.TryParse(x, out i) || (i < 0 || i > 2))
                {
                    Console.WriteLine("Incorect rating, try again");
                }
            }
            while (!int.TryParse(x, out i) || (i < 0 || i > 2));
            ganre[i] = 1;
        }

        public override void Info()
        {
            base.Info();
            if (ganre[0] == 1)
            {
                Console.WriteLine("The ganre is 4X startegy");
            }
            if (ganre[1] == 1)
            {
                Console.WriteLine("The ganre is realtime startegy");
            }
            if (ganre[2] == 1)
            {
                Console.WriteLine("The ganre is step by step startegy");
            }
        }
    }
}
