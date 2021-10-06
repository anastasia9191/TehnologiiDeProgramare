
using System;
using System.Linq;
using System.Threading;

namespace VisualSort
{
    class Program
    {
        private static void Main(string[] args)
        {
            Random random = new Random();
            int[] array = new int[30];
            array = array.Select(x => random.Next(0, 21)).ToArray();
            
            for (int i = 0; i < array.Length; i++)
            {
                int min = i;
                for (int j = i + 1; j < array.Length; j++)
                    if (array[j] < array[min])
                        min = j;
                if (min != i)
                    swap(ref array[i], ref array[min]);

                Console.SetCursorPosition(0, 0);
                Console.Write(print(array));
                Thread.Sleep(300);
            }

            Console.ReadKey(true);
        }

        static string print(int[] array)
        {
            string result = string.Empty;

            int lim = array.Max(), min = array.Min();
            for (int i = min; i <= lim; i++)
            {
                int tmp = 0;
                for (int j = 0; j < array.Length; j++)
                {
                    if (array[j] <= i)
                    {
                        result += "█";
                        tmp = array[j];
                    }
                    else result += " ";
                }
                result += string.Format(" : {0}\n", tmp);
            }

            return result;
        }

        static void swap<T>(ref T a, ref T b)
        {
            T c = a;
            a = b;
            b = c;
        }
    }
}
