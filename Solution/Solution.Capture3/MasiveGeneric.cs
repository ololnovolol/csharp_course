using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Capture3
{
    class MasiveGeneric<F>
    {
        F[] arar;
        public MasiveGeneric()
        {
            arar = new F[1];
        }

        public void PrintMasive()
        {
            Console.Write("|");
            for (int i = 0; i < arar.Length;i++)
            {
                Console.Write(" "+arar[i]+" |");
            }
            Console.WriteLine();
        }

        public void AddGenMasive(F value)
        {
            F[] ararNext = new F[arar.Length + 1];

            for (int i = 0; i < arar.Length; i++)
            {
                ararNext[i] = arar[i];
            }
            ararNext[arar.Length] = value;
            arar = ararNext;
        }


        public void RemoveGenMasiveforIndex(int index)
        {

            if (index > -1 && index < arar.Length)
            {
                arar[index] = default;
            }
            else
                throw new IndexOutOfRangeException();
        }


        public int GetGenMasiveLeunght()
        {
            return arar.Length;
        }

        public F GetGenMasive(int index)
        {
            return arar[index];
        }
    }
}
