using System;

namespace Data_Structures
{
    public class DoublyNode<T> where T : IComparable
    {
        public DoublyNode<T> Next { get; set; }
        public DoublyNode<T> Previous { get; set; }
        public T Value { get; set; }
    }


    public class DoublyLinkedList<T> where T : IComparable
    {
        public DoublyLinkedList()
        {
            First = null;
            Last = null;
        }
        public DoublyLinkedList(T initialValue)
        {
            var initialNode = new DoublyNode<T>()
            {
                Value = initialValue,
                Next = null,
                Previous = null
            };
            First = initialNode;
            Last = initialNode;
        }

        public DoublyNode<T> First { get; set; }
        public DoublyNode<T> Last { get; set; }
        
        
        public void InsertAfter<U>(DoublyNode<T> node, U value) where U : T
        {
            var newNode = new DoublyNode<T>()
            {
                Value = value,
                Previous = node
            };
            if (node.Next == null)
            {
                Last = newNode;
            }
            else
            {
                newNode.Next = node.Next;
                node.Next.Previous = newNode;
            }

            node.Next = newNode;
        }

        public void InsertBefore<U>(DoublyNode<T> node, U value) where U : T
        {
            var newNode = new DoublyNode<T>()
            {
                Value = value,
                Next = node
            };
        }

        public void InsertBegin<U>(DoublyNode<T> node, U value) where U : T
        {
            var newNode = new DoublyNode<T>()
            {
                Value = value,
                Previous = null
            };

            if (First != null)
            {
                First.Previous = newNode;
            }
            
            newNode.Next = First;
            First = newNode;
        }

        public void InsertEnd<U>(DoublyNode<T> node, U value) where U : T
        {
        }

        public void Remove<U>(U value) where U : T
        {
        }
    }
}