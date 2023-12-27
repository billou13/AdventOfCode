using System.IO;
using AdventOfCode.ConsoleApp.Puzzles.Interfaces;
using Microsoft.Extensions.Logging;

namespace AdventOfCode.ConsoleApp.Puzzles;

public class DayTwoPartTwo : IPuzzle
{
    protected readonly ILogger<DayTwoPartTwo> _logger;

    public DayTwoPartTwo(ILogger<DayTwoPartTwo> logger)
    {
        _logger = logger;
    }

    public void Execute()
    {
        int sum = 0;
        using (var stream = new StreamReader(@"Assets\Day02.txt"))
        {
            while (!stream.EndOfStream)
            {
                string line = stream.ReadLine();
                if (string.IsNullOrEmpty(line))
                {
                    continue;
                }

                var game = DayTwoGame.Parse(line);
                int power = game.CalculatePower();

                sum += power;
                _logger.LogDebug($"{nameof(Execute)} - +{power}={sum} [{line}]");
            }
        }

        _logger.LogInformation($"{nameof(Execute)} - total = {sum}");
    }
}
