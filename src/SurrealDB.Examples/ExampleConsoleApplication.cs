using System.Collections.Immutable;
using System.Reflection;

namespace SurrealDB.Examples;

public static class ExampleConsoleApplication
{
	public static async Task RunAsync()
	{
		var assembly = Assembly.GetEntryAssembly();

		if (assembly is null)
		{
			throw new InvalidOperationException("Could not find entry assembly.");
		}

		var examples = assembly
		               .GetTypes()
		               .Where(type => type.GetInterfaces().Any(@interface => @interface == typeof(IExample)))
		               .Select(exampleType => (IExample)Activator.CreateInstance(exampleType)!)
		               .ToImmutableArray();

		for (var i = 0; i < examples.Length; i++)
		{
			Console.WriteLine($"{i + 1}. {examples[i].Name}: {examples[i].Description}");
		}

		Console.WriteLine();
		Console.Write("Enter the number of the example you want to run: ");

		while (true)
		{
			string? input = Console.ReadLine();

			if (input is null)
			{
				break;
			}

			bool isInteger = int.TryParse(input, out int exampleNumber);

			if (!isInteger || exampleNumber < 1 || exampleNumber > examples.Length)
			{
				Console.WriteLine($"Invalid input. Please enter a number between 1 and {examples.Length}.");

				continue;
			}

			IExample exampleToRun = examples[exampleNumber - 1];

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
