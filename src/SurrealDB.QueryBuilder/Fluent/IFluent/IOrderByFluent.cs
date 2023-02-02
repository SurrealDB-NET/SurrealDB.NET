namespace SurrealDB.QueryBuilder.Fluent.IFluent;

public interface IOrderByFluent
	: ILimitByFluent,
		IStartAtFluent,
		IFetchFluent,
		ITimeoutFluent,
		IParallelFluent,
		IBuildFluent
{
	ILimitByFluent LimitBy(uint limit);
}
