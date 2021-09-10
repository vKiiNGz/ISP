using System;
using System.Collections.Generic;
using System.Text;

namespace _053506_Gotchenya_Lab5.Entities
{
    class Deposit
    {
        protected internal decimal percent;
        protected internal string name;
        protected internal int term;
        public override string ToString()
        {
            return string.Format("Name of deposit: {0}, Percent: {1}, Term: {2}.", name, percent, term);
        }
        public Deposit(string _name, decimal _precent, int _term)
        {
            name = _name;
            percent = _precent;
            term = _term;
        }
    }
}
