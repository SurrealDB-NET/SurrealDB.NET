namespace SurrealDB.QueryBuilder.Fluent;

using System.Text;
using IFluent;

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
