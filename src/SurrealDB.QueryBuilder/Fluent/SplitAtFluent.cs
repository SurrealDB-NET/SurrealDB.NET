namespace SurrealDB.QueryBuilder.Fluent;

using System.Text;
using IFluent;

internal class SplitAtFluent : GroupByFluent, ISplitAtFluent
{
    internal SplitAtFluent(StringBuilder currentQuery)
        : base(currentQuery) { }

    public IGroupByFluent GroupBy(params string[] fields)
    {
        Query.Append($" GROUP {string.Join(", ", fields)}");
        return new GroupByFluent(Query);
    }
}
