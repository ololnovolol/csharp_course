using System;

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
