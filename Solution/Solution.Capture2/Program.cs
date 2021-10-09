using System;

namespace Solution.Capture2
{
    class Program
    {

        static void Main(string[] args)
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

             Console.WriteLine("part 1.2 - InputByConsole:");
             InputByConsole.Printer();

             Console.WriteLine("part 1.3 - InputByConsole:");
             Arifmetic.printAllArifmeticOperation();

             Console.WriteLine("part 1.4 - BitOperations:");
             BitOperations.PrintBO();

             Console.WriteLine("part 1.5 - Assignement Operations:");
             AssignmentOperations.PrintAO();

             Console.WriteLine("part 1.6 - Basic data type conversions:");
             BasicDataTypeConversion.PrintBDTC();
             
             Console.WriteLine("part 1.7 - Comparison Operations");
             ComparisonOperations.PrintComparisonOperations();
             

            Console.WriteLine("part 1.8 - Conditional constructs");
            ConditionalConstructs.taskOne(2,10);
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
            Console.WriteLine("result your choise = " + ConditionalConstructs.taskSix(10,5));
            Cleaner.CCleaner();

            Console.WriteLine("part 1.9 - Cicles");
            Cycles.taskOne(10000,5);
            Cycles.taskTwo(10000,5);         
            Cycles.taskThree();
            Cycles.taskFour(7, 2);
            Cleaner.CCleaner();

            Console.WriteLine("part 1.10 - Cicles");
            Massiv.PrintMass();
            Cleaner.CCleaner();

            Console.WriteLine("part 1.11 - Sort Masive");
            SortMasive.SortM(3, 5, 49, 2, 1, 3, 22, 65, 894);
            Cleaner.CCleaner();

            Console.WriteLine("part 1.12 - Methods");
            Methods.Met1();
            Console.WriteLine(Methods.Met2());
            Methods.Met4();
            Methods.Met5();
            Console.WriteLine(Methods.Met6());
            Cleaner.CCleaner();

            Console.WriteLine("part 1.13 - Method parameters");
            Methods.Met3("string");
            Methods.Met3("string","hello");
            Methods.Met4();
            Cleaner.CCleaner();

            Console.WriteLine("part 1.14 - Method ref, out. in");
            int num = 1;
            int xref = 10;
            int xout=100;
            Methods.Addition(ref xref ,10);
            Methods.IncrementVal(155);
            Methods.IncrementRef(ref xref);
            Methods.GetData(10,15,out xref,out xout);
            Methods.GetDataOut(in num,1515 ,out xref, out xout) ;
            Cleaner.CCleaner();

            Console.WriteLine("part 1.15 - key word params");
            SortMasive.SortM(3, 5, 49, 2, 1, 3, 22, 65, 894);
            Cleaner.CCleaner();

            Console.WriteLine("part 1.16 - Recursive functions");
            int count = 0;
            Console.WriteLine(Factorial.Factor(5)); // как посчитать кол-во запусков рекурсии
            Cleaner.CCleaner();

            Console.WriteLine("part 1.17 - Enum");  
            Enum.MathOp(10, 5, Enum.Operation.Add);
            Enum.MathOp(11, 5, Enum.Operation.Multiply);
            Enum.MathOp(100, 5, Enum.Operation.Subtract);
            Enum.MathOp(500, 5, Enum.Operation.Divide);
            Cleaner.CCleaner();

            Console.WriteLine("part 1.18 - Tuples");
            Console.WriteLine("Tuple result (Sum , count) = "+Tuples.T(1,2,3,4,5,6,7,8,9,10));
            Cleaner.CCleaner();


            Console.WriteLine("Solution 2 Complete =)");
            Console.ReadKey();




        }

    }
}
