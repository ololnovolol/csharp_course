using System;

namespace Solution.Capture2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Part1();

            Console.WriteLine("Solution 2 Complete =)");
            Console.ReadKey();
        }

        public static void Part1()
        {
            Console.WriteLine("part 1.1 - Data types:");
            DataTypes.boolPrintTypes();
            DataTypes.bytePrintTypes();
            DataTypes.charPrintTypes();
            DataTypes.decimalPrintTypes();
            DataTypes.doublePrintTypes();
            DataTypes.floatPrintTypes();
            DataTypes.intPrintTypes();
            DataTypes.longPrintTypes();
            DataTypes.objectPrintTypes();
            DataTypes.sbytePrintTypes();
            DataTypes.shortPrintTypes();
            DataTypes.stringPrintTypes();
            DataTypes.uIntPrintTypes();
            DataTypes.uLongPrintTypes();
            DataTypes.ushortPrintTypes();
            DataTypes.varPrintTypes();
            Part2();

        }
        public static void Part2()
        {
            Console.WriteLine("part 1.2 - InputByConsole:");
            InputByConsole.Printer();
            Part3();
        }
        public static void Part3()
        {
            Console.WriteLine("part 1.3 - InputByConsole:");
            Arifmetic.printAllArifmeticOperation();
            Part4();
        }
        public static void Part4()
        {
            Console.WriteLine("part 1.4 - BitOperations:");
            BitOperations.PrintBO();
            Part5();
        }
        public static void Part5()
        {
            Console.WriteLine("part 1.5 - Assignement Operations:");
            AssignmentOperations.PrintAO();
            Part6();
        }
        public static void Part6()
        {
            Console.WriteLine("part 1.6 - Basic data type conversions:");
            BasicDataTypeConversion.PrintBDTC();
            Part7();
        }
        public static void Part7()
        {
            Console.WriteLine("part 1.7 - Comparison Operations");
            ComparisonOperations.PrintComparisonOperations();
            Part8();
        }
        public static void Part8()
        {
            Console.WriteLine("part 1.8 - Conditional constructs");
            ConditionalConstructs.taskOne(2, 10);
            ConditionalConstructs.taskTwo(7);
            ConditionalConstructs.taskTwo(11);
            ConditionalConstructs.taskThree(5);
            ConditionalConstructs.taskThree(10);
            ConditionalConstructs.taskThree(12);

            ConditionalConstructs.taskFour(50);
            ConditionalConstructs.taskFour(150);
            ConditionalConstructs.taskFour(250);

            ConditionalConstructs.taskFive(50);
            ConditionalConstructs.taskFive(150);
            ConditionalConstructs.taskFive(250);
            Cleaner.CCleaner();
            //task six =)
            ConditionalConstructs.taskSix(10, 5);
            Cleaner.CCleaner();
            //task seven =)
            Console.WriteLine("result your choise = " + ConditionalConstructs.taskSix(10, 5));
            Cleaner.CCleaner();
            Part9();
        }
        public static void Part9()
        {
            Console.WriteLine("part 1.9 - Cicles");
            Cycles.taskOne(10000, 5);
            Cycles.taskTwo(10000, 5);
            Cycles.taskThree();
            Cycles.taskFour(7, 2);
            Cleaner.CCleaner();
            Part10();
        }
        public static void Part10()
        {
            Console.WriteLine("part 1.10 - Cicles");
            Massiv.PrintMass();
            Cleaner.CCleaner();
            Part11();
        }
        public static void Part11()
        {
            Console.WriteLine("part 1.11 - Sort Masive");
            SortMasive.SortM(3, 5, 49, 2, 1, 3, 22, 65, 894);
            Cleaner.CCleaner();
            Part12();
        }
        public static void Part12()
        {
            Console.WriteLine("part 1.12 - Methods");
            Methods.Met1();
            Console.WriteLine(Methods.Met2());
            Methods.Met4();
            Methods.Met5();
            Console.WriteLine(Methods.Met6());
            Cleaner.CCleaner();
            Part13();
        }
        public static void Part13()
        {
            Console.WriteLine("part 1.13 - Method parameters");
            Methods.Met3("string");
            Methods.Met3("string", "hello");
            Methods.Met4();
            Cleaner.CCleaner();
            Part14();
        }
        public static void Part14()
        {
            Console.WriteLine("part 1.14 - Method ref, out. in");
            int num = 1;
            int xref = 10;
            int xout = 100;
            Methods.Addition(ref xref, 10);
            Methods.IncrementVal(155);
            Methods.IncrementRef(ref xref);
            Methods.GetData(10, 15, out xref, out xout);
            Methods.GetDataOut(in num, 1515, out xref, out xout);
            Cleaner.CCleaner();
            Part15();
        }
        public static void Part15()
        {
            Console.WriteLine("part 1.15 - key word params");
            SortMasive.SortM(3, 5, 49, 2, 1, 3, 22, 65, 894);
            Cleaner.CCleaner();
            Part16();
        }
        public static void Part16()
        {
            Console.WriteLine("part 1.16 - Recursive functions");

            int[] masive = { 1, 2, 3, 4, 5 };
            Console.WriteLine(Factorial.Factor(5)); // как посчитать кол-во запусков рекурсии
            Factorial.PrintArray(masive);
            Cleaner.CCleaner();
            Part17();
        }
        public static void Part17()
        {
            Console.WriteLine("part 1.17 - Enum");
            Enum.MathOp(10, 5, Enum.Operation.Add);
            Enum.MathOp(11, 5, Enum.Operation.Multiply);
            Enum.MathOp(100, 5, Enum.Operation.Subtract);
            Enum.MathOp(500, 5, Enum.Operation.Divide);
            Cleaner.CCleaner();
            Part18();
        }
        public static void Part18()
        {
            Console.WriteLine("part 1.18 - Tuples");
            Console.WriteLine("Tuple result (Sum , count) = " + Tuples.T(1, 2, 3, 4, 5, 6, 7, 8, 9, 10));
            Cleaner.CCleaner();
        }

    }
}
