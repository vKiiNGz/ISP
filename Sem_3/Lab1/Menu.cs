using System;
using System.Collections.Generic;
using System.Text;
using _053506_Gotchenya_Lab5.Collections;
using _053506_Gotchenya_Lab5.Entities;

namespace _053506_Gotchenya_Lab5
{
    class Menu
    {
        Journal journalHelp = new Journal();
        public MyCustomCollection<Deposit> DepositsCreation()
        {
            MyCustomCollection<Deposit> helpCollection = new MyCustomCollection<Deposit>();
            Deposit help = new Deposit("One step for Men", (decimal)0.3, 60);
            helpCollection.Add(help);
            help = new Deposit("Big fish", (decimal)0.25, 36);
            helpCollection.Add(help);
            help = new Deposit("Middleaerth", (decimal)0.20, 24);
            helpCollection.Add(help);
            help = new Deposit("toss a coin to your witcher", (decimal)0.15, 12);
            helpCollection.Add(help);
            help = new Deposit("Kindergarten", (decimal)0.10, 6);
            helpCollection.Add(help);
            return helpCollection;
        }
        public MyCustomCollection<Person> PersonsCreation(MyCustomCollection<Deposit> helpCollection)
        {
            MyCustomCollection<Person> persCollection = new MyCustomCollection<Person>();
            Person help = new Person("Michael", "Zybenko", "Petrovich", "MC2283354", (decimal)1000, helpCollection[3]);
            persCollection.Add(help);
            help = new Person("Geralt", "WhiteWolf", "ofRivia", "MC2753326", (decimal)120000, helpCollection[0]);
            persCollection.Add(help);
            help = new Person("Shepard", "Commander ", "N7", "MC2758636", (decimal)17000, helpCollection[1]);
            persCollection.Add(help);
            help = new Person("Gandalf", "White ", "Hobbitovich'", "MC7832636", (decimal)5000, helpCollection[2]);
            persCollection.Add(help);
            return persCollection;
        }
        public void ReplenishmentAll(MyCustomCollection<Person> helpCollection)
        {
            for (int i = 0; i < helpCollection.Count; i++)
            {
                helpCollection[i].Replenishment();
            }

        }
        public void PayoffAll(MyCustomCollection<Person> helpCollection)
        {
            decimal total = 0;
            for (int i = 0; i < helpCollection.Count; i++)
            {
                total += helpCollection[i].Payoff();
            }
            Console.WriteLine("The amount of payments is " + total + '$');
        }
        public void StarLine()
        {
            Console.WriteLine("********************************************************************************************************************************************************************************************************************************************");
        }
        public void AddDeposit(ref MyCustomCollection<Deposit> helpCollection)
        {

            Console.WriteLine("Enter the name of the deposit:");
            string name = Console.ReadLine();
            decimal answ;
            Console.WriteLine("Enter the procent of the deposit:");
            while (true)
            {
                if (!(Decimal.TryParse(Console.ReadLine(), out answ)))
                {
                    Console.WriteLine("Wrong input! Try again.");
                }
                else
                {
                    break;
                }
            }

            int answ2;
            Console.WriteLine("Enter the temp of the deposit:");
            while (true)
            {
                if (!(Int32.TryParse(Console.ReadLine(), out answ2)))
                {
                    Console.WriteLine("Wrong input! Try again.");
                }
                else
                {
                    break;
                }
            }
            Deposit help = new Deposit(name, answ, answ2);
            helpCollection.Add(help);
        }

        public void AddPerson(ref MyCustomCollection<Person> helpCollection, MyCustomCollection<Deposit> depCollection)
        {
            if(depCollection.Count == 0)
            {
                Console.WriteLine("First of all, create at least one deposit");
                return;
            }
            string fname, fsurname, fpatronymic, fpasport_ID;
            decimal fsum;
            int answ;
            Console.WriteLine("Enter customer name:");
            fname = Console.ReadLine();
            Console.WriteLine("Enter customer surname:");
            fsurname = Console.ReadLine();
            Console.WriteLine("Enter customer patronymic:");
            fpatronymic = Console.ReadLine();
            Console.WriteLine("Enter customer pasport_ID:");
            fpasport_ID = Console.ReadLine();
            Console.WriteLine("Enter the amount that the client wants to deposit into the account:");
            while (true)
            {
                if (!(Decimal.TryParse(Console.ReadLine(), out fsum)))
                {
                    Console.WriteLine("Wrong input! Try again.");
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine("Choose one of the deposits that the bank can offer you:");
            journalHelp.ShowAllDeposits(depCollection);
            while (true)
            {
                if (Int32.TryParse(Console.ReadLine(), out answ))
                {
                    if (answ < 1 && answ > depCollection.Count)
                    {
                        Console.WriteLine("Wrong input! Try again.");
                    }
                    else
                    {
                        break;
                    }
                }
                
            }
            Person help = new Person(fname, fsurname, fpatronymic, fpasport_ID, fsum, depCollection[answ - 1]);
            helpCollection.Add(help);
        }
        public void ReplenishmentOne(ref MyCustomCollection<Person> helpCollection)
        {

            if (helpCollection.Count == 0)
            {
                Console.WriteLine("First of all, create at least one client");
                return;
            }
            int answ;
            Console.WriteLine("Choose which client needs: ");
            journalHelp.ShowAllPersons(helpCollection);
            while (true)
            {
                if (Int32.TryParse(Console.ReadLine(), out answ))
                {
                    if (answ < 1 && answ > helpCollection.Count)
                    {
                        Console.WriteLine("Wrong input! Try again.");
                    }
                    else
                    {
                        break;
                    }
                }
            }
            helpCollection[answ - 1].Replenishment();           
        }
    }
}
