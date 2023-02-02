using System.Text;
using SurrealDB.QueryBuilder.DataModels;
using SurrealDB.QueryBuilder.Fluent.IFluent;

namespace SurrealDB.QueryBuilder.Fluent;

internal class FetchFluent : TimeoutFluent, IFetchFluent
{
	internal FetchFluent(StringBuilder currentQuery)
		: base(currentQuery) { }

	public ITimeoutFluent Timeout(Duration timeout)
	{
		Query.Append($" TIMEOUT {timeout}");

		return new TimeoutFluent(Query);
	}
}
