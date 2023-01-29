namespace SurrealDB.QueryBuilder.Fluent.IFluent;

using DataModels;

public interface IFetchFluent
    : ITimeoutFluent,
      IParallelFluent,
      IBuildFluent
{
    ITimeoutFluent Timeout(Duration timeout);
}