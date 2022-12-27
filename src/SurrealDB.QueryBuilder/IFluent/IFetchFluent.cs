namespace SurrealDB.QueryBuilder.IFluent;

public interface IFetchFluent
    : ITimeoutFluent,
      IParallelFluent,
      IBuildFluent
{
    ITimeoutFluent Timeout(string timeout);
}