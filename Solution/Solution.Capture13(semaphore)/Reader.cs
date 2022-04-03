using System;
using System.Threading;

namespace Solution.Capture13_semaphore_
{
    public class Reader
    {
        int counter = 3;
        static Semaphore semaphore = new Semaphore(3, 3);
        Thread myThread;


        public Reader(int counterNameReader)
        {
            myThread = new Thread(Read);
            myThread.Name = string.Format($"Читатель{counterNameReader}");
            myThread.Start();

        }

        public void Read()
        {
            while (counter > 0)
            {
                semaphore.WaitOne();

                Console.WriteLine($"{Thread.CurrentThread.Name} зашел в библиотеку");

                Console.WriteLine($"{Thread.CurrentThread.Name} читает книгу");
                Thread.Yield();
                Thread.Sleep(1000);

                Console.WriteLine($"{Thread.CurrentThread.Name} вышел");

                semaphore.Release();

                counter--;
                Thread.Sleep(1000);
                Thread.Yield();
            }

        }
    }
}
