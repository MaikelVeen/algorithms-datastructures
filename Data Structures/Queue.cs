using System;
using System.Data;

namespace Data_Structures
{
    public class Queue<T> where T : IComparable
    {
        private readonly DoublyLinkedList<T> list = new DoublyLinkedList<T>();
        public int Count { get; private set; }

        /// <summary>
        /// Return the item at the front of the queue
        /// </summary>
        /// <returns></returns>
        public T Peek()
        {
            return list.Head == null ? default(T) : list.Head.Value;
        }

        /// <summary>
        /// Appends an item at the end of the queue
        /// </summary>
        /// <param name="element"></param>
        public void Enqueue(T element)
        {
            list.InsertEnd(element);
            Count++;
        }

        /// <summary>
        /// Removes an element at the front of the queue
        /// </summary>
        public T Dequeue()
        {
            if (list.Head == null)
            {
                throw new Exception("Cannot dequeue in an empty queue");
            }

            T returnValue = list.Head.Value;
            if (list.Head.Next != null)
            {
                list.Head.Next.Previous = null;
                list.Head = list.Head.Next;
                Count--;
            }
            else
            {
                list.Head = null;
                list.Tail = null;
                Count--;
            }

            return returnValue;
        }

        /// <summary>
        /// Returns true if list is empty otherwise false
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return list.Head == null && list.Tail == null;
        }

        /// <summary>
        /// Returns true when list is not empty otherwise false
        /// </summary>
        /// <returns></returns>
        public bool IsNotEmpty()
        {
            return !(list.Head == null && list.Tail == null);
        }
        
        /// <summary>
        /// Return whether or not the queue contains a certain value somewhere in the queue
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Contains(T value)
        {
            if (list.Head == null) return false;
            DoublyNode<T> currentNode = list.Head;

            if (list.Head.Value.Equals(value)) return true;
            while (currentNode.Next != null)
            {
                if (currentNode.Next.Value.Equals(value))
                {
                    return true;
                }

                currentNode = currentNode.Next;
            }

            return false;
        }
    }
}