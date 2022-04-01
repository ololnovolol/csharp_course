using System;
using System.IO;
using System.Threading.Tasks;
using System.Threading;

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
                    //BasePrincipsTasks();
                    //WaitMethodTaskPrincipis();
                    //SynhroStartedTasks();
                    //NestedTask();
                    //MassiveTaskVar1();
                    //MassiveTaskVar2();
                    //ReturnsTaskMethod();
                    //ReturnsTaskClass();
                    //ContinuationTasks();
                    //ContinuationTaskVol2();
                    ParalellClassOfTask();



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

            foreach(var task in tasks)
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
                    Console.WriteLine($"Task{id} is finished"); // с именем не понял в чем прикол в консольном выводе
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
        public static void ParalellClassOfTask()
        {


            Razdelitel();
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
