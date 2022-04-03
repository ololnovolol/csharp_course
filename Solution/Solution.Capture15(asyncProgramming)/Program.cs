using System;
using System.Threading;
using System.Threading.Tasks;

namespace Solution.Capture15_asyncProgramming_
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            BaseExampleVol1Async();
            BaseExampleVol2Async();
            await LyambdaAsynkExample();

            await ReturnRezultVoidAsync();
            await ReturnRezultTaskAsync();
            await ReturnRezultTaskAsyncVol1();
            await ReturnRezultTaskTAsyncVol2();
            await ReturnRezultTaskTAsyncVol3();
            await ReturnRezultVALUETaskTisSTRUCTAsync();

            await TaskWhenAllAsync();
            await TaskWhenAnyAsync();
            await TaskWhenAll2Async();
            await TaskWhenAny2Async();

            ErrorProcessingVoidAsynk();
            await ErrorProcessingTaskAsynk();
            await ExceptionTaskAsync();
            await WhenAllTasksExceptionsAsync();

            StreemsVolAsync(); //c# 8.0
            StreemsVolAsync(); //c# 8.0

            Console.ReadKey();
        }
        //part1
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
        //part2
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
            await Task.Delay(0);
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
        //part3
        public async static Task TaskWhenAllAsync()
        {
            Task<int> task1 = Print(10, 5);
            var task2 = Print(10, 5);
            var task3 = Print(10, 5);
            Console.WriteLine("Main job");

            await Task.WhenAll(task1, task2, task3);

            //int One = await task1;
            //int Two = await task2;
            //int Three = await task3;

            //Console.WriteLine($"Rezult Sum third task  {One} + {Two} + {Three} = {One + Two + Three}");

            Console.WriteLine("Main finish");//ждет всех и выполнется

            async Task<int> Print(int a, int b)
            {
                await Task.Delay(new Random().Next(1000, 2000));
                Console.WriteLine($"Result operation divide: {a} / {b} = {a / b}");
                return a / b;
            }
        }
        public static async Task TaskWhenAnyAsync()
        {
            Task<int> task1 = Print(10, 5);
            var task2 = Print(10, 5);
            var task3 = Print(10, 5);
            Console.WriteLine("Main job");

            await Task.WhenAny(task1, task2, task3);

            //int One =  task1;
            //int Two =  task2;
            //int Three =  task3;

            //Console.WriteLine($"Rezult Sum third task  {One} + {Two} + {Three} = {One + Two + Three}");
            Console.WriteLine("Main finish");//ждет хоть один и выполняется

            async Task<int> Print(int a, int b)
            {
                await Task.Delay(new Random().Next(1000, 2000));
                Console.WriteLine($"Result operation divide: {a} / {b} = {a / b}");
                return a / b;
            }
        }
        public async static Task TaskWhenAll2Async()
        {
            int numberforMethod = 5;
            Task<int> task1 = Result(numberforMethod++);
            Task<int> task2 = Result(numberforMethod++);
            Task<int> task3 = Result(numberforMethod++);

            //так нельзя
            //MasTask = await Task.WhenAny(task2, task1, task3);
            int[] MasTask = await Task.WhenAll(task2, task1, task3);

            int iter = 0;
            foreach (var item in MasTask)
            {

                Console.WriteLine($"mas[{iter}] = {item}");
                iter++;
            }


            async Task<int> Result(int num)
            {
                await Task.Delay(1000);
                Console.WriteLine($"Result Operation multy: {num * num}");
                return num * num;
            }
        }
        public async static Task TaskWhenAny2Async()
        {
            int numberforMethod = 5;
            Task<int> task1 = Result(numberforMethod++);
            Task<int> task2 = Result(numberforMethod++);
            Task<int> task3 = Result(numberforMethod++);

            int[] MasTas = new int[3];

            //так нельзя
            //MasTask = await Task.WhenAny(task2, task1, task3);

            for (int i = 0; i < 3; i++)
            {
                if (!task1.IsCanceled)
                    MasTas[i] = await task1;
                if (!task2.IsCanceled)
                    MasTas[i] = await task2;
                if (!task3.IsCanceled)
                    MasTas[i] = await task3;
            }

            int iter = 0;
            foreach (var item in MasTas)
            {

                Console.WriteLine($"mas[{iter}] = {item}");
                iter++;
            }


            async Task<int> Result(int num)
            {
                await Task.Delay(1000);
                Console.WriteLine($"Result Operation multy: {num * num}");
                return num * num;
            }
        }
        //part4
        public static async void ErrorProcessingVoidAsynk()
        {
            Print("hello");
            Print("hi");
            await Task.Delay(1000);

            async void Print(string message)
            {
                try
                {
                    if (message.Length < 3) throw new Exception($"Invalid string length{message.Length}");
                    await Task.Delay(200);
                    Console.WriteLine(message);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public static async Task ErrorProcessingTaskAsynk()
        {
            try
            {
                await PrintAsync("hello");
                await PrintAsync("hi");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            async Task PrintAsync(string message)
            {
                if (message.Length < 3) throw new ArgumentException($"Invalid string length{message.Length}");

                await Task.Delay(200);
                Console.WriteLine(message);
            }
        }
        public static async Task ExceptionTaskAsync()
        {
            Task task = PrintAsync("hi");

            try
            {
                await task;
            }
            catch (Exception)
            {
                Console.WriteLine(task.Exception.InnerException.Message);
                Console.WriteLine($"Task status {task.Status}");
                Console.WriteLine($"Task isFaultad = {task.IsFaulted}");
            }

            async Task PrintAsync(string message)
            {
                if (message.Length < 3) throw new ArgumentException($"Invalid string length{message.Length}");

                await Task.Delay(200);
                Console.WriteLine(message);
            }
        }
        public static async Task WhenAllTasksExceptionsAsync()
        {
            Task task1 = PrintAsync("hi");
            var task2 = PrintAsync("go");

            Task allTasks = Task.WhenAll(task1, task2);

            try
            {
                await allTasks;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception : {ex.Message}");
                Console.WriteLine($"IsFaulted: {allTasks.IsFaulted}");
                if (!(allTasks.Exception is null))
                {
                    foreach (var item in allTasks.Exception.InnerExceptions)
                    {
                        Console.WriteLine($"InnerExeptions message: {ex.Message}");
                    }
                }
            }

            async Task PrintAsync(string message)
            {
                if (message.Length < 3) throw new ArgumentException($"Invalid string length{message.Length}");

                await Task.Delay(200);
                Console.WriteLine(message);
            }
        }
        //part5
        public static async Task StreemsAsync()
        {
            //код не работает в данной версии с# !!!need ->8.0!!!
            // важно понимать
            //Фактически асинхронный стрим объединяет
            //асинхронность и итераторы

            //await foreach (var number in GetNumbersAsync())
            //{
            //    Console.WriteLine(number);
            //}

            //async IAsyncEnumerable<int> GetNumbersAsync()
            //{
            //    for (int i = 0; i < 10; i++)
            //    {
            //        await Task.Delay(100);
            //        yield return i;
            //    }
            //}
        }
        public static async Task StreemsVolAsync()
        {
            //Repository repo = new Repository();
            //IAsyncEnumerable<string> data = repo.GetDataAsync();
            //await foreach (var name in data)
            //{
            //    Console.WriteLine(name);
            //}

        }
    }
    public class Person
    {
        public string name;
        public Person(string name)
        {
            this.name = name;
        }

    }
    class Repository
    {
        string[] data = { "Tom", "Sam", "Kate", "Alice", "Bob" };
        //public async IAsyncEnumerable<string> GetDataAsync()
        //{
        //    for (int i = 0; i < data.Length; i++)
        //    {
        //        Console.WriteLine($"Получаем {i + 1} элемент");
        //        await Task.Delay(500);
        //        yield return data[i];
        //    }
        //}
    }


}
