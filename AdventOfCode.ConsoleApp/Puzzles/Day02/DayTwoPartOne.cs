using System.IO;
using AdventOfCode.ConsoleApp.Puzzles.Interfaces;
using Microsoft.Extensions.Logging;

namespace AdventOfCode.ConsoleApp.Puzzles;

public class DayTwoPartOne : IPuzzle
{
    protected readonly ILogger<DayTwoPartOne> _logger;

    public DayTwoPartOne(ILogger<DayTwoPartOne> logger)
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

                bool isRedPossible = game.MatchWith(DayTwoColor.Red, 12);
                bool isGreenPossible = game.MatchWith(DayTwoColor.Green, 13);
                bool isBluePossible = game.MatchWith(DayTwoColor.Blue, 14);
                bool isPossible = isRedPossible && isGreenPossible && isBluePossible;

                int number = isPossible ? game.GameId : 0;
                sum += number;
                _logger.LogDebug($"{nameof(Execute)} - {(isPossible ? "OK" : "KO")} +{number}={sum} [{line}]");
            }
        }

        _logger.LogInformation($"{nameof(Execute)} - total = {sum}");
    }
}
