using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Capture3
{
    class OverloadingTypeConversionOperations
    {
        internal class Clock
        {
            public int Hours { get; set; }

            public void PrinOClock()

            {
                Console.WriteLine("on the clock " + Hours + " o`clock");
            }

            public static implicit operator Clock(int x)
            {
                return new Clock { Hours = x % 24 };
            }

            public static explicit operator int (Clock clock)
            {
                return clock.Hours;
            }


        }



        internal class Celcius
        {
            public double Gradus { get; set; }
            static readonly double CelToFarengheit = 9.00 / 5.00;

            public static implicit operator Fahrenheit(Celcius celcius)
            {
                double f = (32 + (celcius.Gradus * CelToFarengheit));
                return new Fahrenheit { Gradus = f };

            }

        }


        internal class Fahrenheit
        {
            static readonly double FarToCelsium = 5.00 / 9.00;
            public double Gradus { get; set; }


            public static implicit operator Celcius(Fahrenheit fahrenheit)
            {
                double c = (FarToCelsium * (fahrenheit.Gradus - 32));
                return new Celcius { Gradus = c };

            }

        }



        internal class Dollar
        {
            public decimal Sum { get; set; }

            //public static explicit operator Dollar(Euro v)
            //{
            //    return new Dollar { Sum = Euro.DollarToEuro * v.Sum};
            //}

            public static explicit operator Dollar(decimal v)
            {
                return new Dollar { Sum = v * Euro.DollarToEuro };
            }

            //public static explicit operator Euro(Dollar v)
            //{
            //    throw new NotImplementedException();
            //}
        }


        internal class Euro
        {
            public decimal Sum { get; set; }
            public readonly static decimal DollarToEuro = 1.14m;

            public static implicit operator Euro(Dollar v)
            {
                return new Euro { Sum = v.Sum / DollarToEuro};
            }

            //public static explicit operator Dollar(Euro v)
            //{
            //    throw new NotImplementedException();
            //}
        }


    }

}
