namespace SurrealDB.Examples;

public interface IExample
{
	public string Name { get; }

	public string Description { get; }

	public Task RunAsync(CancellationToken cancellationToken = default);
}
