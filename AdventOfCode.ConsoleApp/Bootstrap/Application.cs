using System;
using System.Collections.Generic;
using System.Threading;
using AdventOfCode.ConsoleApp.Puzzles.Interfaces;
using Microsoft.Extensions.Logging;

namespace AdventOfCode.ConsoleApp.Bootstrap;

public class Application
{
    private readonly ILogger<Application> _logger;
    private readonly IEnumerable<IPuzzle> _puzzles;

    public Application(ILogger<Application> logger, IEnumerable<IPuzzle> puzzles)
    {
        _logger = logger;
        _puzzles = puzzles;
    }

    public void Run(string[] args)
    {
        string name = args[0];
        _logger.LogDebug($"{nameof(Run)} - loading puzzle '{name}'...");

        var puzzle = LoadPuzzle(name);
        puzzle.Execute();
    }

    private IPuzzle LoadPuzzle(string name)
    {
        foreach (var puzzle in _puzzles)
        {
            if (!string.Equals(puzzle.GetType().Name, name, StringComparison.InvariantCultureIgnoreCase))
            {
                continue;
            }

            return puzzle;
        }

        throw new ArgumentException($"The name '{name}' is not recognized as a correct type of puzzle.", nameof(name));
    }
}
