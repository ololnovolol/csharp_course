using System;


namespace Solutin.Capture12
{

    internal class Reader
    {
        //Library library = new Library();
        Lazy<Library> library = new Lazy<Library>();
        public void ReadBook()
        {
            //library.GetBook();
            library.Value.GetBook();
            Console.WriteLine("Читаем бумажную книгу");
        }

        public void ReadEbook()
        {
            Console.WriteLine("Читаем книгу на компьютере");
        }
    }

    internal class Library
    {
        private string[] books = new string[99];

        public void GetBook()
        {
            Console.WriteLine("Выдаем книгу читателю");
        }
    }
}
