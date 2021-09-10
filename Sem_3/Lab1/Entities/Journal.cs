using System;
using System.Collections.Generic;
using System.Text;
using _053506_Gotchenya_Lab5.Collections;

namespace _053506_Gotchenya_Lab5.Entities
{
    class Journal
    {
        delegate void CollectionHandler(string message);
        event CollectionHandler CreationClientEvent;

        public void ShowAllDeposits(MyCustomCollection<Deposit> helpCollection)
        {
            Console.WriteLine("Deposits: ");
            for (int i = 0; i < helpCollection.Count; i++)
            {
                Console.WriteLine("Deposit №" + (i + 1) + ' ' + helpCollection[i].ToString());
            }
        }

        public void ShowAllPersons(MyCustomCollection<Person> helpCollection)
        {
            Console.WriteLine("Persons: ");
            for (int i = 0; i < helpCollection.Count; i++)
            {
                Console.WriteLine("Person №" + (i + 1) + ' ' + helpCollection[i].ToString());
            }
        }
        public void AddClientMessage()
        {
            Console.WriteLine("***********************************************************************************************************Client_Creation******************************************************************************************************************");        
        }
        public void AddDepositMessage()
        {
            Console.WriteLine("***********************************************************************************************************Deposit_Creation*****************************************************************************************************************");
        }
    }
}
