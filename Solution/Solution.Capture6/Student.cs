using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Capture6
{
    class Student : IPrintableStudent, IPrintablePerson, IComparer<Student>
    {

        private int Age;

        public int ageS
        {
            get { return Age; }
            set { Age = value; }
        }
        private string Name;

        public string nameS
        {
            get { return Name; }
            set { Name = value; }
        }
        public int groupe { get; set; }

        public static Student SortByGroup { get; set; }
        public static Student SortByAge { get; set; }


        void IPrintablePerson.Print()
        {
            Console.WriteLine($"name = {Name}, age = {Age}, Groupe = {groupe}");
        }

        void IPrintableStudent.Print()
        {
            Console.WriteLine($"i am Student");
        }

        //public int CompareTo(Student s1, Student s2)
        //{
        //    if(s1.Name.Length > s2.Name.Length)
        //    {
        //        return 1;
        //    }else if(s1.Name.Length < s2.Name.Length)
        //    {
        //        return -1;
        //    }
        //    else
        //    {
        //        return 0;
        //    }
        //}

        public int Compare(Student s1, Student s2)
        {
            if (s1.Name.Length > s2.Name.Length)
            {
                return 1;
            }
            else if (s1.Name.Length < s2.Name.Length)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        public class StudentComparer : IComparer<Student>
        {
            public StudentComparer()
            {

            }

            public int Compare(Student s1, Student s2)
            {
                if (s1.ageS > s2.ageS)
                {
                    return 1;
                }
                else if (s1.ageS < s2.ageS)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}

