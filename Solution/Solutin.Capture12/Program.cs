using System;

namespace Solutin.Capture12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LazyIni();
            MathClass();


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

        }


    }
}
