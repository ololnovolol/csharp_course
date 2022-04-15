using System;
using System.Collections;
using System.Collections.Generic;

namespace Solution.Algorithms_FundamentalOfAlgoAndDataStructures_.DualCircularLinkedList
{
    internal class DualCircularLinkedList<T> : IEnumerable<T>
    {
        private Node<T> head;
        private int count;

        public void Add(T data)
        {
            Node<T> node = new Node<T>(data);
            



            if (head == null)
            {
                head = node;

            } 
            else if (count == 1)
            {
                node.Next = head;
                node.Previous = head;

                head.Next = node;
                head.Previous = node;

            }
            else
            {
                node.Next = head;
                Node<T> bufer = head.Previous;
                bufer.Next = node;
                node.Previous = bufer;

                head.Previous = node;


            }



            count++;
        }

        public bool Remove(T data)
        {
            if (IsEmpty()) return false;

            Node<T> current = head;
            if (count == 1 && current.Data.Equals(data))
            {
                head = null;
                count = 0;
            }
            else if (count > 0)
            {
                if (head.Data.Equals(data))
                {
                    Node<T> bufferPrevios = head.Previous;
                    Node<T> bufferNext = head.Next;

                    bufferPrevios.Next = bufferNext;
                    bufferNext.Previous = bufferPrevios;
                    count--;

                    head = bufferNext;
                    
                    return true;
                }

                do
                {
                    if (current.Data.Equals(data))
                    {

                        Node<T> bufferPrevios = current.Previous;
                        Node<T> bufferNext = current.Next;

                        bufferPrevios.Next = bufferNext;
                        bufferNext.Previous = bufferPrevios;
                        count--;

                        //current.Previous = bufferPrevios;
                        //current.Next = bufferNext;

                        current = bufferNext;
                        return true;

                    }
                    current = current.Next;
                    
                } while (current != head);
            }

            return false;
        }
        public void Clear()
        {
            head = null;
            count = 0;
        }
        public bool Contains(T data)
        {
            int newcount = count;
            Node<T> current = head;

            if(current == null) return false;
            do
            {
                if(current.Data.Equals(data))
                {
                    return true;
                }
                current = current.Next;
                newcount--;
            } while (newcount != 0);
            return false;


            //DoublyNode<T> current = head;
            //if (current == null) return false;
            //do
            //{
            //    if (current.Data.Equals(data))
            //        return true;
            //    current = current.Next;
            //}
            //while (current != head);
            //return false;
        }

        public int GetCount() => count;

        public bool IsEmpty() => count == 0 ? true : false;

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = head;
            do
            {
                if (current != null)
                {
                    yield return current.Data;
                    current = current.Next;
                }
            }
            while (current != head);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

    }
}
