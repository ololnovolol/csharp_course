using System;
using System.Threading;

namespace Solution.Capture17_Parallel_Linq_
{
    class Program
    {
        public static void Main(string[] args)
        {

            Parallelwork();
            


            Console.ReadKey();
        }
        public static void Parallelwork()
        {
            int[] numbers = { -5, -4, -3, -2, -1, 0, 1, 2, 3, 4, 5, 6, 7 };
            object [] numberss = { -5, -4, -3, -2, -1, 0, 1, 2, 3, 4, "5" };
             
            AsParallel(numbers);
            Console.WriteLine("----------");
            AsOrdered(numbers);
            Console.WriteLine("----------");
            AggregateExceptionOperate(numberss);
            Console.WriteLine("----------");
            AggregateExceptionSolution(numberss);


        }

        public static void AsParallel(int[] numbers)
        {
            //var1
            //var squareNumbers = from n in numbers.AsParallel()
            //                    where n > 0
            //                    select (Square(n));

            //foreach (var item in squareNumbers)
            //{
            //    Console.WriteLine(item);
            //}

            //var2 optimized

            numbers.AsParallel().Where(n => n > 0).Select(n => Square(n)).ForAll(Console.WriteLine);

            static int Square(int n) => n * n;

        }

        public static void AsOrdered(int[] numbers)
        {
            //var 1
            //var result = from n in numbers.AsParallel().AsOrdered()
            //             where n > 0
            //             select Square(n);

            //foreach (var item in result)
            //{
            //    Console.WriteLine(item);
            //}

            //var 2

            var result = from n in numbers.AsParallel().AsUnordered()
                         where n > 0
                         select Square(n);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }


            static int Square(int n) => n * n;
        }

        public static void AggregateExceptionOperate(object[] numbers)
        {
            var squares = from n in numbers
                          let x = (int)n
                          select x * x;



            try
            {
                foreach (var item in squares)
                {
                    Console.WriteLine(item);
                }
            }
            catch(Exception)
            {
                //foreach (var item in ex.InnerExceptions)
                //{
                //    Console.WriteLine(item.Message);
                //}
                Console.WriteLine("Error");
            }



        }

        public static void AggregateExceptionSolution(object[] numbers)
        {
            CancellationTokenSource cts = new CancellationTokenSource();

            var task = new Task(() =>
            {
                Thread.Sleep(400);
                cts.Cancel();
            });
            task.Start();

            try
            {
                var result = from n in numbers.AsParallel().WithCancellation(cts.Token)
                             let x = (int)n
                             select Square(x);

                foreach (var item in result)
                {
                    Console.WriteLine(item);
                }

            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Операция была прервана");
            }
            catch (AggregateException ex)
            {
                if (ex.InnerExceptions != null)
                {
                    foreach (Exception e in ex.InnerExceptions)
                        Console.WriteLine(e.Message);
                }
            }
            finally
            {
                cts.Dispose();
            }
            
            static int Square(int n)
            {
                Thread.Sleep(1000);
                return n * n;
            }
        }


    }
}

