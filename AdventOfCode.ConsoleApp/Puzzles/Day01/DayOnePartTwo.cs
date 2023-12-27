using Microsoft.Extensions.Logging;

namespace AdventOfCode.ConsoleApp.Puzzles;

public class DayOnePartTwo : DayOne<DayOnePartTwo>
{
    private static string[] DigitLetters = ["one", "two", "three", "four", "five", "six", "seven", "eight", "nine"];

    public DayOnePartTwo(ILogger<DayOnePartTwo> logger)
        : base(logger)
    {
    }

    protected override DigitItem GetFirstDigit(string line)
    {
        var result = base.GetFirstDigit(line);
        var withLetters = GetFirstByDigitLetters(line);
        return withLetters is not null && withLetters.Value.Position < result.Position
            ? withLetters.Value
            : result;
    }

    protected override DigitItem GetLastDigit(string line)
    {
        var result = base.GetLastDigit(line);
        var withLetters = GetLastByDigitLetters(line);
        return withLetters is not null && withLetters.Value.Position > result.Position
            ? withLetters.Value
            : result;
    }

    private DigitItem? GetFirstByDigitLetters(string line)
    {
        DigitItem? item = null;
        for (int i = 0; i < DigitLetters.Length; i++)
        {
            int index = line.IndexOf(DigitLetters[i]);
            if (index < 0 || (item is not null && index > item.Value.Position))
            {
                continue;
            }

            item = new(index, i + 1);
        }

        return item;
    }

    private DigitItem? GetLastByDigitLetters(string line)
    {
        DigitItem? item = null;
        for (int i = 0; i < DigitLetters.Length; i++)
        {
            int index = line.LastIndexOf(DigitLetters[i]);
            if (index < 0 || (item is not null && index < item.Value.Position))
            {
                continue;
            }

            item = new(index, i + 1);
        }

        return item;
    }
}
