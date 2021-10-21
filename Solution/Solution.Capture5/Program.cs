using System;

namespace Solution.Capture5
{
    class Program
    {
        delegate void Shmelegate();
        delegate int Prilegate(int y, int x);
        delegate T Operation<T, K>( K val, K val1);
        delegate T OperationRef<T, K>(ref K val, ref K val1);
        static void Main(string[] args)
        {
            Shmelegate shm = Hello;
            Shmelegate shm1 = HowAreYou;
            Shmelegate shm3 = shm + shm1;
            shm3();

            Prilegate pri = Add;
            Console.WriteLine(pri(1, 2));
            Console.WriteLine(pri.Invoke(1,5));


            Operation<int, int> opOne = Add;
            Console.WriteLine(opOne(2,5));
            
            Operation<string, string> opTwo = Add;
            Console.WriteLine(opTwo("2", "5"));

            int a = 256;
            int b = 512;        
            OperationRef<int, int> opRef = AddX;
            int c = opRef(ref a, ref b);
            Console.WriteLine("c= " + c);

            //opOne = opTwo;//





            Console.ReadKey();


        }

        private static void Hello()
        {
            Console.WriteLine("Hello");
        }
        private static void HowAreYou()
        {
            Console.WriteLine("How are you?");
        }

        private static int Add(int x, int y) { return x + y; }
        private static string Add(string x, string y) { return x + y; }
        private static int AddX(ref int x, ref int y)
        {
            y = (x * 2) + y;
            return y;
        }
    }
}
