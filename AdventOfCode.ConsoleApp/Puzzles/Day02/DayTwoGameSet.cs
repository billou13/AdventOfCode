using System.Collections.Generic;

namespace AdventOfCode.ConsoleApp.Puzzles;

public class DayTwoGameSet
{
    public readonly List<DayTwoGameSetItem> Items;

    public DayTwoGameSet()
    {
        Items = new List<DayTwoGameSetItem>();
    }

    public bool MatchWith(DayTwoColor color, int quantity)
    {
        foreach (var item in Items)
        {
            if (color != item.Color)
            {
                continue;
            }

            if (item.Quantity > quantity)
            {
                return false;
            }
        }

        return true;
    }

    public int GetQuantity(DayTwoColor color)
    {
        foreach (var item in Items)
        {
            if (color != item.Color)
            {
                continue;
            }

            return item.Quantity;
        }

        return 0;
    }

    public static DayTwoGameSet Parse(string value)
    {
        var result = new DayTwoGameSet();
        foreach (string v in value.Split(','))
        {
            result.Items.Add(DayTwoGameSetItem.Parse(v));
        }

        return result;
    }
}
