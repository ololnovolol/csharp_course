using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Capture3
{
    internal class GenericAccount<T>
    {
        private string Name { set; get; }
        private byte Age { set; get; }
        private T ID { set; get; }

        public string name
        {
            get { return Name; }
            set { Name = value; }
        }
        public byte age
        {
            get => Age;
            set => Age = value;
        }
        public T Id
        {
            get { return ID; }
            set { ID = value; }
        }
        public GenericAccount(T Id, string name, byte age)
        {
            ID = Id;
            Name = name;
            Age = age;
        }
    }
}
