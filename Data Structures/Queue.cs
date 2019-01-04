using System;

namespace Data_Structures
{
    public class Queue<T> where T: IComparable
    {
        private DoublyLinkedList<T> _list = new DoublyLinkedList<T>();
        
        public T Peek()
        {
            return _list.Head.Value;
        }

        public void Enqueue<U>(U element) where U : T
        {
            _list.InsertEnd(element);
        }

        public void Dequeue() 
        {
            if (_list.Head.Next != null)
            {
                _list.Head.Next.Previous = null;
                _list.Head = _list.Head.Next;
            }
            else
            {
                _list.Head = null;
                _list.Tail = null;
            }
        } 
    }
}