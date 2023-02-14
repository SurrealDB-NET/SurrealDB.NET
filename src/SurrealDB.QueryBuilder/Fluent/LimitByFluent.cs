using System.Text;
using SurrealDB.QueryBuilder.Fluent.IFluent;

namespace SurrealDB.QueryBuilder.Fluent;

internal class LimitByFluent : StartAtFluent, ILimitByFluent
{
	internal LimitByFluent(StringBuilder currentQuery)
		: base(currentQuery) { }

	public IStartAtFluent StartAt(uint startAt)
	{
		Query.Append($" START {startAt}");

		return new StartAtFluent(Query);
	}
}
