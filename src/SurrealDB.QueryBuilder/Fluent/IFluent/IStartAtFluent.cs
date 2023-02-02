namespace SurrealDB.QueryBuilder.Fluent.IFluent;

public interface IStartAtFluent
	: IFetchFluent,
		ITimeoutFluent,
		IParallelFluent,
		IBuildFluent
{
	IFetchFluent Fetch(params string[] fields);
}
