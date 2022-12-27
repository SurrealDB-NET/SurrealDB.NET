using System.Text;
using SurrealDB.QueryBuilder.IFluent;

namespace SurrealDB.QueryBuilder.Fluent;

internal class StartAtFluent : FetchFluent, IStartAtFluent
{
    internal StartAtFluent(StringBuilder currentQuery)
        : base(currentQuery) { }

    public IFetchFluent Fetch(params string[] fields)
    {
        _query.Append(" FETCH ");
        _query.Append(string.Join(", ", fields));
        return new FetchFluent(_query);
    }
}