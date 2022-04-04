using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Solution.Capture14_ParallelProgrammingTPL_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamReader sm = new StreamReader("Text.txt");
            {
                string line;
                while ((line = sm.ReadLine()) != null)
                {
                    BasePrincipsTasks();
                    WaitMethodTaskPrincipis();
                    SynhroStartedTasks();
                    NestedTask();
                    MassiveTaskVar1();
                    MassiveTaskVar2();
                    ReturnsTaskMethod();
                    ReturnsTaskClass();
                    ContinuationTasks();
                    ContinuationTaskVol2();
                    ParalellClassOfTasVol1();
                    ParallelFor();
                    ParallelForEach();
                    ParallelExitingForOperatorBreack();
                    SoftOperationCanceledExceptionVol1();
                    SoftOperationCanceledExceptionVol2();
                    OperationCanceledExceptionVol3();
                    ParallelCAnselation();


                    Console.WriteLine(">>The end Main Tread<<");
                    Console.ReadKey();
                }
            }
        }

        public static void Razdelitel() => Console.WriteLine("----------------------------");
        public static void BasePrincipsTasks()
        {
            Task task = new Task(() => Console.WriteLine("Hello Task"));
            task.Start();

            Task task1 = Task.Factory.StartNew(() => Console.WriteLine
            ("Hello Task1"));

            Task task3 = Task.Run(() => Console.WriteLine("Hello Task3"));

            task.Wait();
            task1.Wait();
            task3.Wait();

            Razdelitel();
        }
        public static void WaitMethodTaskPrincipis()
        {
            Console.WriteLine("Started Main procces");

            Task myTask = new Task(() =>
            {
                Console.WriteLine("My Task is started");
                Thread.Sleep(1000);
                Console.WriteLine("MyTask Ends");
            });

            myTask.Start();
            myTask.Wait();

            Console.WriteLine("Main Task Ends");
            //myTask.Wait();


            Razdelitel();
        }
        public static void SynhroStartedTasks()
        {

            Task newTask = new Task(() =>
            {
                Console.WriteLine($"---Task{Task.CurrentId} is Starts");
                Thread.Sleep(1000);
                Console.WriteLine($"---Task{Task.CurrentId} ends");
            });
            newTask.Start();
            //newTask.Wait();

            Console.WriteLine($"Ид Таска = {newTask.Id} или так = {Task.CurrentId}");
            Console.WriteLine($" есть ли ошибка?= {newTask.Exception}");
            Console.WriteLine($"статус задачи = {newTask.Status}");
            //newTask.Wait();
            Console.WriteLine($"завершена ли задача? = {newTask.IsCompleted}");
            //newTask.Wait();
            Console.WriteLine($"задача отменена? = {newTask.IsCanceled}");
            //newTask.Wait();
            Console.WriteLine($"задача завершилась с исключением? = {newTask.IsFaulted}");

            newTask.Wait();

            Razdelitel();

        }
        public static void NestedTask()
        {

            Task outer = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Outer Task Started");
                Task inner = Task.Factory.StartNew(() =>
                {
                    Console.WriteLine("Inner Task Started");
                    Thread.Sleep(1000);
                    Console.WriteLine("Inner Task Finished");
                }, TaskCreationOptions.AttachedToParent);//TaskCreationOptions.AttachedToParent для выполнения вложенной частив последовательность
            });

            outer.Wait();
            Console.WriteLine("Outer Tas Finished");

            Razdelitel();
        }
        public static void MassiveTaskVar1()
        {
            Task[] tasks =
            {
                new Task(()=> Console.WriteLine("First Task")),
                new Task(()=> Console.WriteLine("Second Task")),
                new Task(()=> Console.WriteLine("Thrid Task"))

            };

            foreach (var task in tasks)
            {
                task.Start();
            }
            Console.WriteLine("Main ended");

            Razdelitel();
        }
        public static void MassiveTaskVar2()
        {
            int j = 3;
            Task[] tasks = new Task[j];

            for (int i = 0; i < j; i++)
            {
                var id = i + 1;
                tasks[i] = new Task(() =>
                {
                    Thread.Sleep(10);
                    Console.WriteLine($"Task{id} is finished"); // разобпались)
                });
                tasks[i].Start();
            }

            Console.WriteLine("Main Ended");

            Task.WaitAll(tasks);

            Razdelitel();

        }
        public static void ReturnsTaskMethod()
        {
            int firstValue = 5;
            int secondValue = firstValue;

            Task<int> sumTask = new Task<int>(() => SumTaskforReturnsTask(firstValue, secondValue));
            sumTask.Start();

            int result = sumTask.Result;
            Console.WriteLine($"{firstValue}+{secondValue}={result}");


            Razdelitel();

        }
        public static int SumTaskforReturnsTask(int x, int y) => x + y;
        public static void ReturnsTaskClass()
        {
            PersonForReturnsTaskClass person = new PersonForReturnsTaskClass("Tolya", 25);
            Task<PersonForReturnsTaskClass> personTask = new Task<PersonForReturnsTaskClass>(() => person);
            personTask.Start();

            var personRetursResultTask = personTask.Result;
            Console.WriteLine($"name:{personRetursResultTask.Name} Age:{personRetursResultTask.Age}");

            Razdelitel();
        }
        public static void ContinuationTasks()
        {
            Task taskOne = new Task(() => Console.WriteLine($"Id задачи: { Task.CurrentId.Value }"));


            Task taskTwo = taskOne.ContinueWith(PrintForContinuatuonalTasks);
            //Task taskThree = taskTwo.ContinueWith(PrintForContinuatuonalTasks);

            taskOne.Start();

            taskTwo.Wait();
            //taskThree.Wait();

            Console.WriteLine($"Id taskOne = {taskOne.Id}\nId taskTwo = {taskTwo.Id}"); // почему то присвоились наоборот =0
            Console.WriteLine("End ContinuationTasks method");

            Razdelitel();
        }
        public static void PrintForContinuatuonalTasks(Task t)
        {
            Console.WriteLine($"Id задачи: {Task.CurrentId.Value}");
            Console.WriteLine($"Id предыдущей задачи: {t.Id}");
            Thread.Sleep(3000);

            Razdelitel();
        }
        public static void ContinuationTaskVol2()
        {
            Task taskOne = new Task(() => Console.WriteLine($"Task {Task.CurrentId} : taskOne<< Previos Task NoN is First!!!!"));
            Task taskTwo = taskOne.ContinueWith(t => Console.WriteLine($"Task {Task.CurrentId} : taskTwo<< Previos Task {t.Id}"));
            Task taskThree = taskTwo.ContinueWith(t => Console.WriteLine($"Task {Task.CurrentId} : taskThree<< Previos Task {t.Id}"));
            Task taskFour = taskThree.ContinueWith(t => Console.WriteLine($"Task {Task.CurrentId} : taskFour<< Previos Task {t.Id}"));

            taskOne.Start();

            taskFour.Wait();
            Console.WriteLine(">>Ending Task this.Method<<");

        }
        public static void ParalellClassOfTasVol1()
        {
            Parallel.Invoke(
                PrintForParallelVol1,
                () =>
                {
                    Console.WriteLine($"Running {Task.CurrentId}");
                    Thread.Sleep(1000);
                },
                () => MultipleForParallelVol1(5)
                );


            Razdelitel();
        }
        public static void PrintForParallelVol1()
        {
            Console.WriteLine($"Running {Task.CurrentId} method >>Print<<");
            Thread.Sleep(1000);
        }
        public static void MultipleForParallelVol1(int x)
        {
            Console.WriteLine($"Running {Task.CurrentId} Method{x} >>Multiple<<");
            Thread.Sleep(400);
            Console.WriteLine($"result{x}: {x * x} for {Task.CurrentId} in Method >>Multiple<<");
        }
        public static void ParallelFor()
        {
            // вызывается как цикл начиная с 1 до 4, в аргумент метода пердается текущий итератор
            // Parallel.For(1, 4, MultipleForParallelVol1);
            Parallel.For(1, 5, MultipleForParallelVol1); //!!! обязательно принимает метод c параметром - ами,<<<<<<

            Razdelitel();
        }
        public static void ParallelForEach()
        {
            // результатом вывода будет кол-во итераций = кол-ву елементов масива
            // каждый елемент масива попадает в аргумет метода или делената
            ParallelLoopResult loop = Parallel.ForEach<int>(new List<int>() { 1, 3, 5, 8 }, MultipleForParallelVol1);

            Razdelitel();
        }
        public static void ParallelExitingForOperatorBreack()
        {
            ParallelLoopResult result = Parallel.For(1, 10, ForParallelExitingg);

            if (!result.IsCompleted)
                Console.WriteLine($"\nexecution process completed " +
                    $",but was paused for >>№{result.LowestBreakIteration}<<" +
                    $" iterations of running the thread");

            Razdelitel();
        }
        public static void ForParallelExitingg(int x, ParallelLoopState pls)
        {
            if (x == 5) pls.Break();
            Console.WriteLine($">>Task{Task.CurrentId}<< Result { x * x } = { x } * { x }");
            Thread.Sleep(2000);
        }
        public static void SoftOperationCanceledExceptionVol1()
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            CancellationToken token = cts.Token;

            Task task = new Task(() =>
            {
                for (int i = 1; i < 10; i++)
                {
                    if (token.IsCancellationRequested)
                    {
                        Console.WriteLine("Operation was Canseled");
                        return;
                    }

                    Console.WriteLine($"Ineration number{i} >> {i} * {i} = {i * i}");
                    Thread.Sleep(200);
                }
            }, token);

            task.Start();

            Thread.Sleep(1500);// после задержки по времени отменяем выполнение задачи

            cts.Cancel();

            Thread.Sleep(1000);

            Console.WriteLine($"Task{task.Id} have a status \"{task.Status}\"");
            cts.Dispose();// освобождаем ресурсы

            Razdelitel();
        }
        public static void SoftOperationCanceledExceptionVol2()
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            CancellationToken token = cts.Token;

            Task myTask = new Task(() =>
            {
                int i = 1;
                var name = $"Task{i}";
                Thread.CurrentThread.Name = name;

                token.Register(() =>
                {
                    Console.WriteLine("Operation canceled");
                    i = 10;
                });

                for (; i < 10; i++)
                {
                    Console.WriteLine($"Ineration number{i} >> {i} * {i} = {i * i} >>Task{i}");
                    Thread.Sleep(250);
                }

            }, token);

            myTask.Start();

            Thread.Sleep(1650);
            cts.Cancel(); // после задержки по времени отменяем выполнение задачи

            Thread.Sleep(1000);

            Console.WriteLine($"Task status is = {myTask.Status}");
            cts.Dispose();

            Razdelitel();
        }
        public static void OperationCanceledExceptionVol3()
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            CancellationToken token = cts.Token;

            Task newTask = new Task(() => PrintForOperationsCancelVol3(token), token);
            try
            {
                newTask.Start();

                Thread.Sleep(1400);
                cts.Cancel();

                newTask.Wait();
            }
            catch (AggregateException ae)
            {
                foreach (Exception e in ae.InnerExceptions)
                {
                    if (e is TaskCanceledException)
                        Console.WriteLine("Операция прервана");
                    else
                        Console.WriteLine(e.Message);
                }
            }
            finally
            {
                cts.Dispose();
            }
            Console.WriteLine($"Task status = {newTask.Status}");

            Razdelitel();
        }
        public static void PrintForOperationsCancelVol3(CancellationToken t)
        {
            for (int i = 1; i < 11; i++)
            {
                if (t.IsCancellationRequested)
                {
                    t.ThrowIfCancellationRequested();
                }

                Console.WriteLine($"result multiplication {i} * {i} = {i}");
                Thread.Sleep(200);
            }
        }
        public static void ParallelCAnselation()
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            CancellationToken token = cts.Token;

            Task task = new Task(() =>
            {
                Thread.Sleep(300);
                Console.WriteLine("----------------->Cancelation is aviable");

                cts.Cancel();
            });
            task.Start();

            try
            {
                Parallel.For(1, 10, new ParallelOptions { CancellationToken = token }, MultipleForParallelVol1);
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("!!!Operation Canceled!!!");
            }
            finally
            {
                cts.Dispose();
            }


        }

        public class PersonForReturnsTaskClass
        {
            private int age;
            private string name;
            public int Age { get; }
            public string Name { get; }
            public PersonForReturnsTaskClass(string name, int age)
            {
                this.age = age;
                this.name = name;
            }
        }

    }
}
