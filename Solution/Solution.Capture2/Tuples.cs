using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Capture2
{
    public static class Tuples
    {
        public static (int sum,int count) T (params int[] mas)
        {
            var result = (sum:0, count:0) ;

            for (int i = 0; i < mas.Length; i++)
            {
                result.sum += mas[i];
                result.count++;
                    
            }


            return result;
        }
    }
}
