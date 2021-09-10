using System;
using _053506_Gotchenya_Lab5.Collections;
using _053506_Gotchenya_Lab5.Entities;

namespace _053506_Gotchenya_Lab5
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Menu mm = new Menu();
            Journal journal = new Journal();
            journal.AddClientMessage();
            journal.AddDepositMessage();
            MyCustomCollection<Deposit> depCollection = mm.DepositsCreation();
            MyCustomCollection<Person> persCollection = mm.PersonsCreation(depCollection);
            MyCustomCollection<int> intcol = new MyCustomCollection<int>();
            intcol.Add(10);
            intcol.Remove(100);
            Console.WriteLine("Hello, your personal banking assistant welcomes you! What would you like to do?");
            int answ = -1;
            while (answ != 0)
            {

                Console.WriteLine("Display information about all available deposits - 1");
                Console.WriteLine("Display information about all bank clients - 2");
                Console.WriteLine("Add new deposit - 3");
                Console.WriteLine("Add new customer  - 4");
                Console.WriteLine("Calculate the total amount of interest payments for all deposits - 5");
                Console.WriteLine("Replenish the amount of the deposit for all clients - 6");
                Console.WriteLine("Replenish the amount of the client's deposit - 7");
                Console.WriteLine("Exit - 0");
                Console.WriteLine("Enter what you want to do:");
                while (true)
                {
                    if(Int32.TryParse(Console.ReadLine(),out answ))
                    {
                        if(answ >= 0 && answ <= 7)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Wrong input! Try again.");
                        }
                    }
                }
                switch(answ)
                {
                    case 0:
                        {
                            answ = 0;
                            break;
                        }
                    case 1:
                        {
                            journal.ShowAllDeposits(depCollection);
                            break;
                        }
                    case 2:
                        {
                            journal.ShowAllPersons(persCollection);
                            break;
                        }
                    case 3:
                        {
                            mm.AddDeposit(ref depCollection);
                            break;
                        }
                    case 4:
                        {
                            mm.AddPerson(ref persCollection, depCollection);
                            break;
                        }
                    case 5:
                        {
                            mm.PayoffAll(persCollection);
                            break;
                        }
                    case 6:
                        {
                            mm.ReplenishmentAll(persCollection);
                            break;
                        }
                    case 7:
                        {
                            mm.ReplenishmentOne(ref persCollection);
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
                mm.StarLine();
            }
            Console.WriteLine("Good bye, my friend!"); 
        }
    }
}
