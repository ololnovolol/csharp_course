using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Capture3.Generic
{
    class DemandAccount<U> : DepositAccount<U>
    {
        public DemandAccount(U _id) : base(_id)
        {
        }
    }
}
