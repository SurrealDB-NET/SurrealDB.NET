namespace SurrealDB.QueryBuilder.Fluent;

public interface IStartAtFluent
    : IFetchFluent,
      ITimeoutFluent,
      IParallelFluent,
      IBuildFluent
{
    IFetchFluent Fetch(params string[] fields);
}