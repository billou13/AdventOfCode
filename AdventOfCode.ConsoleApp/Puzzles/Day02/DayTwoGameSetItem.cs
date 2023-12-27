using System;

namespace AdventOfCode.ConsoleApp.Puzzles;

public class DayTwoGameSetItem
{
    public DayTwoColor Color { get; private set; }
    public int Quantity { get; private set; }

    public static DayTwoGameSetItem Parse(string value)
    {
        string[] values = value.Trim().Split(' ');
        return new DayTwoGameSetItem
        {
            Color = ParseColor(values[1]),
            Quantity = int.Parse(values[0])
        };
    }

    private static DayTwoColor ParseColor(string value)
    {
        if (string.Equals(value, "blue", StringComparison.InvariantCultureIgnoreCase)) return DayTwoColor.Blue;
        if (string.Equals(value, "green", StringComparison.InvariantCultureIgnoreCase)) return DayTwoColor.Green;
        if (string.Equals(value, "red", StringComparison.InvariantCultureIgnoreCase)) return DayTwoColor.Red;
        throw new InvalidOperationException($"The value '{value}' is not recognized as a correct color value.");
    }
}
