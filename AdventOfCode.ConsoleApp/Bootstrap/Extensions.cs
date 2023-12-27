using System;
using System.Linq;
using AdventOfCode.ConsoleApp.Puzzles.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace AdventOfCode.ConsoleApp.Bootstrap;

public static class Extensions
{
    public static IServiceCollection AddPuzzles(this IServiceCollection services)
    {
        var types = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(s => s.GetTypes())
            .Where(t => typeof(IPuzzle).IsAssignableFrom(t));

        foreach (var type in types)
        {
            if (type.IsInterface || type.IsAbstract)
            {
                continue;
            }

            services.Add(new ServiceDescriptor(typeof(IPuzzle), type, ServiceLifetime.Singleton));
        }

        return services;
    }
}
