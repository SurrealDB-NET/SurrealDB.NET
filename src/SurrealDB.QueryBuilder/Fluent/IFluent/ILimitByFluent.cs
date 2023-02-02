namespace SurrealDB.QueryBuilder.Fluent.IFluent;

public interface ILimitByFluent
	: IStartAtFluent,
		IFetchFluent,
		ITimeoutFluent,
		IParallelFluent,
		IBuildFluent
{
	IStartAtFluent StartAt(uint startAt);
}
