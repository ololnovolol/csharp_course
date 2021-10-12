using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Capture3.Indexers
{
    class Dictionary
    {
        //А класс Dictionary представляет словарь слов и хранит все слова в приватном массиве
        //Добавьте в класс Dictionary индексатор таким образом, чтобы с помощью индексатора можно было по слову получить или изменить его перевод.

        Word[] words;
        public Dictionary()
        {
            words = new Word[]
            {
            new Word("red", "красный"),
            new Word("blue", "синий"),
            new Word("green", "зеленый")
            };
        }

        public Word this[string sourse]
        {
            get
            {
                switch (sourse)
                {
                    case "red": return words[0];
                    case "blue": return words[1];
                    case "green": return words[2];
                    default: return null;
                }  
            }
            set
            {
                switch (sourse)
                {
                    case "red":
                        words[0] = value;
                        break;
                    case "blue":
                        words[1] = value;
                        break;
                    case "green":
                        words[2] = value;
                        break;
                }
            }
        }    



    
    }
}

