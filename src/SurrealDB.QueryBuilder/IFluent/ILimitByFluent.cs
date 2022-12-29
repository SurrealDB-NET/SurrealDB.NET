namespace SurrealDB.QueryBuilder.Fluent;

public interface ILimitByFluent
    : IStartAtFluent,
      IFetchFluent,
      ITimeoutFluent,
      IParallelFluent,
      IBuildFluent
{
    IStartAtFluent StartAt(int startAt);
}