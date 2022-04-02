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
            //await LyambdaAsynkExample();
            //await ReturnRezultVoidAsync();
            //await ReturnRezultTaskAsync();
            //await ReturnRezultTaskAsyncVol1();
            //await ReturnRezultTaskTAsyncVol2();
            //await ReturnRezultTaskTAsyncVol3();
            await ReturnRezultVALUETaskTisSTRUCTAsync();

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
        public async static Task LyambdaAsynkExample()
        {

            Func<string, Task> Print = async (message) =>
            {
                await Task.Delay(3000);
                Console.WriteLine(message);
            };

            await Print("one");
            await Print("two");
            await Print("three");
        }

        public async static Task ReturnRezultVoidAsync()
        {
            VoidReturnExample voidRE = new VoidReturnExample();
            await voidRE.Starter();

        }
        public async static Task ReturnRezultTaskAsync()
        {
            var task = PrintAsync("one - one");
            Console.WriteLine("Main Works");

            await task; // task.Wait(); одно и тоже??

            Console.WriteLine("Main end");


            async Task PrintAsync(string message)
            {
                await Task.Delay(1000);
                Console.WriteLine(message);
                await Task.Delay(250);
            }
        }
        public async static Task ReturnRezultTaskAsyncVol1()
        {
            int n1 = await SquareAsync(5);
            int n2 = await SquareAsync(6);
            Console.WriteLine($"n1={n1}  n2={n2}"); // n1=25  n2=36

            async Task<int> SquareAsync(int n)
            {
                await Task.Delay(0);
                return n * n;
            }
        }
        public async static Task ReturnRezultTaskTAsyncVol2()
        {
            Person person = await GetPersonAsync("Tom");
            Console.WriteLine(person.name); // Tom
                                            // определение асинхронного метода
            async Task<Person> GetPersonAsync(string name)
            {
                await Task.Delay(100);
                return new Person(name);
            }
        }
        public async static Task ReturnRezultTaskTAsyncVol3()
        {
            Task<int> task1 = Multiple(3);
            var task2 = Multiple(5);

            Console.WriteLine("procces main ");

            int one = await task1;
            int two = await task2;

            Console.WriteLine($"one = {one}\n two = {two}");
            //Console.WriteLine($"task1 type={task1.GetType()} \ntask2 type ={task2.GetType()} ");

            async Task<int> Multiple(int number)
            {
                await Task.Delay(0);
                int result = number * number;
                Console.WriteLine($"result multiple: {result} = {number} * {number}");
                return result;
            }
        }
        public async static Task ReturnRezultVALUETaskTisSTRUCTAsync()
        {
            //await PrintAsync("Hello METANIT.COM");

            //Person person = await GetPersonAsync("Tom");
            //Console.WriteLine(person.name); // Tom

            //// определение асинхронного метода
            //async ValueTask PrintAsync(string message)
            //{
            //    await Task.Delay(0);
            //    Console.WriteLine(message);
            //}

            //// определение асинхронного метода
            //async ValueTask<Person> GetPersonAsync(string name)
            //{
            //    await Task.Delay(0);
            //    return new Person(name);
            //}
            //record class Person(string Name);

            ///данный код работает в новых версиях c# начиная с 9.0 вроде
        }


        public class Person
        {
            public string name;
            public Person(string name)
            {
                this.name = name;
            }

        }

    } 
}