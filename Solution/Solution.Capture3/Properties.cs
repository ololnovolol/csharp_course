using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Capture3
{
    public class Properties
    {

        private int propertyAgeblock;
        public int propertyAge { get; set; }




        public Properties(int num, int num2)
        {
            propertyAgeblock = num;
            propertyAge = num2;
            Console.WriteLine("propertyAgeblock = " + propertyAgeblock);
            Console.WriteLine("propertyAge = " + propertyAge);
        }


    }
}
