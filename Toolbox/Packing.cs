using System.Numerics;

namespace ProjectEuler.Toolbox;

/// <summary>
/// Functions to solve the packing problem class of problems
/// </summary>
public static class Packing
{
    /// <summary>
    /// Find the set of items that combined get closest to but not exceed the goal value
    /// </summary>
    /// <param name="items"></param>
    /// <param name="goal"></param>
    /// <returns></returns>
    public static IEnumerable<long> Knapsack(long[] items, long goal)
    {
        var matches = items
            .Where(i => i <= goal)
            .Select(i => new { i, ia = new[] { i } })
            .Select(t => t.i == goal ? t.ia : Knapsack(items, goal - t.i).Concat(t.ia));

        return matches.OrderBy(x => x.Count()).First();
    }

    /// <summary>
    /// Find the set of items that combined get closest to but not exceed the goal value
    /// </summary>
    /// <param name="goal"></param>
    /// <param name="items"></param>
    /// <param name="chosenItems"></param>
    /// <returns></returns>
    public static BigInteger Knapsack01(BigInteger goal, ReadOnlySpan<BigInteger> items, out List<BigInteger> chosenItems)
    {
        chosenItems = new();

        if (items.Length == 0)
        {
            return 0;
        }

        if (items.Length == 1)
        {
            if (items[0] <= goal)
            {
                chosenItems.Add(items[0]);
                return items[0];
            }
            
            return 0;
        }

        // without the first item
        var remainItems = items[1..];
        var withoutFirstItemResult = Knapsack01(goal, remainItems, out List<BigInteger> chosenItemsInRemainItems);

        // with all the items
        var withFirstItemResult = BigInteger.Zero;
        var chosenItemsInItems = new List<BigInteger>();

        if (goal >= items[0])
        {
            withFirstItemResult = Knapsack01(goal - items[0], remainItems, out chosenItemsInItems) + items[0];
            chosenItemsInItems.Add(items[0]);
        }

        // select max from the two results
        if (withoutFirstItemResult >= withFirstItemResult)
        {
            chosenItems = chosenItemsInRemainItems;
            return withoutFirstItemResult;
        }

        chosenItems = chosenItemsInItems;
        return withFirstItemResult;
    }
}
