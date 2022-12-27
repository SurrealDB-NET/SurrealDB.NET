using SurrealDB.QueryBuilder.Enums;

namespace SurrealDB.QueryBuilder.IFluent;

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