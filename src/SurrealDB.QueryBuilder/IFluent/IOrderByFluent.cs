namespace SurrealDB.QueryBuilder.IFluent;

public interface IOrderByFluent
    : ILimitByFluent,
      IStartAtFluent,
      IFetchFluent,
      ITimeoutFluent,
      IParallelFluent,
      IBuildFluent
{
    ILimitByFluent LimitBy(int limit);
}