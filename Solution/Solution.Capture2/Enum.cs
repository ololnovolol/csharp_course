using System;

namespace Solution.Capture2
{
    public static class Enum
    {
        public enum Operation
        {
            Add = 1,
            Subtract,
            Multiply,
            Divide
        }

        public static void MathOp(double x, double y, Operation op)
        {
            double result = 0.0;

            switch (op)
            {
                case Operation.Add:
                    result = x + y;
                    break;
                case Operation.Subtract:
                    result = x - y;
                    break;
                case Operation.Multiply:
                    result = x * y;
                    break;
                case Operation.Divide:
                    result = x / y;
                    break;
            }
            Console.WriteLine($"first number = {x}\nsecond number {y}\ndo {op}");
            Console.WriteLine($"\tThe result of the operation is {result}");
        }
    }
}
