using System;

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
