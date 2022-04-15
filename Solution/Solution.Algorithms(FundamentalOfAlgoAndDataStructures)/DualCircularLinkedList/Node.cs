using System;

namespace Solution.Algorithms_FundamentalOfAlgoAndDataStructures_.DualCircularLinkedList
{
    internal class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Next { get; set; }
        public Node<T> Previous { get; set; }

        public Node(T data)
        {
            Data = data;
        }

    }
}
