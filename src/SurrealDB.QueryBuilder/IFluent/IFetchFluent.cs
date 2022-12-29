namespace SurrealDB.QueryBuilder.Fluent;

public interface IFetchFluent
    : ITimeoutFluent,
      IParallelFluent,
      IBuildFluent
{
    ITimeoutFluent Timeout(string timeout);
}