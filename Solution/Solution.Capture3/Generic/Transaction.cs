using System;
namespace Solution.Capture3.Generic
{
    class Transaction<T> where T : Account
    {
        public T FromAccount { get; set; }
        public T ToAccount { get; set; }
        public int SumTransaction { get; set; }

        public void Execute()
        {
            if (FromAccount.CurrentSum > SumTransaction)
            {
                FromAccount.CurrentSum -= SumTransaction;
                ToAccount.CurrentSum += SumTransaction;
                Console.WriteLine($"Balanse from ID - {FromAccount.Id}: {FromAccount.CurrentSum}$ \nBalanse from ID - {ToAccount.Id}: {ToAccount.CurrentSum}$");
            }
            else
            {
                Console.WriteLine($"Not enough money in the account {FromAccount.Id}");
            }
        }

    }
}
