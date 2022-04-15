using System;
using System.Collections;
using System.Collections.Generic;

namespace Solution.Algorithms_FundamentalOfAlgoAndDataStructures_.Queue
{
    internal class Queue<T> : IEnumerable<T>
    {
        public Node<T> head;
        public Node<T> tail;
        private int count;

        public void Enqueue(T data)
        {
            Node<T> node = new Node<T>(data);
            Node<T> buffer = tail;
            tail = node;

            //count == null
            if (head == null)
            {
                head = tail;
            }
            else
            {
                buffer.Next = tail;
            }

            count++;
        }

        public T Dequeue()
        {
            if (count != 0)
            {
                T buffer = head.Data;
                head = head.Next;
                count--;
                return buffer;
            }
            else
            {
                throw new InvalidOperationException("List is Empty");
            }



        }

        public T First()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("List is Empty");
            }
            return head.Data;
        }
        // получаем последний элемент
        public T Last()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("List is Empty");
            }
            return tail.Data;
        }
        public int Count() => count;

        public bool IsEmpty() => count == 0;

        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public bool Contains(T data)
        {
            Node<T> current = head;
            while (current !=  null)
            {
                if (current.Data.Equals(data))
                {
                    return true;
                }
                current = current.Next;
            }
            return false;

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
           return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node<T> current = head;
            while(current != null)
            {
                yield return current.Data;
                    current = current.Next;
            }
        }
    }
}
