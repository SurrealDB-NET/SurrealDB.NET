using SurrealDB.QueryBuilder.Enums;

namespace SurrealDB.QueryBuilder.IFluent;

public interface IWhereFluent
    : ISplitAtFluent,
      IGroupByFluent,
      IOrderByFluent,
      ILimitByFluent,
      IStartAtFluent,
      IFetchFluent,
      ITimeoutFluent,
      IParallelFluent
{
    ISplitAtFluent SplitAt(params string[] fields);
}