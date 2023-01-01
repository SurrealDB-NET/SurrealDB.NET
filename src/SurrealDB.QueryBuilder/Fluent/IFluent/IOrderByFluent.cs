namespace SurrealDB.QueryBuilder.Fluent;

public interface IOrderByFluent
    : ILimitByFluent,
      IStartAtFluent,
      IFetchFluent,
      ITimeoutFluent,
      IParallelFluent,
      IBuildFluent
{
    ILimitByFluent LimitBy(uint limit);
}