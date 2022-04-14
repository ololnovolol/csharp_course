using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Solution.Algorithms_FundamentalOfAlgoAndDataStructures_.Queue
{
    internal class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Next { get; set; }


        public Node(T data)
        {
            Data = data;
        }
    }
}
