
namespace Solution.Capture3.Indexers
{
    class Word
    {
        //Класс Word представляет слово, где свойство Target хранит перевод слова.
        public string Source { get; }
        public string Target { get; set; }
        public Word(string source, string target)
        {
            Source = source;
            Target = target;
        }
    }
}
