using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Capture3.Generic
{
    class TurboAcount : DemandAccount<Account>
    {
        public TurboAcount(Account _id) : base(_id)
        {
        }
    }
}
