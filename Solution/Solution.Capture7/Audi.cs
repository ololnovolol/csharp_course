using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Capture7
{
    class Audi
    {
        public int speed { get; init; }
        public string name { get; init; }
        public void Drive()
        {
            Console.WriteLine($"car {name} move with speed {speed}");
        }
    }
}
