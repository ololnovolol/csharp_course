using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Capture3.Generic
{
    class DepositAccount<U>
    {
        public U id;
        public DepositAccount(U id)
        {
            this.id = id;
        }
    }
}
