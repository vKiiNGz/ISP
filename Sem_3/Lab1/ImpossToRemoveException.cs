using System;
using System.Collections.Generic;
using System.Text;

namespace _053506_Gotchenya_Lab5
{
    class ImpossToRemoveException: Exception
    {
        public ImpossToRemoveException(string message)
        : base(message)
        {
            Console.WriteLine(message);
        }
    }
}
