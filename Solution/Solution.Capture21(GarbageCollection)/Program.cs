using System;

namespace Solution.Capture21_GarbageCollection_
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //WorkerPartOne();
            //UsingTest();
            //NestedUsing();
            //NestedUsing1();
            //Console.WriteLine();
            //NestedUsing2();
            


            Console.ReadKey();
        }
        // part one
        public static void WorkerPartOne()
        {
            //Test Destructor
            TestGCDestructor();
            GC.Collect();
            Console.Read();

            //Test Dispose
            TestGCDispose();

            //Test Combinate methods call GC or Dispose

        }
        public static void TestGCDestructor()
        {
            Person person1 = new Person("Semen");
         
        }
        public static void TestGCDispose()
        {
            PerDson p = null;
            try
            {
                p = new PerDson("Disposer");
            }
            finally
            {
                p?.Dispose();
            }
        }
        // part two
        public static void UsingTest()
        {
            using (PerDson perd = new PerDson("UsingTrain"))
            {
                // переменная tom доступна только в блоке using
                // некоторые действия с объектом Person
                Console.WriteLine($"Name: {perd.Name}");

            }
            Console.WriteLine("after using block");
            // or   UsingBlock();   // syntax sugar using block concat in block method
        }
        public static void UsingBlock()
        {
            using (PerDson perd = new PerDson("UsingTrain"))
            
                // переменная tom доступна только в блоке using
                // некоторые действия с объектом Person
                Console.WriteLine($"Name: {perd.Name}");

            
        }
        public static void NestedUsing()
        {
            using (PerDson pe = new PerDson("Fist Using Block"))
            {
                Console.WriteLine(pe.Name);
                using (PerDson perd = new PerDson("Second using block"))
                {
                    Console.WriteLine(perd.Name);
                }// вызов метода Dispose для объекта perd
            } // вызов метода Dispose для объекта pe
            Console.WriteLine("Method job is end");
        }
        public static void NestedUsing1()
        {
            using (PerDson pe = new PerDson("Fist Using Block"))

                Console.WriteLine(pe.Name);
            using (PerDson perd = new PerDson("Second using block"))
            {
                    Console.WriteLine(perd.Name);
                }// вызов метода Dispose для объекта perd
             // вызов метода Dispose для объекта pe
            Console.WriteLine("Method job is end");
        }
        public static void NestedUsing2()
        {
            using (PerDson pe = new PerDson("Fist Using Block"))

                Console.WriteLine(pe.Name);
            using (PerDson perd = new PerDson("Second using block"))
            
                Console.WriteLine(perd.Name);
            // вызов метода Dispose для объекта perd
            // вызов метода Dispose для объекта pe
            Console.WriteLine("Method job is end");
        }
        // part pointers




    }
}
