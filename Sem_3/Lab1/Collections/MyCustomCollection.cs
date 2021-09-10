using System;
using System.Collections.Generic;
using System.Text;
using _053506_Gotchenya_Lab5;
using _053506_Gotchenya_Lab5.Interfaces;


namespace _053506_Gotchenya_Lab5.Collections
{
    class MyCustomCollection<T>: Node<T>, ICustomCollection<T>
    {
        Node<T> first = new Node<T>();
        Node<T> curr = new Node<T>();
        int amount = 0;

        public T this[int index] 
        {
            get
            {
                /*
                if(index > amount - 1)
                {
                    Console.WriteLine("No such element exists.");
                    return default;
                }
                else
                {
                    Node<T> help = new Node<T>();
                    help = first;
                    int counter = 0;
                    while(counter != index)
                    {
                        help = help.next;
                        counter++;
                    }
                    return help.val;
                }
                */
                try
                {
                    Node<T> help = new Node<T>();
                    help = first;
                    int counter = 0;
                    while (counter != index)
                    {
                        help = help.next;
                        counter++;
                    }
                    return help.val;
                }
                catch(IndexOutOfRangeException)
                {
                    Console.WriteLine("No such element exists.");
                    return default;
                }


            }
            set
            {
                if (index > amount - 1)
                {
                    Console.WriteLine("No such element exists.");
                }
                else
                {
                    int counter = 0;
                    Node<T> help = new Node<T>();
                    help = first;
                    while (counter != index)
                    {
                        help = help.next;
                        counter++;
                    }
                    help.val = value;
                }           
            }
        }

        public void Reset()
        {
            if(amount == 0)
            {
                Console.WriteLine("Collection is empty.");
                return;
            }
            curr = first;
        }

        public void Next()
        {
            if (amount == 0)
            {
                Console.WriteLine("Collection is empty.");
                return;
            }
            if (curr.next != null)
            {
                curr = curr.next;
            }
            else
            {
                Console.WriteLine("This is the last element.");
            }
        }

        public T Current()
        {
            if (amount == 0)
            {
                Console.WriteLine("Collection is empty.");
                return default;
            }
            return curr.val;
        }
        public int Count 
        { 
            get
            {
                return amount;
            }
        }

        public void Add(T item)
        {       
            if (amount == 0)
            {
                first.val = item;
                curr = first;
                amount++;
                return;
            }
            else
            {
                Node<T> help = new Node<T>(item);
                Node<T> helpcurr = first;
                while (helpcurr.next != null)
                {
                    helpcurr = helpcurr.next;
                }
                help.prev = helpcurr;
                helpcurr.next = help;
                amount++;
            }
        }

        public void Remove(T item)
        {

            try
            {
                if (amount == 0)
                {
                    Console.WriteLine("Collection is empty.");
                    return;
                }

                Node<T> help = first;
                while (!(help.val.Equals(item)) && help.next != null)
                {
                    help = help.next;
                }
                if (!(help.val.Equals(item)) && help.next == null)
                {
                    throw new ImpossToRemoveException("No such element exists.");
                    //Console.WriteLine("No such element exists.");
                    //return;
                }

                if (help.Equals(first))
                {
                    if (amount == 1)
                    {
                        first.val = default;
                        curr.val = default;
                        amount--;
                        return;
                    }
                    else
                    {
                        (first.next).prev = null;
                        first = first.next;
                        curr = first;
                        amount--;
                        return;
                    }
                }
                else
                {
                    if (help.prev != null)
                    {
                        (help.prev).next = help.next;
                    }
                    if (help.next != null)
                    {
                        (help.next).prev = help.prev;
                    }
                    curr = first;
                    amount--;
                    return;
                }
            }
            catch(ImpossToRemoveException)
            {
                Console.WriteLine("You tried to remove the next item - {0}", item);
            }
        }

        public T RemoveCurrent()
        {
            if (amount == 0)
            {
                Console.WriteLine("Collection is empty.");
                return default;
            }

            if (curr.Equals(first))
            {
                if (amount == 1)
                {
                    first.val = default;
                    curr.val = default;
                    amount--;
                    return default;
                }
                else
                {
                    first = first.next;
                    curr = first;
                    amount--;
                    return default;
                }
            }
            else
            {
                if (curr.prev != null)
                {
                    (curr.prev).next = curr.next;
                }
                if (curr.next != null)
                {
                    (curr.next).prev = curr.prev;
                }
                curr = first;
                amount--;
                return default;
            }

        }
    }
}
