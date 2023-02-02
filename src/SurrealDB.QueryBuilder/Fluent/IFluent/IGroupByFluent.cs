using SurrealDB.QueryBuilder.Enums;

namespace SurrealDB.QueryBuilder.Fluent.IFluent;

public interface IGroupByFluent
	: IOrderByFluent,
		ILimitByFluent,
		IStartAtFluent,
		IFetchFluent,
		ITimeoutFluent,
		IParallelFluent,
		IBuildFluent
{
	IOrderByFluent OrderByRandom();

	IOrderByFluent OrderBy(
		string field, SortOrder sortOrder = SortOrder.Asc, TextSortMethod textSortMethod = TextSortMethod.None
	);
}
