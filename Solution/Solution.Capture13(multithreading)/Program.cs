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
                    ThreadBase();
                    ThreadUseDelegate();
                    ThreadsDuplet();
                    ThreadDupletObj();
                    SynchronizationThreads.Synhro();
                    monitorMethod();
                    autoResetEventMethod();

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
        public static void monitorMethod()
        {
            Monitor monitor = new Monitor();
            monitor.StartThread();

        }
        public static void autoResetEventMethod()
        {
            AutoResetEventClass arc = new AutoResetEventClass();
            arc.Start();
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
        public class Monitor
        {
            int x = 0;
            object locker = new object();
            /*
            void Enter(object obj): получает в экслюзивное владение объект, передаваемый в качестве параметра.

            void Enter(object obj, bool acquiredLock): дополнительно принимает второй параметра - логическое значение,
            которое указывает, получено ли владение над объектом из первого параметра

            void Exit(object obj): освобождает ранее захваченный объект

            bool IsEntered(object obj): возвращает true, если монитор захватил объект obj

            void Pulse (object obj): уведомляет поток из очереди ожидания, что текущий поток освободил объект obj

            void PulseAll(object obj): уведомляет все потоки из очереди ожидания, что текущий поток освободил объект obj.
            После чего один из потоков из очереди ожидания захватывает объект obj.

            bool TryEnter (object obj): пытается захватить объект obj. Если владение над объектом успешно получено,
            то возвращается значение true

            bool Wait (object obj): освобождает блокировку объекта и переводит поток в очередь ожидания объекта.
            Следующий поток в очереди готовности объекта блокирует данный объект. А все потоки, которые вызвали метод Wait,
            остаются в очереди ожидания, пока не получат сигнала от метода Monitor.Pulse или Monitor.PulseAll, 
            посланного владельцем блокировки.           
            */

            public Monitor()
            {

            }

            public void StartThread()
            {
                for (int i = 1; i < 6; i++)
                {
                    Thread myThread = new Thread(printMonitor);
                    myThread.Name = String.Format($"Thread name is {i}");
                    myThread.Start();
                }
            }
            public void printMonitor()
            {
                Monitor monitor = new Monitor();
                bool asquiredLock = false;
                try
                {
                    System.Threading.Monitor.Enter(locker, ref asquiredLock);
                    x = 1;
                    for (int i = 1; i < 6; i++)
                    {
                        Console.WriteLine($"{Thread.CurrentThread.Name} : {x}");
                        x++;
                        Thread.Sleep(100);
                    }
                }
                finally
                {
                    if (asquiredLock) System.Threading.Monitor.Exit(locker);

                }

            }
        }
        public class AutoResetEventClass
        {
            static bool isResetHandler = true;
            int x = 1;
            object locker = new object();
            AutoResetEvent autoResetHandler = new AutoResetEvent(isResetHandler);

            public AutoResetEventClass()
            {
                isResetHandler = true;
            }
            public void Start()
            {
                for (int i = 1; i < 6; i++)
                {
                    Thread topThread = new Thread(Print);
                    topThread.Name = String.Format($"nameThread is : {i}");
                    topThread.Start();
                }
            }

            public void Print()
            {
                autoResetHandler.WaitOne();  //ожидание сигнального состояния тоесть останавливает все процессы кроме выполнения текущего блока кода до вызова Сет     
                x = 1;
                for (int i = 1; i < 6; i++)
                {
                    Console.WriteLine($"{Thread.CurrentThread.Name} : {x}");
                    x++;
                    Thread.Sleep(200);
                }
                autoResetHandler.Set(); //после обработки кода выше переводит в сигнальное состояние продолжают выполнятся остальные потоки

            }

        }

    }
}

