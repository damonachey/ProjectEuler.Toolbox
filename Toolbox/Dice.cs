namespace ProjectEuler.Toolbox;

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
                    var result = new int[rolls.Length + 1];
                    rolls.AsSpan().CopyTo(result.AsSpan(1));
                    result[0] = roll;

                    yield return result;
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
        var possibleRolls = PossibleRolls(dice, sides).ToArray();

        Random.Shared.Shuffle(possibleRolls);

        var queue = new Queue<int[]>(possibleRolls);

        while (true)
        {
            if (queue.Count < possibleRolls.Length)
            {
                var list = queue.Concat(possibleRolls).ToArray();

                Random.Shared.Shuffle(list);

                queue = new(list);
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
        var possibleRolls = PossibleRolls(dice, sides).ToArray();

        while (true)
        {
            yield return possibleRolls[Random.Shared.Next(0, possibleRolls.Length)];
        }
    }
}
