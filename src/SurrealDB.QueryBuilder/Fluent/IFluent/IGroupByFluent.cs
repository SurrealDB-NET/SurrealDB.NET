namespace SurrealDB.QueryBuilder.Fluent.IFluent;

using Enums;

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

    IOrderByFluent OrderBy(string field, SortOrder sortOrder = SortOrder.Asc, TextSortMethod textSortMethod = TextSortMethod.None);
}
