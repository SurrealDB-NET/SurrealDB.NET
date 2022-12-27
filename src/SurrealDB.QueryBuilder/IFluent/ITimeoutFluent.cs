namespace SurrealDB.QueryBuilder.IFluent;

public interface ITimeoutFluent
    : IParallelFluent,
      IBuildFluent
{
    IParallelFluent Parallel();
}