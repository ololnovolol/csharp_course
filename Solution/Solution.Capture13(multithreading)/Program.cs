using System;
using System.IO;
using System.Threading;

namespace Solution.Capture13_multithreading_
{

    internal class Program
    {
        public static void Main(string[] args)
        {
            using (StreamReader sm = new StreamReader("Text.txt"))
            {
                string line;
                while ((line = sm.ReadLine()) != null)
                {
                    //ThreadBase();
                    //ThreadUseDelegate();
                    //ThreadsDuplet();
                    //ThreadDupletObj();
                    SynchronizationThreads.Synhro();

                }
                Console.ReadKey();
            }
        }

        public static void ThreadBase()
        {
            //get the thread now
            Thread usingThread = Thread.CurrentThread;

            //get the thread name
            Console.WriteLine($"name thread = {usingThread.Name}");
            usingThread.Name = "Main method";
            Console.WriteLine($"new name thread = {usingThread.Name}");
            Thread.Sleep(500);

            Console.WriteLine($"\nв каком контексте выполняется ExecutionContext {usingThread.ExecutionContext}");
            Thread.Sleep(500);
            Console.WriteLine($"работает ли в данный момент IsAlive {usingThread.IsAlive}");
            Thread.Sleep(500);
            Console.WriteLine($"работает ли в фоновом IsBackground {usingThread.IsBackground}");
            Thread.Sleep(500);
            Console.WriteLine($"числовой индентификатор потока ManagedThreadId {usingThread.ManagedThreadId}");
            Thread.Sleep(500);
            Console.WriteLine($"приорите Priority {usingThread.Priority}");
            Thread.Sleep(500);
            Console.WriteLine($"состояние потока из списка перечислений ThreadState {usingThread.ThreadState}");
        }
        public static void ThreadUseDelegate()
        {
            Thread myThread1 = new Thread(Print);
            Thread myThread2 = new Thread(new ThreadStart(Print));
            myThread1.Name = "First";
            myThread2.Name = "Second";
            //myThread3.Name = "Second"; Error

            ;
            Thread myThread3 = new Thread(() => Console.WriteLine($"Hello Thread"));


            myThread1.Start();
            myThread2.Start();
            myThread3.Start();


        }
        public static void ThreadsDuplet()
        {
            string nameNewThread = "FirstThread";
            Speacker speack = new Speacker(nameNewThread);

            Thread newThread = new Thread(speack.SpeackMethod)
            {
                Name = nameNewThread
            };
            //newThread.Priority = ThreadPriority.Highest;
            newThread.Start();

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"TopThread = {i}");
                Thread.Sleep(300);
            }



        }
        public static void ThreadDupletObj()
        {

            Thread testTread1 = new Thread(new ParameterizedThreadStart(Printer));
            Thread testTread2 = new Thread(Printer);
            Thread testTread3 = new Thread(message => Console.WriteLine(message));

            testTread1.Start("First");
            testTread2.Start("Second");
            testTread3.Start("Third");


        }
        static void Print() => Console.WriteLine($"Hello Thread");
        static void Printer(object message) => Console.WriteLine(message);
        public static void Display()
        {

            lock (SynchronizationThreads.locker)
            {
                var x = 1;
                for (int i = 1; i < 6; i++)
                {
                    Console.WriteLine($"{Thread.CurrentThread.Name}: {x}st call");
                    x++;
                    Thread.Sleep(100);
                }
            }

        }
        class Speacker
        {
            string name;
            public Speacker(string name)
            {
                this.name = name;
            }

            public void SpeackMethod()
            {

                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine($"Name:{name} = {i}");
                    Thread.Sleep(400);
                }
            }
        }

        public static class SynchronizationThreads
        {
            public static object locker = new object();

            public static void Synhro()
            {

                for (int i = 1; i < 6; i++)
                {
                    Thread thread = new Thread(Display);
                    thread.Name = $"Thread number {i}";
                    thread.Start();
                }
            }


        }
    }
}

