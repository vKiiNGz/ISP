using System;
using System.Collections.Generic;
using System.Text;

namespace _053506_Gotchenya_Lab5.Entities
{
    class Person
    {
        string name, surname, patronymic, pasport_ID;
        decimal sum;
        Deposit person_deposit;

        public void Replenishment()
        {
            sum *= ((decimal)1 + person_deposit.percent); 
        }
        public decimal Payoff()
        {
            return sum * person_deposit.percent;
        }
        public override string ToString()
        {
            string help; 
            help = string.Format("Name: {0}, Surname: {1}, Patronymic: {2}, Pasport_ID: {3}, Balance in $: {4}, ", name, surname, patronymic, pasport_ID, sum);
            help += this.person_deposit.ToString();
            return help;
        }
        public Person(string _name, string _surname, string _patronymic, string _pasport_ID, decimal _sum, Deposit _person_deposit)
        {
            name = _name;
            surname = _surname;
            patronymic = _patronymic;
            pasport_ID = _pasport_ID;
            sum = _sum;
            person_deposit = _person_deposit;
        }
    }
}
