using System;
using Solution.Algorithms_FundamentalOfAlgoAndDataStructures_.Queue;
using Solution.Algorithms_FundamentalOfAlgoAndDataStructures_.StackLink;
using Solution.Algorithms_FundamentalOfAlgoAndDataStructures_.LinkedList;
using Solution.Algorithms_FundamentalOfAlgoAndDataStructures_.DualLinkedList;

namespace Solution.Algorithms_FundamentalOfAlgoAndDataStructures_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ExpectedMyLinkedList();
            //ExpectedMyDualLinkedList();
            //ExpectedMyStackLink();
            ExpectedQueue();



            Console.ReadKey();
        }

        static void ConstantaTyprOfAlgoritm()
        {
            int x = 10;
            if (x > 0)
            {
                x--;
            }
            else
            {
                x++;
            }
        }
        static int LogarifmTyprOfAlgoritm(int key, int[] numbers)
        {
            int low = 0;
            int high = numbers.Length - 1;
            while (low <= high)
            {
                // находим середину
                int mid = low + (high - low) / 2;
                // если ключ поиска меньше значения в середине
                // то верхней границей будет элемент до середины
                if (key < numbers[mid]) high = mid - 1;
                else if (key > numbers[mid]) low = mid + 1;
                else return mid;
            }
            return -1;

        }
        static int LineTyprOfAlgoritm(int n)
        {
            int result = 1;
            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }
            return result;

        }
        static void LineLogarifmTyprOfAlgoritm()
        {
            //Примером подобного алгоритма может служить сортировка
            //слиянием (merge sort)

        }
        static void QuadraticTyprOfAlgoritm(int[] nums)
        {
            int temp;
            for (int i = 0; i < nums.Length - 1; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] > nums[j])
                    {
                        temp = nums[i];
                        nums[i] = nums[j];
                        nums[j] = temp;
                    }
                }
            }

        }
        static void СubicTyprOfAlgoritm()
        {
            char[] chars = new char[] { 'A', 'B', 'C' };
            for (int i = 0; i < chars.Length; i++)
            {
                for (int j = 0; j < chars.Length; j++)
                {
                    for (int k = 0; k < chars.Length; k++)
                    {
                        Console.WriteLine($"{chars[i]}{chars[j]}{chars[k]}");
                    }
                }
            }

        }
        static void ExpectedMyLinkedList()
        {
            LinkedList<string> linkedList = new LinkedList<string>();
            // добавление элементов
            linkedList.Add("Tom");
            linkedList.Add("Alice");
            linkedList.Add("Bob");
            linkedList.Add("Sam");

            // выводим элементы
            foreach (var item in linkedList)
            {
                Console.WriteLine(item);
            }
            // удаляем элемент
            linkedList.Remove("Alice");
            foreach (var item in linkedList)
            {
                Console.WriteLine(item);
            }
            // проверяем наличие элемента
            bool isPresent = linkedList.Contains("Sam");
            Console.WriteLine(isPresent == true ? "Sam присутствует" : "Sam отсутствует");

            // добавляем элемент в начало            
            linkedList.AppendFirst("Bill");
        }
        static void ExpectedMyDualLinkedList()
        {
            DoublyLinkedList<string> linkedList = new DoublyLinkedList<string>();
            // добавление элементов
            linkedList.Add("Bob");
            linkedList.Add("Bill");
            linkedList.Add("Tom");
            linkedList.AddFirst("Kate");
            foreach (var item in linkedList)
            {
                Console.WriteLine(item);
            }
            // удаление
            linkedList.Remove("Bill");

            // перебор с последнего элемента
            foreach (var t in linkedList.BackEnumerator())
            {
                Console.WriteLine(t);
            }
        }

        static void ExpectedMyStackLink()
        {
            try
            {
                FixedStack<string> stack = new FixedStack<string>(8);
                // добавляем четыре элемента
                stack.Push("Kate");
                stack.Push("Sam");
                stack.Push("Alice");
                stack.Push("Tom");

                // извлекаем один элемент
                var head = stack.Pop();
                Console.WriteLine(head);    // Tom

                // просто получаем верхушку стека без извлечения
                head = stack.Peek();
                Console.WriteLine(head);    // Alice
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void ExpectedQueue()
        {
            Queue<string> queue = new Queue<string>();
            queue.Enqueue("Kate");
            queue.Enqueue("Sam");
            queue.Enqueue("Alice");
            queue.Enqueue("Tom");

            foreach (string item in queue)
                Console.WriteLine(item);
            Console.WriteLine();

            Console.WriteLine();
            string firstItem = queue.Dequeue();
            Console.WriteLine($"Извлеченный элемент: {firstItem}");
            Console.WriteLine();

            foreach (string item in queue)
                Console.WriteLine(item);
        }

    }
}
