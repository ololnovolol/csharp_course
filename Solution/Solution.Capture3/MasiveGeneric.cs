using System;

namespace Solution.Capture3
{
    class MasiveGeneric<F>
    {
        F[] arar;
        public MasiveGeneric()
        {
            arar = new F[0];
        }

        public void PrintMasive()
        {
            Console.Write("|");
            for (int i = 0; i < arar.Length; i++)
            {
                Console.Write(" " + arar[i] + " |");
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
            F[] ararNext = new F[arar.Length - 1];
            for (int i = 0, j = 0; i < ararNext.Length; i++)
            {
                if (index == j)
                {
                    j++;
                    i--;
                }
                else
                {
                    ararNext[i] = arar[j];
                    j++;
                }

            }
            arar = ararNext;
        }

        public int GetGenMasiveLeunght()
        {
            return arar.Length;
        }

        public F GetGenMasive(int index)
        {
            if (index > -1 && index < arar.Length)
            {
                return arar[index];
            }
            else
                throw new IndexOutOfRangeException();
        }
    }
}
