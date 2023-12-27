using System;
using System.Collections.Generic;

namespace AdventOfCode.ConsoleApp.Puzzles;

public class DayTwoGame
{
    public int GameId { get; private set; }
    public readonly List<DayTwoGameSet> Sets;

    public DayTwoGame()
    {
        Sets = new List<DayTwoGameSet>();
    }

    public bool MatchWith(DayTwoColor color, int quantity)
    {
        foreach (var set in Sets)
        {
            if (set.MatchWith(color, quantity))
            {
                continue;
            }

            return false;
        }

        return true;
    }

    public int CalculatePower()
    {
        int minRedQuantity = GetMinimumQuantity(DayTwoColor.Red);
        int minGreenQuantity = GetMinimumQuantity(DayTwoColor.Green);
        int minBlueQuantity = GetMinimumQuantity(DayTwoColor.Blue);

        return minRedQuantity * minGreenQuantity * minBlueQuantity;
    }

    private int GetMinimumQuantity(DayTwoColor color)
    {
        int result = 0;
        foreach (var set in Sets)
        {
            result = Math.Max(result, set.GetQuantity(color));
        }

        return result;
    }

    public static DayTwoGame Parse(string value)
    {
        string[] values = value.Split(':');

        var result = new DayTwoGame { GameId = ParseGameId(values[0]) };
        foreach (string v in values[1].Split(';'))
        {
            result.Sets.Add(DayTwoGameSet.Parse(v));
        }

        return result;
    }

    private static int ParseGameId(string value)
    {
        return int.Parse(value.Replace("game", string.Empty, StringComparison.InvariantCultureIgnoreCase).Trim());
    }
}
