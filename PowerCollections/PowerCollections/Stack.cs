using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace PowerCollections
{
    public class Stack<T> : IEnumerable<T>
    {
        T[] items;
        int count = 0;
        public int Count
        {
            get
            {
                return count;
            }
        }
        public int Capacity
        {
            get
            {
                return items.Length;
            }
        }
        public Stack()
        {
            const int defaultCapacity = 10;
            items = new T[defaultCapacity];
        }
        public Stack(int capacity)
        {
            items = new T[capacity];
        }

        public void Push(T item)
        {
            if (count == items.Length)
                throw new Exception("Stack is full");
            items[count++] = item;
        }
        public T Pop()
        {
            if (count == 0)
                throw new Exception("Stack is empty");
            T item = items[--count];
            items[count] = default(T);
            return item;
        }
        public T Top()
        {
            if (count == 0)
                throw new Exception("The top of the stack is empty");
            return items[count - 1];
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = Count - 1; i >= 0; i--)
            {
                yield return items[i];
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}