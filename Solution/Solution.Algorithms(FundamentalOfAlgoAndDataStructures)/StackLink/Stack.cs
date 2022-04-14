using System;
using System.Collections;
using System.Collections.Generic;

namespace Solution.Algorithms_FundamentalOfAlgoAndDataStructures_.StackLink
{
    internal class Stack<T>
    {
        private int count;
        public T[] items;
        const int DEFAULT_LEUNGHT = 10;

        public Stack()
        {
            items = new T[DEFAULT_LEUNGHT];
        }

        public Stack(int leunght)
        {
            items = new T[leunght];
        }

        public bool IsEmpty()
        {
            if (count == 0) return true;
            return false;

            //get { return count == 0; }
        }

        public int Count() => count;

        // добaвление элемента
        public void Push(T item)
        {
            if (count == items.Length)
            {
                Resize(items.Length + 10);
            }
            items[count++] = item;
        }

        // извлечение элемента
        public T Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is Empty");
            }
            T item = items[--count];
            items[count] = default(T);

            if (count > 0 && count < items.Length - 10)
                Resize(items.Length - 10);
            return item;
        }

        // возвращаем элемент из верхушки стека
        public T Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is Empty");
            }
            return items[count - 1];

        }

        private void Resize(int newLeunght)
        {
            T[] temp = new T[newLeunght];
            for (int i = 0; i < newLeunght; i++)
            {
                temp[i] = items[i];

            }

            items = temp;
        }




    }
}
