namespace SurrealDB.QueryBuilder.Fluent;

public interface IFromFluent
    : IWhereFluent,
      ISplitAtFluent,
      IGroupByFluent,
      IOrderByFluent,
      ILimitByFluent,
      IStartAtFluent,
      IFetchFluent,
      ITimeoutFluent,
      IParallelFluent
{
    IWhereFluent Where(string predicate);
}