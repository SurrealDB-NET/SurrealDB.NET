using System.Text;

namespace SurrealDB.QueryBuilder.Fluent;

internal class FromFluent : WhereFluent, IFromFluent
{
    internal FromFluent(StringBuilder currentQuery)
        : base(currentQuery) { }

    public IWhereFluent Where(string predicate)
    {
        query.Append($" WHERE {predicate}");
        return new WhereFluent(query);
    }
}