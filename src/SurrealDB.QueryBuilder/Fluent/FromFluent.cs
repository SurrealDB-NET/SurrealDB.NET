using System.Text;
using SurrealDB.QueryBuilder.Fluent.IFluent;

namespace SurrealDB.QueryBuilder.Fluent;

internal class FromFluent : WhereFluent, IFromFluent
{
	internal FromFluent(StringBuilder currentQuery)
		: base(currentQuery) { }

	public IWhereFluent Where(string predicate)
	{
		Query.Append($" WHERE {predicate}");

		return new WhereFluent(Query);
	}
}
