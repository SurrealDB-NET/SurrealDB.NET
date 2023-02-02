using System.Text;
using SurrealDB.QueryBuilder.Fluent.IFluent;

namespace SurrealDB.QueryBuilder.Fluent;

internal class OrderByFluent : LimitByFluent, IOrderByFluent
{
	internal OrderByFluent(StringBuilder currentQuery)
		: base(currentQuery) { }

	public ILimitByFluent LimitBy(uint limit)
	{
		Query.Append($" LIMIT {limit}");

		return new LimitByFluent(Query);
	}
}
