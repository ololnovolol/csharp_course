using System;
using System.Data;

namespace Solution.Capture11
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTimeMethod();
            FormatData();
            DateOnly();
            TimeOnly();
        }

        public static void DateTimeMethod()
        {
            DateTime dt = new DateTime();
            Console.WriteLine(dt); // Console.WriteLine(DateTime.MinValue);

            DateTime date1 = new DateTime(2015, 7, 20, 18, 30, 25); // год - месяц - день - час - минута - секунда
            Console.WriteLine(date1); // 20.07.2015 18:30:25

            Console.WriteLine(dt = DateTime.Now);
            Console.WriteLine(DateTime.UtcNow);
            date1 = DateTime.Now;
            dt = DateTime.Now;
            Console.WriteLine(dt.AddMinutes(5));
            DateTime date22 = new DateTime(2015, 7, 20, 18, 30, 25); // 20.07.2015 18:30:25
            DateTime date2 = new DateTime(2015, 7, 20, 15, 30, 25); // 20.07.2015 15:30:25
            Console.WriteLine(date22.Subtract(date2));
        }
        public static void FormatData()
        {
            DateTime now = DateTime.Now;

            Console.WriteLine($"D: {now.ToString("D")}");
            Console.WriteLine($"d: {now.ToString("d")}");
            Console.WriteLine($"F: {now.ToString("F")}");
            Console.WriteLine($"f: {now:f}");
            Console.WriteLine($"G: {now:G}");
            Console.WriteLine($"g: {now:g}");
            Console.WriteLine($"M: {now:M}");
            Console.WriteLine($"O: {now:O}");
            Console.WriteLine($"o: {now:o}");
            Console.WriteLine($"R: {now:R}");
            Console.WriteLine($"s: {now:s}");
            Console.WriteLine($"T: {now:T}");
            Console.WriteLine($"t: {now:t}");
            Console.WriteLine($"U: {now:U}");
            Console.WriteLine($"u: {now:u}");
            Console.WriteLine($"Y: {now:Y}");

            DateTime mynow = DateTime.Now;
            Console.WriteLine(mynow.ToString("hh:mm:ss"));
            Console.WriteLine(mynow.ToString("dd.MM.yyyy"));

            TimeOnly time = new TimeOnly(14, 23, 30);
            Console.WriteLine(time.Hour);       // 14
            Console.WriteLine(time.Minute);     // 23
            Console.WriteLine(time.Second);     // 30
        }
        public static void DateOnly()
        {
            //DateOnly now = new DateOnly(2022, 1, 6);
            //Console.WriteLine(now.Day);         // 6
            //Console.WriteLine(now.DayNumber);   // 738160
            //Console.WriteLine(now.DayOfWeek);   // Thursday
            //Console.WriteLine(now.DayOfYear);   // 6
            //Console.WriteLine(now.Month);       // 1
            //Console.WriteLine(now.Year);        // 2022

            //DateOnly now1 = DateOnly.Parse("06.01.2022");    // на русскоязычной локализованной ОС
            //Console.WriteLine(now1); // 06.01.2022
            //now = now1.AddDays(1);   // 07.01.2022
            //now = now1.AddMonths(4); // 07.05.2022
            //now = now1.AddYears(-1); // 07.05.2021
            //Console.WriteLine(now1.ToShortDateString());  // 07.05.2021
            //Console.WriteLine(now1.ToLongDateString());   // 7 мая 2021 г.
        }
        public static void TimeOnly()
        {
            //TimeOnly time = TimeOnly.Parse("06:33:22");
            //Console.WriteLine(time);        // 6:33
            //time = time.AddHours(1);        // 7:33
            //time = time.AddMinutes(-23);   // 7:10

            //Console.WriteLine(time.ToShortTimeString());  // 7:10
            //Console.WriteLine(time.ToLongTimeString());   // 7:10:22
        }
    }

}
