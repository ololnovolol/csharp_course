using System;

namespace Solution.Capture21_Unsafe_
{
    class Program
    {
        static void Main(string[] args)
        {
            UnsafeParameters();
            StructurePointers();
            MassivePointersVar1();
            MassivePointersVar2();
            MassivePointers();
            ClassPointersVar1();
            Test();
            Console.ReadKey();


        }
        public static void UnsafeParameters()
        {
            unsafe
            {
                Method1();
                Method2();
            }
            unsafe void Method1()
            {
                int* x; // регистрируем указатель на число (разыменовывание) 

                int y = 10;

                x = &y;  // получаем ссылку на ячейку в памяти

                ulong adressY = (ulong)x; // получаем адресс переменной у
                Console.WriteLine($"Адрес переменной y: {adressY}");
            }
            unsafe void Method2()
            {
                int* x; // регистрируем указатель на число (разыменовывание) 

                int y = 10;

                x = &y;  // получаем ссылку на ячейку в памяти

                int** z = &x; // создаем указатель на указатель

                **z = **z + 40;
                //z = z + 40; //   необьяснимая хрень почему не ругается компила на z и **z

                Console.WriteLine($"x = {*x}, y = {y}, z = {**z}");

            }
        }
        public static void StructurePointers()
        {
            unsafe 
            {
                Point point = new Point(0, 0);
                Console.WriteLine(point);

                Point* point2 = &point; // создаем разыменованный тип который указует на адресс в памяти

                point2->X = 30; //set
                Console.WriteLine(point2->X); //get

                
                (*point2).Y = 180; // разыменовать назад указатель!!!!!!!!!!!

                Console.WriteLine(point);
                

            }
        }

        public static void MassivePointersVar1()
        {
            unsafe
            {
                const int count = 7;
                int* masPoint = stackalloc int[count];

                for (int i = 0; i < count; i++)
                {
                    masPoint[i] = i * i;
                }

                for (int i = 0; i < count; i++)
                {
                    Console.Write(" " + masPoint[i]);
                }
                Console.WriteLine();

            }
        }
        public static void MassivePointersVar2()
        {
            unsafe
            {
                const int count = 7;
                int* masPoint = stackalloc int[count];

                int* p = masPoint;
                for (int i = 0; i < count; i++)
                {
                    *p = i * i;
                    p++;
                }

                for (int i = 0; i < count; i++)
                {
                    Console.Write(" " + masPoint[i]);
                }
                Console.WriteLine();

            }
        }
        public static void MassivePointers()
        {
            unsafe
            {
                const int count = 10;
                int* masPoint = stackalloc int[count];

                int* p = masPoint;

                *(p++) = 1; // присваиваем первой ячейке значение 1 и
                            // увеличиваем указатель на 1
                for (int i = 2; i <= count; i++, p++)
                {
                    // считаем факториал числа
                    *p = p[-1] * i;
                }

                for (int i = 0; i < count; i++)
                {
                    Console.Write(" " + masPoint[i]);
                }
                Console.WriteLine();

            }
        }

        public static void ClassPointersVar1()
        {
            unsafe
            {
                Person person = new Person();
                

                fixed (int* pX = &person.X, pY = &person.Y)
                {
                    *pX = 30;
                    *pY = 150;
                }
                Console.WriteLine(person); // x: 30  y: 150



            }
        }

        public static void Test()
        {
            unsafe
            {
                string line = "abcdefg";

                fixed (char* s = line)
                {
                    char f = *(s + 5);
                    char c = *(s + 2);

                    Console.WriteLine(f);
                    Console.WriteLine(c);
                }
                

            }

            unsafe
            {
                int[] mas = { 0, 1, 2, 3, 4, 5, 6 };

                fixed(int* p = mas)
                {
                    *(p + 2) = 100;
                }
                for (int i = 0; i < mas.Length; i++)
                {
                    Console.Write(" " + mas[i]);
                }

                Console.WriteLine();
            }
        }


        unsafe struct Point
        {
            public int X { get; set; }
            public int Y { get; set; }

            //public string IsNotForbidden = "666"; так нельзя
            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }
            public override string ToString()
            {
                return string.Format($"x = {X}, y = {Y}");
            }
        }

        unsafe class Person
        {
            public int X; // не работает с автосвойствами =(
            public int Y;

  
            public override string ToString()
            {
                return string.Format($"x = {X}, y = {Y}");
            }
        }
    }
}
