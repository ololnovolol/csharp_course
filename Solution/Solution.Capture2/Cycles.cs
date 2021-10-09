using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Capture2
{
    public static class Cycles
    {
        public static void taskOne(int a, int b)
        {
            /*За каждый месяц банк начисляет к сумме вклада 7% от суммы. Напишите консольную программу, 
                в которую пользователь вводит сумму вклада и количество месяцев.
                А банк вычисляет конечную сумму вклада с учетом начисления процентов за каждый месяц.
            Для вычисления суммы с учетом процентов используйте цикл for. 
                Для ввода суммы вклада используйте выражение 
                Convert.ToDecimal(Console.ReadLine())
                (сумма вклада будет представлять тип decimal).
            */
            decimal sum = Convert.ToDecimal(a);
            decimal mounts = Convert.ToDecimal(b);
            decimal result = 0;

            Console.WriteLine("your sum of depisit = " + sum+ "grn");
            Console.WriteLine("your time for depisit = " + mounts+" mounts");
            for (int i = 0; i < mounts; i++)
            {
                result = (a*7/100) + a;               
            }
            Console.WriteLine("\tyour deposit amount in a year  = " + result);


        }
        public static void taskTwo(int a, int b)
        {
            //Перепишите предыдущую программу, только вместо цикла for используйте цикл while.
            decimal sum = Convert.ToDecimal(a);
            decimal mounts = Convert.ToDecimal(b);
            decimal result = 0;
            int i = 0;

            Console.WriteLine("your sum of depisit = " + sum + "grn");
            Console.WriteLine("your time for depisit = " + mounts + " mounts");
            while (i < mounts)
            {
                result = (a * 7 / 100) + a;
                i++;
            }
            Console.WriteLine("\tyour deposit amount in a year  = " + result);
        }
        public static void taskThree()
        {
            //Напишите программу, которая выводит на консоль таблицу умножения`
            for(int i = 1; i < 10 ; i++)
            {
                Console.WriteLine($"multiply table for {i}");
                for (int j = 1; j < 10; j++)
                {
                    Console.Write($"{i} * {j} = {i*j}\n" );
                }              
            }
        }
        public static void taskFour(int a, int b)
        {
            /*
             * Напишите программу, в которую пользователь вводит два числа и выводит результат их умножения. 
             * При этом программа должны запрашивать у пользователя ввод чисел, 
             * пока оба вводимых числа не окажутся в диапазоне от 0 до 10. 
             * Если введенные числа окажутся больше 10 или меньше 0, то программа должна вывести пользователю о том, 
             * что введенные числа недопустимы, и повторно запросить у пользователя ввод двух чисел. 
             * Если введенные числа принадлежат диапазону от 0 до 10, то программа выводит результат умножения
             * Для организации ввода чисел используйте бесконечный цикл while и оператор break.
             */
            int result = 0;
            for (int i = 0; i < 100; i++)
            {
                if(a>=0 && a<10 | b >= 0 && b < 10)
                {
                    result = a * b;
                    Console.WriteLine("result for miltiply = "+ result);
                    break;
                }
                else if (a<0 && a>10)
                {
                    Console.WriteLine("First number dont are in the range 0 to 10 ");
                    i--;
                }
                else if (b < 0 && b > 10)
                {
                    Console.WriteLine("Second number dont are in the range 0 to 10");
                    i--;
                }


            }
            
        }
    }
}
