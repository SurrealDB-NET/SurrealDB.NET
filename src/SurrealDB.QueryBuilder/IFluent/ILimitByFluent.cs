namespace SurrealDB.QueryBuilder.IFluent;

public interface ILimitByFluent
    : IStartAtFluent,
      IFetchFluent,
      ITimeoutFluent,
      IParallelFluent,
      IBuildFluent
{
    IStartAtFluent StartAt(int startAt);
}