using System;
using System.Collections.Generic;
using System.Linq;

namespace Data_Structures
{
    public class Stack<T>
    {
        private List<T> Data { get; set; }
        public int Count { get; private set; }

        public Stack()
        {
            Data = new List<T>();
        }

        /// <summary>
        /// Adds an element on top of the stack
        /// </summary>
        /// <param name="element"></param>
        public void Push(T element)
        {
            Data.Add(element);
            Count++;
        }

        /// <summary>
        /// Returns the element currently on top of the stack
        /// and subsequently removes it
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public T Pop()
        {
            if (Count == 0)
            {
                throw new Exception("Underflow in Stack");
            }

            T dataToReturn = Data[Count - 1];
            Data.RemoveAt(Count - 1);
            Count--;
            return dataToReturn;
        }

        /// <summary>
        /// Returns value currently on top of the stack
        /// </summary>
        /// <returns></returns>
        public T Peek() => Data.ElementAt(Count - 1);

        /// <summary>
        /// Determines whether value is in stack or not
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Contains(T value) => Data.Contains(value);

        /// <summary>
        /// Returns an array with all the elements of the stack
        /// </summary>
        /// <returns></returns>
        public T[] ToArray() => Data.ToArray();
    }
}