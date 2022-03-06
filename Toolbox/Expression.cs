using System.Text.RegularExpressions;

namespace ProjectEuler.Toolbox;

// TODO: Test Expression class
public static class Expression
{
    /// <summary>
    /// Simple generic expression evaluator NOTE: only supports +-*/ for now
    ///
    /// *** Must be properly parenthesized ***
    /// </summary>
    /// <param name="expr"></param>
    /// <returns></returns>
    public static double Evaluate(string expr)
    {
        while (expr.Contains('('))
        {
            expr = Regex.Replace(expr, @"\(([^\(]*?)\)", m => Evaluate(m.Groups[1].Value).ToString());
        }

        double result = 0;

        foreach (var match in Regex.Matches("+" + expr, @"\D ?-?[\d.]+").Cast<Match>())
        {
            var oper = match.Value[0];
            var value = double.Parse(match.Value[1..]);
            result = oper == '+' ? result + value : oper == '-' ? result - value : oper == '*' ? result * value : result / value;
        }

        return result;
    }

    /// <summary>
    /// Valid RPN instruction "a b op". NOTE: assumes binary operators only for now
    /// </summary>
    /// <param name="expr"></param>
    /// <returns></returns>
    public static double EvaluateRPN(string expr)
    {
        var stack = new Stack<double>();

        foreach (var item in expr.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
        {
            if ("+-*/".Contains(item[0]))
            {
                stack.Push(item[0] == '+' ? stack.Pop() + stack.Pop() : item[0] == '-' ? stack.Pop() - stack.Pop() : item[0] == '*' ? stack.Pop() * stack.Pop() : stack.Pop() / stack.Pop());
            }
            else
            {
                stack.Push(double.Parse(item));
            }
        }

        return stack.Pop();
    }
}
