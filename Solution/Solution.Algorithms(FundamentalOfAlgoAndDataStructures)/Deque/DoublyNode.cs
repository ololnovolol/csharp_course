using System;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Solution.Algorithms_FundamentalOfAlgoAndDataStructures_.Deque
{
    internal class DoublyNodeDeque<T> : IEnumerable<T>
    {
        public Deque<T> head { get; set; }
        public Deque<T> tail { get; set; }
        private int count;

        public void AddLast(T data)
        {
            Deque<T> node = new Deque<T>(data);

            if (head == null)
                head = node;
            else
            {
                tail.Next = node;
                node.Previos = tail;
            }
            tail = node;
            count++;
        }
        public void AddFirst(T data)
        {
            Deque<T> node = new Deque<T>(data);
            Deque<T> temp = head;
            node.Next = temp;
            head = node;
            if (count == 0)
                tail = head;
            else
                temp.Previos = node;
            count++;

        }
        public T RemoveFirst()
        {
            if (count == 0)
                throw new InvalidOperationException();
            T output = head.Data;
            if (count == 1)
            {
                head = tail = null;
            }
            else
            {
                head = head.Next;
                head.Previos = null;
            }
            count--;
            return output;
        }
        public T RemoveLast()
        {
            if(count == 0)
            {
                throw new InvalidOperationException();
            }
            T output = head.Data;
            if (count == 1)
            {
                tail = head = null;
            }
            else
            {
                tail = tail.Previos;
                tail.Next = null;
            }
            count--;
            return output;
           
        }

        public bool Contain(T data)
        {
            Deque<T> current = head;
            while(current != null)
            {
                if (current.Data.Equals(data))
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public bool IsEmpty() => count == 0;

        public int GetCount() => count;
       
        public IEnumerator<T> GetEnumerator()
        {
            Deque<T> current = head;
            while( current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }
    }
}
