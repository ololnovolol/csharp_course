using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Solution.BaseNetwork_StreamsBinaryData_
{
    internal class Account
    {
        public string Id { get; private set; }
        public string Name { get; private set; }
        public decimal Sum { get; private set; }
        public int Procent { get; private set; }

        public Account(string id, decimal sum, int period)
        {
            Id = id;
            Sum = sum;
            Procent = period > 6 ? 10 : 1;
        }
    }
}
