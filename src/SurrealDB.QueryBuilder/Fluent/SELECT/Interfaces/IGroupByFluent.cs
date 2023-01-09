using SurrealDB.QueryBuilder.Enums;

namespace SurrealDB.QueryBuilder.Fluent.Select;

public interface IGroupByFluent : IOrderByFluent
{
    IOrderByFluent OrderByRandom();

    IOrderByFluent OrderBy(string field, SortOrder sortOrder = SortOrder.ASC,
        TextSortMethod textSortMethod = TextSortMethod.None);
}
