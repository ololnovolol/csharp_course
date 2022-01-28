using System;

namespace Solution.Capture3
{
    public static class ConsoleWrapper
    {
        public static void Clean()
        {
            Console.WriteLine(">> Press any key to execute next part.");
            Console.ReadLine();
            Console.Clear();
        }

        public static void PrintTitle(string partNumber, string theme)
        {
            Console.WriteLine($">> [Part: {partNumber}] Theme: {theme}");
        }
    }
}
