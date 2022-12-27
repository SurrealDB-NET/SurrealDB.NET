namespace SurrealDB.QueryBuilder.IFluent;

public interface IStartAtFluent
    : IFetchFluent,
      ITimeoutFluent,
      IParallelFluent,
      IBuildFluent
{
    IFetchFluent Fetch(params string[] fields);
}