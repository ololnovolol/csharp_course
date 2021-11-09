using System;

namespace Solution.Capture2
{
    public static class DataTypes
    {
        public static void boolPrintTypes()
        {
            bool alive = true;
            bool isDead = false;
            Console.WriteLine("");
            Console.WriteLine($"First variant Type bool : {alive}");
            Console.WriteLine($"Second variant Type bool : {isDead}");
        }

        public static void bytePrintTypes()
        {
            byte bit1 = 0;
            byte bit2 = 255;
            Console.WriteLine("");
            Console.WriteLine($"Min variant Type byte : {bit1}");
            Console.WriteLine($"Max variant Type byte : {bit2}");
        }

        public static void sbytePrintTypes()
        {
            sbyte bit1 = -128;
            sbyte bit2 = 127;
            Console.WriteLine("");
            Console.WriteLine($"Min variant Type sbyte : {bit1}");
            Console.WriteLine($"Max variant Type sbyte : {bit2}");
        }

        public static void shortPrintTypes()
        {
            short n1 = -32768;
            short n2 = 32767;
            Console.WriteLine("");
            Console.WriteLine($"Min variant Type short : {n1}");
            Console.WriteLine($"Max variant Type short : {n2}");
        }

        public static void ushortPrintTypes()
        {
            ushort n1 = 0;
            ushort n2 = 65535;
            Console.WriteLine("");
            Console.WriteLine($"Min variant Type ushort : {n1}");
            Console.WriteLine($"Max variant Type ushort : {n2}");
        }


        public static void intPrintTypes()
        {
            int a = -2147483648;
            int b = 2147483647;
            Console.WriteLine("");
            Console.WriteLine($"Min variant Type int : {a}");
            Console.WriteLine($"Max variant Type int : {b}");
        }

        public static void uIntPrintTypes()
        {
            uint a = 0;
            uint b = 4294967295;
            Console.WriteLine("");
            Console.WriteLine($"Min variant Type uInt : {a}");
            Console.WriteLine($"Max variant Type uInt : {b}");
        }

        public static void longPrintTypes()
        {
            long a = -9223372036854775808L;
            long b = 9223372036854775807L;
            Console.WriteLine("");
            Console.WriteLine($"Min variant Type long : {a}");
            Console.WriteLine($"Max variant Type long : {b}");
        }

        public static void uLongPrintTypes()
        {
            ulong a = 0U;
            ulong b = 1844744073709551615U;
            Console.WriteLine("");
            Console.WriteLine($"Min variant Type ulong : {a}");
            Console.WriteLine($"Max variant Type ulong : {b}");
        }

        public static void floatPrintTypes()
        {
            float a = -340282356779733642999999999999999999999f;
            float b = 340282356779733642999999999999999999999f;
            Console.WriteLine("");
            Console.WriteLine($"Min variant Type float : {a}");
            Console.WriteLine($"Max variant Type float : {b}");
        }

        public static void doublePrintTypes()
        {
            double a = 0.453543435453453434453245345343453453453453453453453453;
            double b = 99999999999999999999999999999999999999.745343434534345353;
            Console.WriteLine("");
            Console.WriteLine($"Forst variant Type double : {a}");
            Console.WriteLine($"Second variant Type double : {b}");
        }

        public static void decimalPrintTypes()
        {
            decimal a = 0.5m;
            decimal b = 94532.4563456456m;
            Console.WriteLine("");
            Console.WriteLine($"Min variant Type decimal : {a}");
            Console.WriteLine($"Max variant Type decimal : {b}");
        }

        public static void charPrintTypes()
        {
            char a = '0';

            Console.WriteLine("");
            Console.WriteLine($"variant Type char : {a}");

        }

        public static void stringPrintTypes()
        {
            string str1 = "hello";
            string str2 = "124212424";
            Console.WriteLine("");
            Console.WriteLine($"Type string : {str1}");
            Console.WriteLine($"Max variant Type string : {str2}");
        }

        public static void objectPrintTypes()
        {
            object a = 22;
            object b = 3.14;
            object c = "hello code";
            Console.WriteLine("");
            Console.WriteLine($"First variant Type object : {a}");
            Console.WriteLine($"Second variant Type object : {b}");
            Console.WriteLine($"Third variant Type object : {c}");
        }

        public static void varPrintTypes()
        {
            var hello = "Hell to World";
            var c = 20;

            Console.WriteLine("");
            Console.WriteLine($"First variant Type object : {hello} this type var saved string");
            Console.WriteLine($"Third variant Type object : {c} this type var saved int");

            Cleaner.CCleaner();
        }
    }


}
