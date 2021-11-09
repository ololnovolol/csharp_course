using System;

namespace Solution.Capture3.Intheritance
{
    class Children : Human
    {
        public bool _speack { get; } = false;
        protected int _age = 3;
        protected new const string HI_HELLO = "Hello";
        protected new readonly bool speack = true;

        public int age
        {
            get { return _age; }
            set { _age = value; }
        }
        protected string _name = "i don't know";

        public string name
        {
            get { return _name; }
            set { _name = value; }
        }

        public Children(int age, string name, bool colorOgTheSkinWhite = true) : base(colorOgTheSkinWhite)
        {
            this.name = (name != null) ? name : "i don't know";
            this.age = (age != 0) ? age : 3;


            if (age > 3)
            {
                _speack = true;
                Console.WriteLine($"I am Childrean can i speak {_speack}, my is name = {_name}, my race is {rase}");

            }
            else
            {
                Console.WriteLine($"I am Childrean can i speak {_speack}");
            }
        }
        public Children() { }
        public override void Display()
        {
            Console.WriteLine($"me rase = {rase}, my age = {age}, my name is {name}");
        }

    }
}
