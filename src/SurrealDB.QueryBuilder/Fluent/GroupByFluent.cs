using System.Text;
using SurrealDB.QueryBuilder.Enums;
using SurrealDB.QueryBuilder.IFluent;

namespace SurrealDB.QueryBuilder.Fluent;

internal class GroupByFluent : OrderByFluent, IGroupByFluent
{
    internal GroupByFluent(StringBuilder currentQuery)
        : base(currentQuery) { }

    public IOrderByFluent OrderByRandom()
    {
        Query.Append(" ORDER RAND()");
        return new OrderByFluent(Query);
    }

    public IOrderByFluent OrderBy(string field, TextSortMethod textSortMethod = TextSortMethod.None, SortOrder sortOrder = SortOrder.Asc)
    {
        Query.Append(" ORDER ");
        Query.Append(field);
        if (textSortMethod is not TextSortMethod.None)
            Query.Append($" {textSortMethod.ToString().ToUpper()}");
        Query.Append($" {sortOrder.ToString().ToUpper()}");
        return new OrderByFluent(Query);
    }
}