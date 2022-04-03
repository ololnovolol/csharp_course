using System;
namespace Solution.Capture3
{
    internal class AccessModifiers // default internal
    {
        public int publ = 99;
        private int priva { get; set; } = 99;   // from Constructor
        protected int protec { get; set; } = 99;  //yes
        internal int intern { get; set; } = 99;  //yes
        protected internal int protecIntern { get; set; } = 99;  //yes
        private protected int privaProtec { get; set; } = 99;  // from Constructor

        public AccessModifiers(int priva, int protec, int privaProtec)
        {
            Console.WriteLine("\nHello i am Class");
            this.priva = priva;
            this.protec = protec;
            this.privaProtec = privaProtec;
        }
        public class AccessModifiersSubClass // default private
        {
            public string publ { get; set; } = "Bye Bye";  //yes
            private string priva { get; set; } = "Bye Bye";  // from Constructor
            protected string protec { get; set; } = "Bye Bye"; //from Constructor
            internal string intern { get; set; } = "Bye Bye";  //yes
            protected internal string protecIntern { get; set; } = "Bye Bye";  //yes
            private protected string privaProtec { get; set; } = "Bye Bye";  // from Constructor

            public AccessModifiersSubClass(string priva, string protec, string privaProtec)
            {
                Console.WriteLine("\nHello i am Subclass");
                this.priva = priva;
                this.protec = protec;
                this.privaProtec = privaProtec;

            }
            public void SubClassPrinter()
            {
                Console.WriteLine($"string publ = {publ}\nstring priva = {priva}\nstring protec = {protec}\nstring intern = {intern}\nstring protecIntern = {protecIntern}\nstring privaProtec = {privaProtec}");
            }
        }

        public void Printer()
        {
            Console.WriteLine($"int publ = {publ}\nint priva = {priva}\nint protec = {protec}\nint intern = {intern}\nint protecIntern = {protecIntern}\nint privaProtec = {privaProtec}");
        }

    }
}
