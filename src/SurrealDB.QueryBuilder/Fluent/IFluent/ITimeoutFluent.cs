namespace SurrealDB.QueryBuilder.Fluent.IFluent;

public interface ITimeoutFluent
	: IParallelFluent,
		IBuildFluent
{
	IParallelFluent Parallel();
}
