﻿namespace ProjectEuler.Toolbox;

public static class Dice
{
    /// <summary>
    /// Possible dice rolls for a number of dice of specified sides.
    /// </summary>
    /// <param name="dice"></param>
    /// <param name="sides"></param>
    /// <returns></returns>
    public static IEnumerable<int[]> PossibleRolls(int dice, int sides)
    {
        for (var roll = 1; roll <= sides; roll++)
        {
            if (dice == 1)
            {
                yield return new[] { roll };
            }
            else
            {
                foreach (var rolls in PossibleRolls(dice - 1, sides))
                {
                    yield return new[] { roll }.Concat(rolls).ToArray();
                }
            }
        }
    }

    /// <summary>
    /// Generate a sequence of metered rolls of dice specifying how many
    /// dice to roll and how many sides they have.  Guaranteed to see all
    /// combinations every two periods.
    /// </summary>
    /// <param name="dice"></param>
    /// <param name="sides"></param>
    /// <returns></returns>
    public static IEnumerable<int[]> MeteredRolls(int dice, int sides)
    {
        var possibleRolls = PossibleRolls(dice, sides).ToList();

        possibleRolls.Shuffle();

        var queue = new Queue<int[]>(possibleRolls);

        while (true)
        {
            if (queue.Count < possibleRolls.Count)
            {
                var list = queue.Concat(possibleRolls).ToList();

                list.Shuffle();

                queue = new Queue<int[]>(list);
            }

            yield return queue.Dequeue();
        }
    }

    /// <summary>
    /// Generate a sequence of random rolls of dice specifying how many
    /// dice to roll and how many sides they have.
    /// </summary>
    /// <param name="dice"></param>
    /// <param name="sides"></param>
    /// <returns></returns>
    public static IEnumerable<int[]> RandomRolls(int dice, int sides)
    {
        var possibleRolls = PossibleRolls(dice, sides).ToList();
        var rand = new Random(Guid.NewGuid().GetHashCode());

        while (true)
        {
            yield return possibleRolls[rand.Next(0, possibleRolls.Count)];
        }
    }
}
