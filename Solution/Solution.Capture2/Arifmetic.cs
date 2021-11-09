using System;

namespace Solution.Capture2
{
    public static class Arifmetic
    {
        public static void printAllArifmeticOperation()
        {

            Console.Write("input number one : 76");
            int a = 76;
            Console.WriteLine();
            Console.Write("input number two : 25");
            int b = 25;
            Console.WriteLine() ;

            int sum = a + b;
            Console.WriteLine("sum result this numbers = " + sum);

            int minus  = a - b;
            Console.WriteLine("minus result this numbers = " + minus);

            int multiply = a * b;
            Console.WriteLine("multiply result this numbers = " + multiply);

            double divide = Convert.ToDouble(a / b);
            Console.WriteLine("divide result this numbers = " + divide);

            int reminderOfDivide = a % b;
            Console.WriteLine("reminderOfDivide result this numbers = " + reminderOfDivide);

            int increment = ++a;
            Console.WriteLine("increment result a number = " + increment);

            int decrement = --a;
            Console.WriteLine("decrement result a number = " + decrement);

            Cleaner.CCleaner();
        }
    }
}
