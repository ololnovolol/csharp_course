
namespace Solution.Algorithms_FundamentalOfAlgoAndDataStructures_.CircularLinkedList
{
    internal class Node<T>
    {
        public Node<T> Next { get; set; }
        public T Data;

        public Node(T data)
        {
            Data = data;
        }

    }
}
