using System.Text;
using SurrealDB.QueryBuilder.IFluent;

namespace SurrealDB.QueryBuilder.Fluent;

internal class FromFluent : WhereFluent, IFromFluent
{
    internal FromFluent(StringBuilder currentQuery)
        : base(currentQuery) { }

    public IWhereFluent Where(string predicate)
    {
        _query.Append($" WHERE {predicate}");
        return new WhereFluent(_query);
    }
}