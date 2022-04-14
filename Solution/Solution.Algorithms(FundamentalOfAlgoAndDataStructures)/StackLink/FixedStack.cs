using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Solution.Algorithms_FundamentalOfAlgoAndDataStructures_.StackLink
{
    internal class FixedStack<T>
    {
        private int count;
        public T[] items;
        const int DEFAULT_LEUNGHT = 10;

        public FixedStack()
        {
            items = new T[DEFAULT_LEUNGHT];
        }

        public FixedStack(int leunght)
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
                throw new InvalidOperationException("Stack is crowded");
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




        }
}
