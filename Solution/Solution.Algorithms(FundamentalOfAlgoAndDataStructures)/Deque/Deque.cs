using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Solution.Algorithms_FundamentalOfAlgoAndDataStructures_.Deque
{
    internal class Deque<T>
    {
        public Deque<T> Next { get; set; }

        public Deque<T> Previos { get; set; }
        public T Data;

        public Deque(T data)
        {
            Data = data;
        }


    }
}
