using System;

namespace Data_Structures
{
    public class Queue<T> where T: IComparable
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
        public void Dequeue()
        {
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
        }
        
        /// <summary>
        /// Returns whether or not the list is empty
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return list.Head == null && list.Tail == null;
        }
    }
}