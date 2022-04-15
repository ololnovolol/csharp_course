using System;
using System.Collections;
using System.Collections.Generic;

namespace Solution.Algorithms_FundamentalOfAlgoAndDataStructures_.CircularLinkedList
{
    internal class CircularLinkedList<T> : IEnumerable<T>
    {
        private Node<T> first;
        private Node<T> last;
        private int count;

        public void Add(T data)
        {
            Node<T> node = new Node<T>(data);

            if (first == null)
            {
                first = node;
                last = node;
            }
            else
            {
                last.Next = node;
                last = node;
                last.Next = first;
            }
            count++;
        }

        public bool Remove(T data)
        {
            Node<T> current = first;
            Node<T> previous = last;

            if (count == 0)
            {
                return false;
            }
            if (count == 1)
            {
                if (current.Data.Equals(data))
                {
                    first = last = null;
                    return true;
                }
                return false;
            }
            else
            {
                // если первый елемент
                if (first.Data.Equals(data))
                {
                    previous.Next = current.Next;
                    count--;
                    first = current.Next;
                    return true;
                }
                do
                {
                    if(current.Next == last && current.Next.Data.Equals(data))
                    {
                        current.Next = first;
                        last = current;
                        count--;
                        return true;
                    }
                    if (current.Data.Equals(data))
                    {
                        previous.Next = current.Next;
                        count--;
                        return true;
                    }
                    current = current.Next;
                    previous = previous.Next;
                    

                } while (current != last);
                return false;
            }
        }

        public int GetCount() => count;

        public bool IsEmpty() => count == 0 ? true : false;

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = first;
           do
            {
                if (current != null)
                {
                    yield return current.Data;
                    current = current.Next;
                }
            }
            while (current != first);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }
    }
}
