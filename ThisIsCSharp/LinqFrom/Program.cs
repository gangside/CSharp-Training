using System;
using System.Linq;

namespace LinqFrom
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 8, 7, 6, 2, 10, 66, 1, 10 };
            var result = from n in numbers
                         where n % 2 == 0
                         orderby n
                         select n;

            foreach (int n in result)
            {
                Console.WriteLine($"짝수 : {n}");
            }
        }
    }
}
