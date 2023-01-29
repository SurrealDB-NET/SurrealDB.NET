namespace SurrealDB.Examples;

using System.Collections.Immutable;
using System.Reflection;

public static class ExampleConsoleApplication
{
    // ReSharper disable once MemberCanBePrivate.Global
    public static readonly ImmutableArray<IExample> Examples = Assembly
        .GetExecutingAssembly()
        .GetTypes()
        .Where(type => type.GetInterfaces().Any(@interface => @interface == typeof(IExample)))
        .Select(exampleType => (IExample)Activator.CreateInstance(exampleType)!)
        .ToImmutableArray();

    public static async Task RunAsync()
    {
        for (var i = 0; i < Examples.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {Examples[i].Name}: {Examples[i].Description}");
        }

        Console.WriteLine();
        Console.Write("Enter the number of the example you want to run: ");

        while (true)
        {
            var input = Console.ReadLine();

            if (input is null)
            {
                break;
            }

            var isInteger = int.TryParse(input, out var exampleNumber);

            if (!isInteger || exampleNumber < 1 || exampleNumber > Examples.Length)
            {
                Console.WriteLine($"Invalid input. Please enter a number between 1 and {Examples.Length}.");

                continue;
            }

            var exampleToRun = Examples[exampleNumber - 1];

            Console.WriteLine();
            Console.WriteLine($"Running example {exampleNumber}: {exampleToRun.Name}");
            Console.WriteLine();

            await exampleToRun.RunAsync();

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();

            break;
        }
    }
}
