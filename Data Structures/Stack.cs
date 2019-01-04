using System;
using System.Collections.Generic;
using System.Linq;

namespace Data_Structures
{
    public class Stack<T>
    {
        private List<T> _data;
        private int _top;

        public Stack()
        {
            _data = new List<T>();
            _top = 0;
        }

        public void Push<U>(U element) where U : T
        {
            _data.Add(element);
            _top += 1;
        }

        public void Pop()
        {
            if (_top == 0)
            {
                throw new Exception("Underflow in Stack");
            }

            _data.RemoveAt(_top - 1);
            _top -= 1;
        }

        public T Peek()
        {
            return _data.ElementAt(_top - 1);
        }

        public int Size()
        {
            return _top;
        }
    }
}