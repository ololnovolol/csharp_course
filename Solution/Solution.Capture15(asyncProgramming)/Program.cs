using System;
using System.Threading.Tasks;
using System.Threading;

namespace Solution.Capture15_asyncProgramming_
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //BaseExampleVol1Async();
            //BaseExampleVol2Async();


            Console.ReadKey();

        }
        public async static void BaseExampleVol1Async()
        {
            await PrintAsync();   // вызов асинхронного метода
            Console.WriteLine("Некоторые действия в методе Main");

            void Print()
            {
                Thread.Sleep(3000);     // имитация продолжительной работы

                // или так
                //await Task.Delay(TimeSpan.FromMilliseconds(3000));
                Console.WriteLine("Hello METANIT.COM");
            }

            // определение асинхронного метода
            async Task PrintAsync()
            {
                Console.WriteLine("Начало метода PrintAsync"); // выполняется синхронно
                await Task.Run(() => Print());                // выполняется асинхронно
                Console.WriteLine("Конец метода PrintAsync");
            }
        }

        public async static void BaseExampleVol2Async()
        {
            //вызываю три способа одной задачи для понимания оптимизации Асинхрона
            PrintNOASYNC();
            Console.Clear();
            await PRINTvar1NONoptimizationASYNC();
            Console.Clear();
            await PRINTvar2OPTIMIZATIONasync();


            void PrintNOASYNC()
            {
                Print("no async 1");
                Print("no async 2");
                Print("no async 3");

                void Print(string name)
                {
                    Thread.Sleep(3000);
                    Console.WriteLine(name);
                }
            }
            async Task PRINTvar1NONoptimizationASYNC()
            {
                await Print("async NO_OPTIMIZED 1");
                await Print("async NO_OPTIMIZED 2");
                await Print("async NO_OPTIMIZED 3");

                async Task Print(string name)
                {
                    await Task.Delay(3000);
                    Console.WriteLine(name);
                }
            }
            async Task PRINTvar2OPTIMIZATIONasync()
            {
                
                var start1 = Print("async OPTIMIZED =)");
                var start2 = Print("async OPTIMIZED =)");
                var start3 = Print("async OPTIMIZED =)");
                Console.WriteLine("Yeah this is super optimized=)");

                await start1;
                await start2;
                await start3;

                async Task Print(string name)
                {
                    await Task.Delay(3000);
                    Console.WriteLine(name);
                }
            }
        }



    }
}
