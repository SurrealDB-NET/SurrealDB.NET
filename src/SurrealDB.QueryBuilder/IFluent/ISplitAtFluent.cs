namespace SurrealDB.QueryBuilder.Fluent;

public interface ISplitAtFluent
    : IGroupByFluent,
      IOrderByFluent,
      ILimitByFluent,
      IStartAtFluent,
      IFetchFluent,
      ITimeoutFluent,
      IParallelFluent,
      IBuildFluent
{
    IGroupByFluent GroupBy(params string[] fields);
}