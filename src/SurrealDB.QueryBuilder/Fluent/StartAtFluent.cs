using System.Text;
using SurrealDB.QueryBuilder.Fluent.IFluent;

namespace SurrealDB.QueryBuilder.Fluent;

internal class StartAtFluent : FetchFluent, IStartAtFluent
{
	internal StartAtFluent(StringBuilder currentQuery)
		: base(currentQuery) { }

	public IFetchFluent Fetch(params string[] fields)
	{
		Query.Append(" FETCH ");
		Query.Append(string.Join(", ", fields));

		return new FetchFluent(Query);
	}
}
