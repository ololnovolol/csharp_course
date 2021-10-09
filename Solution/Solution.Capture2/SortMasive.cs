using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Capture2
{
    public static class SortMasive
    {
        public static void SortM(params int[] mas)
        {
            //int[] mas = a;
            int temp;
            for (int i = 0; i <= mas.Length - 1; i++)
            {
                for (int j = i + 1; j < mas.Length; j++)
                {
                    if (mas[i] > mas[j])
                    {
                        temp = mas[i];
                        mas[i] = mas[j];
                        mas[j] = temp;
                    }
                }
            }

            Console.WriteLine("Sorted array output");
            for (int i = 0; i < mas.Length; i++)
            {
                Console.Write($"{mas[i]} ");
            }

        }
    }
}

