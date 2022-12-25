namespace SurrealDB.Examples;

public interface IExample
{
    public Task RunAsync(CancellationToken cancellationToken = default);
}
