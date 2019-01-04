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
            Head = null;
            Tail = null;
        }

        public DoublyLinkedList(T initialValue)
        {
            var initialNode = new DoublyNode<T>()
            {
                Value = initialValue,
                Next = null,
                Previous = null
            };
            Head = initialNode;
            Tail = initialNode;
        }

        public DoublyNode<T> Head { get; set; }
        public DoublyNode<T> Tail { get; set; }


        public void InsertAfter<U>(DoublyNode<T> node, U value) where U : T
        {
            var newNode = new DoublyNode<T>()
            {
                Value = value,
                Previous = node
            };

            if (node.Next == null)
            {
                Tail = newNode;
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

            if (node.Previous == null)
            {
                newNode.Previous = null;
                Head = newNode;
            }
            else
            {
                newNode.Next = node;
                node.Previous.Next = newNode;
            }

            node.Previous = newNode;
        }

        public void InsertBegin<U>(U value) where U : T
        {
            var newNode = new DoublyNode<T>()
            {
                Value = value,
            };

            if (Head == null)
            {
                Head = newNode;
                Tail = newNode;
                newNode.Previous = null;
                newNode.Next = null;
            }
            else
            {
                InsertBefore(Head, value);
            }
        }

        public void InsertEnd<U>(U value) where U : T
        {
            if (Tail == null)
            {
                InsertBegin(value);
            }
            else
            {
                InsertAfter(Tail, value);
            }
        }

        /// <summary>
        /// Removes the first occurence of node with given value
        /// </summary>
        /// <param name="value"></param>
        /// <typeparam name="U"></typeparam>
        public void RemoveFirst<U>(U value) where U : T
        {
            // TODO: Implement and test this method
        }
    }
}