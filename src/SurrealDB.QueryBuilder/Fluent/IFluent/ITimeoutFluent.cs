namespace SurrealDB.QueryBuilder.Fluent;

public interface ITimeoutFluent
    : IParallelFluent,
      IBuildFluent
{
    IParallelFluent Parallel();
}