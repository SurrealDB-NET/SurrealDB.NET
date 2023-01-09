using System.Text;
using SurrealDB.QueryBuilder.DataModels;
using SurrealDB.QueryBuilder.Fluent.Shared;
using SurrealDB.QueryBuilder.Fluent.Shared.Implementation;

namespace SurrealDB.QueryBuilder.Fluent.Select;

internal class FetchFluent : TimeoutFluent, IFetchFluent
{
    internal FetchFluent(StringBuilder currentQuery)
        : base(currentQuery)
    {
    }

    public ITimeoutFluent Timeout(Duration timeout)
    {
        query.Append($" TIMEOUT {timeout}");
        return new TimeoutFluent(query);
    }
}
