using System.Collections.Immutable;
using System.Reflection;
using SurrealDB.Examples;

var exampleTypes = Assembly
    .GetExecutingAssembly()
    .GetTypes()
    .Where(type => type
        .GetInterfaces()
        .Any(@interface => @interface == typeof(IExample)))
    .ToImmutableArray();

var examples = exampleTypes
    .Select(exampleType => (IExample) Activator.CreateInstance(exampleType)!)
    .ToImmutableArray();

Console.WriteLine("SurrealDB.NET Examples");
Console.WriteLine("==================");
Console.WriteLine();

for (var i = 0; i < examples.Length; i++)
{
    var example = examples[i];

    Console.WriteLine($"{i + 1}. {example.Name}: {example.Description}");
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

    if (!isInteger || exampleNumber < 1 || exampleNumber > examples.Length)
    {
        Console.WriteLine("Invalid input. Please enter a number between 1 and {0}.", examples.Length);

        continue;
    }

    var exampleToRun = examples[exampleNumber - 1];

    Console.WriteLine();
    Console.WriteLine($"Running example {exampleNumber}: {exampleToRun.Name}");
    Console.WriteLine();

    await exampleToRun.RunAsync();

    Console.WriteLine();
    Console.WriteLine("Press any key to exit...");
    Console.ReadKey();

    break;
}
