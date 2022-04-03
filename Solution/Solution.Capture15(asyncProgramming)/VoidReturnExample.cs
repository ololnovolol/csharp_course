using System;
using System.Threading.Tasks;

namespace Solution.Capture15_asyncProgramming_
{
    class VoidReturnExample
    {

        public async Task Starter()
        {
            Account acc = new Account();
            acc.Added += PrintAsync;

            acc.Put(500);

            await Task.Delay(1000);

            async void PrintAsync(object o, string message)
            {
                Console.WriteLine("Method PrintAsync started");
                await Task.Delay(1000);
                Console.WriteLine(message);
            }
        }

    }
    class Account
    {
        public int sum;
        public event EventHandler<string> Added;

        public void Put(int sum)
        {
            this.sum = sum;
            Added?.Invoke(this, $"in count put {sum}");

        }
    }
}
