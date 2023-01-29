using System.Text;
using SurrealDB.QueryBuilder.DataModels;

namespace SurrealDB.QueryBuilder.Fluent;

using IFluent;

internal class FetchFluent : TimeoutFluent, IFetchFluent
{
    internal FetchFluent(StringBuilder currentQuery)
        : base(currentQuery) { }

    public ITimeoutFluent Timeout(Duration timeout)
    {
        query.Append($" TIMEOUT {timeout}");
        return new TimeoutFluent(query);
    }
}
