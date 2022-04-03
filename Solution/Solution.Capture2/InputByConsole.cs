using System;
using System.Globalization;


namespace Solution.Capture2
{
    public static class InputByConsole
    {
        public static void Printer()
        {
            Console.Write("Input your Name : ");
            string name = Console.ReadLine();
            Console.Write("Input your Age : ");
            var age = Convert.ToInt32(Console.ReadLine());
            Console.Write("Input your Height : ");

            NumberFormatInfo nfi = new NumberFormatInfo()
            {
                NumberDecimalSeparator = ".",
            };

            double height = Convert.ToDouble(Console.ReadLine(), nfi);

            Console.WriteLine("First variant input");
            Console.WriteLine($"Имя: {name}  Возраст: {age}  Рост: {height}");
            Console.WriteLine("Second variant input");
            Console.WriteLine("Имя: {0}  Возраст: {2}  Рост: {1}", name, height, age);

            Cleaner.CCleaner();
        }

    }
}
