using System;

namespace Chapter14_Q1Q2
{
    class Program
    {
        static void Main()
        {
            int[] array = { 11, 22, 33, 44, 55 };
            foreach (var item in array)
            {
                Action action = () => Console.WriteLine(item * item);

                action.Invoke();
            }
        }
    }
}
