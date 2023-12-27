using System;
using System.IO;
using AdventOfCode.ConsoleApp.Puzzles.Interfaces;
using Microsoft.Extensions.Logging;

namespace AdventOfCode.ConsoleApp.Puzzles;

public abstract class DayOne<T> : IPuzzle
{
    protected readonly ILogger<T> _logger;

    public DayOne(ILogger<T> logger)
    {
        _logger = logger;
    }

    public void Execute()
    {
        int sum = 0;
        using (var stream = new StreamReader(@"Assets\DayOne.txt"))
        {
            while (!stream.EndOfStream)
            {
                string line = stream.ReadLine();
                if (string.IsNullOrEmpty(line))
                {
                    continue;
                }

                var firstDigit = GetFirstDigit(line);
                var lastDigit = GetLastDigit(line);

                int number = firstDigit.Value * 10 + lastDigit.Value;
                sum += number;
                _logger.LogDebug($"{nameof(Execute)} - +{number}={sum} [{line}]");
            }
        }

        _logger.LogInformation($"{nameof(Execute)} - total = {sum}");
    }

    protected virtual DigitItem GetFirstDigit(string line)
    {
        for (int i = 0; i < line.Length; i++)
        {
            if (char.IsDigit(line[i]))
            {
                return new(i, line[i] - '0');
            }
        }

        throw new InvalidOperationException($"${nameof(GetFirstDigit)} - unable to find first digit from line '{line}'");
    }

    protected virtual DigitItem GetLastDigit(string line)
    {
        for (int i = line.Length - 1; i >= 0; i--)
        {
            if (char.IsDigit(line[i]))
            {
                return new(i, line[i] - '0');
            }
        }

        throw new InvalidOperationException($"${nameof(GetLastDigit)} - unable to find last digit from line '{line}'");
    }
}
