using System;
using System.Linq.Expressions;

namespace ExpressionTreeViaLambda
{
    class Program
    {
        static void Main(string[] args)
        {
            Expression<Func<int, int, int>> expression = (a, b) => 1 * 2 + (a - b);

            Func<int, int, int> func = expression.Compile();

            //x = 10, y = 8;
            Console.WriteLine($"1*2+({10}-{8}) = {func(10, 8)}");
        }
    }
}
