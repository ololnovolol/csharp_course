using System;
using System.Collections;
using System.Collections.Generic;

namespace Solution.Algorithms_FundamentalOfAlgoAndDataStructures_.Queue
{
    internal class Queue<T> : IEnumerable<T>
    {
        public Node<T> head;
        public Node<T> tail;
        public int count { get; }

        public void Enqueue(T data)
        {


        }

        public T Dequeue()
        {

        }

        public T First()
        {

        }
        // получаем последний элемент
        public T Last()
        {

        }
        public int Count()
        {
        }
        public bool IsEmpty()

        {
        }

        public void Clear()
        {
        }

        public bool Contains(T data)
        {
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
