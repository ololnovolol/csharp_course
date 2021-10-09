using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Capture2
{
    public static class ConditionalConstructs
    {
        public static int taskOne(int a, int b)
        {
            int result = 0;
            
            Console.WriteLine("--------------------------------------------\nУпражнение 1\nНапишите консольную программу, в которой \nпрограмма сранивает два введенных числа и выводит на консоль результат сравнения (два числа равны,\nпервое число больше второго или первое число меньше второго)");
            Console.WriteLine($"int a = {a}; \nint b = {b};");
            if (a > b) 
            {
                Console.WriteLine("\tnumber a is more");
            }else if (b > a)
            {
                Console.WriteLine("\tnumber b is more");
            }
            else
            {
                Console.WriteLine("\tnumbers a and b are equal");
            }

            return result;
        }

        public static int taskTwo (int a)
        {
            int result = 0;
           Console.WriteLine("--------------------------------------------\nУпражнение 2\nНапишите консольную программу, в которой \nЕсли число одновременно больше 5 и меньше 10, то программа выводит (Число больше 5 и меньше 10). Иначе программа выводит сообщение (Неизвестное число)");
            Console.WriteLine($"int a = {a};");
            if (a < 10 && a > 5)
            {
                Console.WriteLine("\tNumber greater than 5 and less than 10");
            }
            else
            {
                Console.WriteLine("\tUnknown number");
            }

            return result;
        }

        public static int taskThree(int a)
        {
            int result = 0;
            Console.WriteLine("--------------------------------------------\nУпражнение 3\nНапишите консольную программу, в которой \nЕсли число либо равно 5, либо равно 10, то программа выводит (Число либо равно 5, либо равно 10). Иначе программа выводит сообщение (Неизвестное число).");
            Console.WriteLine($"int a = {a};");
            if (a == 10 || a == 5)
            {
                Console.WriteLine("\tThe number is either 5 or 10");
            }
            else
            {
                Console.WriteLine("\tUnknown number");
            }

            return result;
        }

        public static double  taskFour(double a)
        {
            double result = 0;
            Console.WriteLine("--------------------------------------------\nУпражнение 4\nНапишите консольную программу, в которую пользователь вводит сумму вклада.\nЕсли сумма вклада меньше 100, то начисляется 5%. \nЕсли сумма вклада от 100 до 200, то начисляется 7%. \nЕсли сумма вклада больше 200, то начисляется 10%.).");
            Console.WriteLine($"deposit = {a};");
            if (a < 100)
            {
                result = Convert.ToDouble((a * 5 / 100) + a);
            }
            else if(a >= 100 && a < 200)
            {
                result = Convert.ToDouble((a * 7/ 100) + a);

            }else if (a >= 200)
            {
                result = Convert.ToDouble((a * 10 / 100) + a);

            }
            Console.WriteLine("the amount of the deposit with accrued interest = "+ result);

            return result;
        }
        public static double taskFive(double a)
        {
            double result = 0;
            Console.WriteLine("--------------------------------------------\nУпражнение 5\nНапишите консольную программу, в которую пользователь вводит сумму вклада.\nЕсли сумма вклада меньше 100, то начисляется 5%. \nЕсли сумма вклада от 100 до 200, то начисляется 7%. \nЕсли сумма вклада больше 200, то начисляется 10%.)\nИзмените программу таким образом, чтобы к финальной сумме дочислялись бонусы. 15 едениц ");
            Console.WriteLine($"deposit = {a};");
            if (a < 100)
            {
                result = Convert.ToDouble((a * 5 / 100) + a) ;
                result += 15;
            }
            else if (a >= 100 && a < 200)
            {
                result = Convert.ToDouble((a * 7 / 100) + a);
                result += 15;
            }
            else if (a >= 200)
            {
                result = Convert.ToDouble((a * 10 / 100) + a);
                result += 15;
            }
            Console.WriteLine("the amount of the deposit with accrued interest = " + result);

            return result;
        }

        public static int taskSix(int a, int b)
        {
            Console.WriteLine("Упражнение 6");
            Console.WriteLine("Напишите консольную программу, которая выводит пользователю сообщение (Введите номер операции: )\n1.Сложение \n2.Вычитание \n3.Умножение\n4.Деление\nРядом с названием каждой операции указан ее номер, например, операция вычитания имеет номер 2. \nПусть пользователь вводит в программу номер операции, и в зависимости от номера операции программа выводит ему\nДля определения операции по введенному номеру используйте конструкцию switch...case.\nЕсли введенное пользователем число не соответствует никакой операции (например, число 120), \nто выведите пользователю сообщение о том, что операция неопределена.");
            Console.WriteLine("\nto select an action, select the corresponding number\n1 Addition \n2 Subtraction \n3 Multiplication \n4 Division");

            int x = Convert.ToInt32(Console.ReadLine());
            switch (x)
            {
                case 1:
                    Console.WriteLine("you have chosen the operation : - Addition(+)");
                    return a + b;
                    break;
                case 2:
                    Console.WriteLine("you have chosen the operation : - Subtraction(-)");
                    return a - b;
                    break;
                case 3:
                    Console.WriteLine("you have chosen the operation : - Multiplication(*)");
                    return a * b;
                    break;
                case 4:
                    Console.WriteLine("you have chosen the operation : - Division(/)");
                    return a / b;
                    break;
                default:
                    Console.WriteLine("operation undefined");
                    return 0;
                    break;

                    return 0;
            }




            Cleaner.CCleaner();

        }

       
    }
}
