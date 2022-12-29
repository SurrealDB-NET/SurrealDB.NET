using SurrealDB.QueryBuilder.Enums;

namespace SurrealDB.QueryBuilder.IFluent;

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

    IOrderByFluent OrderBy(string field, TextSortMethod textSortMethod = TextSortMethod.None, SortOrder sortOrder = SortOrder.Asc);
}