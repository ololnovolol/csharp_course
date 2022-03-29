using System;

namespace Solutin.Capture12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //LazyIni();
            MathClass();
            ConvertTypes();


            Console.ReadKey();
        }

        public static void LazyIni()
        {
            Reader reader = new Reader();
            reader.ReadBook();
            reader.ReadEbook();
        }

        public static void MathClass()
        {
            int firstValue = 15;
            int secondValue = 25;;
            Console.WriteLine(Math.Abs(-12.5));
            double result1 = Math.Round(20.56); // 21
            double result2 = Math.Round(20.46); //20
            double result = Math.Truncate(16.89); // 16



        }

        public static void ConvertTypes()
        {

        }
    }
}
