using System.Text;

namespace SurrealDB.QueryBuilder.Fluent;

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