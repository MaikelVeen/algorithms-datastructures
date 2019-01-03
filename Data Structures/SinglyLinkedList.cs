using System;

namespace Data_Structures
{
    public class LinkedListNode<T> where T : IComparable
    {
        public T Value { get; set; }
        public LinkedListNode<T> Next { get; set; }
    }

    public class SinglyLinkedList<T> where T : IComparable
    {
        public LinkedListNode<T> Start { get; set; }

        public LinkedListNode<T> Find<U>(U value) where U : T
        {
            var p = Start;
            while (p != null && p.Value.CompareTo(value) != 0)
            {
                p = p.Next;
            }

            return p;
        }

        // Places value before the value its bigger than, 
        // It is assumed that the linked list is sorted
        public void Insert<U>(U value) where U : T
        {
            if (Start == null || Start.Value.CompareTo(value) > 0)
            {
                Start = new LinkedListNode<T>()
                {
                    Value = value,
                    Next = Start
                };
            }

            var currentNode = Start;
            while (currentNode.Next != null && currentNode.Next.Value.CompareTo(value) <= 0)
            {
                currentNode = currentNode.Next;
            }

            currentNode.Next = new LinkedListNode<T>()
            {
                Value = value,
                Next = currentNode.Next
            };
        }

        // Finds the first occurence of the value and deletes it
        // It is assumed that te linked list is sorted
        public void RemoveValue<U>(U value) where U : T
        {
            if (Start == null || Start.Value.CompareTo(value) > 0)
            {
                // The value does not exist
                return;
            }

            // ReSharper disable once InvertIf
            if (Start.Value.CompareTo(value) == 0)
            {
                Start = Start.Next;
                return;
            }

            var currentNode = Start;
            while (currentNode.Next != null && currentNode.Next.Value.CompareTo(value) <= 0)
            {
                if (currentNode.Next.Value.CompareTo(value) == 0)
                {
                    currentNode.Next = currentNode.Next.Next;
                    return;
                }

                currentNode = currentNode.Next;
            }
        }
    }
}