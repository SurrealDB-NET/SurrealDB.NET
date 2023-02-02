namespace SurrealDB.QueryBuilder.Fluent.IFluent;

public interface IFromFluent
	: IWhereFluent,
		ISplitAtFluent,
		IGroupByFluent,
		IOrderByFluent,
		ILimitByFluent,
		IStartAtFluent,
		IFetchFluent,
		ITimeoutFluent,
		IParallelFluent
{
	IWhereFluent Where(string predicate);
}
