using System.Text;
using SurrealDB.QueryBuilder.IFluent;

namespace SurrealDB.QueryBuilder.Fluent;

internal class FetchFluent : TimeoutFluent, IFetchFluent
{
    internal FetchFluent(StringBuilder currentQuery)
        : base(currentQuery) { }

    public ITimeoutFluent Timeout(string timeout)
    {
        _query.Append($" TIMEOUT {timeout}");
        return new TimeoutFluent(_query);
    }
}
