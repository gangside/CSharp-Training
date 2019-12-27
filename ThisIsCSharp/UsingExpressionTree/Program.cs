using System;
using System.Linq.Expressions;

namespace UsingExpressionTree
{
    class Program
    {
        static void Main(string[] args)
        {
            //1*2+(x-y)
            Expression const1 = Expression.Constant(1);
            Expression const2 = Expression.Constant(2);

            //1*2
            Expression leftExp = Expression.Multiply(const1, const2);

            //x, y를 위한 변수
            Expression param1 = Expression.Parameter(typeof(int));
            Expression param2 = Expression.Parameter(typeof(int));

            //x-y
            Expression rightExp = Expression.Subtract(param1, param2);

            Expression exp = Expression.Add(leftExp, rightExp);

            Expression<Func<int, int, int>> expression
                = Expression<Func<int, int, int>>.Lambda<Func<int, int, int>>(exp, new ParameterExpression[] { 
                (ParameterExpression)param1, (ParameterExpression)param2});

            Func<int, int, int> func = expression.Compile();

            // x = 10, y = 7
            Console.WriteLine($"1*2+({10}-{7}) = {func(10, 7)}");
        }
    }
}
