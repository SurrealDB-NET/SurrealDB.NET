using System.Text;

namespace SurrealDB.QueryBuilder.Fluent.Select.Implementation;

internal class SplitAtFluent : GroupByFluent, ISplitAtFluent
{
    internal SplitAtFluent(StringBuilder currentQuery)
        : base(currentQuery)
    {
    }

    public IGroupByFluent GroupBy(params string[] fields)
    {
        query.Append($" GROUP {string.Join(", ", fields)}");
        return new GroupByFluent(query);
    }
}
