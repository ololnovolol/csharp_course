using System;

namespace Solution.Capture3
{
    class ValueTypesAndReferenceTypes
    {
        public string name = "null";
        public uint age = 0;

        private string usName = "Unnamed";
        private uint usAge = 0;
        //private char usBlood = '-';

        public void ClearWithBase(ref string name, out uint age, in char blood)
        {
            name = usName;
            age = usAge;
            //blood = usBlood;
            Console.WriteLine("\nerror!!!\tValueTypes <<in>> - readonly\n\t\t parametr groupBlood don`t cleared!!!\n ");
        }

        public static void AddOrDeleteToArray(ref int[] array, int item, int index)
        {

            int newLeungth = array.Length + 1;
            int[] massive = new int[newLeungth];
            massive[index] = item;

            for (int i = 0, j = 0; j < massive.Length; j++)
            {
                if (j != index) { massive[j] = array[i]; i++; }
                else { i = index; }

            }
            array = new int[newLeungth];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = massive[i];
            }
        }
        public static void AddFirst(ref int[] array, int item)
        {
            AddOrDeleteToArray(ref array, item, 0);
        }
        public static void AddLast(ref int[] array, int item)
        {
            AddOrDeleteToArray(ref array, item, array.Length);
        }

    }
}
