using SurrealDB.QueryBuilder.Enums;

namespace SurrealDB.QueryBuilder.Fluent;

public interface IGroupByFluent
    : IOrderByFluent,
      ILimitByFluent,
      IStartAtFluent,
      IFetchFluent,
      ITimeoutFluent,
      IParallelFluent,
      IBuildFluent
{
    IOrderByFluent OrderByRandom();

    IOrderByFluent OrderBy(string field, SortOrder sortOrder = SortOrder.ASC, TextSortMethod textSortMethod = TextSortMethod.None);
}