using System;

namespace Solution.Capture3.Intheritance
{
    class Human : Monkey
    {

        private new string _race = "not undefined";
        protected new const string HI_HELLO = "agu";
        protected new readonly bool speack = false;

        public string rase
        {
            get { return _race; }
            set { _race = value; }
        }


        public Human(bool colorOgTheSkinWhite)
        {
            _race = (colorOgTheSkinWhite) ? "White" : "Black";
            Console.WriteLine($"Hello i am new Human and i have race = {_race}");
        }
        public Human()
        {
            new Human(true);
        }

        protected override void Cry()
        {
            Console.WriteLine("yeee");
        }

        public override void Display()
        {
            Console.WriteLine($"my race = {_race}");
        }

    }
}
