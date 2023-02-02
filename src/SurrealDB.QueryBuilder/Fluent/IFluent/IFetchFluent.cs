using SurrealDB.QueryBuilder.DataModels;

namespace SurrealDB.QueryBuilder.Fluent.IFluent;

public interface IFetchFluent
	: ITimeoutFluent,
		IParallelFluent,
		IBuildFluent
{
	ITimeoutFluent Timeout(Duration timeout);
}
