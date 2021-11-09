using System;

namespace Solution.Capture3
{
    class MethodOverloading
    {
        public void Add(int a, int b)
        {
            int result = a + b;
            Console.WriteLine($"Overloading the result method. Add with two parameters is {result}");
        }
        public void Add(int a, int b, int c)
        {
            int result = a + b + c;
            Console.WriteLine($"Overloading the result method. Add with three parameters is {result}");
        }
        public int Add(int a, int b, int c, int d)
        {
            int result = a + b + c + d;
            Console.WriteLine($"Overloading the result method. Add with four parameters is {result}");
            return result;
        }
        public void Add(double a, double b)
        {
            double result = a + b;
            Console.WriteLine($"Overloading the result method. Add with two double  parameters is {result}");
        }
    }
}
