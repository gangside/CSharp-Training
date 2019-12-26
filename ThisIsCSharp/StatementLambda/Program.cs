using System;

namespace StatementLambda
{
    class Program
    {
        delegate string Concatenate(string[] args);

        static void Main(string[] args)
        {
            string[] arr = { "치킨", "피자", "족발" };

            Concatenate concat = (arr) =>
            {
                string result = "";
                foreach (string s in arr){
                    result += s;
                }
                return result;
            };

            Console.WriteLine(concat(arr));
        }
    }
}
