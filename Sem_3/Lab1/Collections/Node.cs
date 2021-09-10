using System;
using System.Collections.Generic;
using System.Text;

namespace _053506_Gotchenya_Lab5.Collections
{
    class Node<T>
    {
        protected internal T val;
        protected internal Node<T> next;
        protected internal Node<T> prev;

        protected internal Node(T _val)
        {
            val = _val;
            next = null;
            prev = null;
        }
        protected internal Node()
        {
            val = default(T);
            next = null;
            prev = null;
        }
    }
}
