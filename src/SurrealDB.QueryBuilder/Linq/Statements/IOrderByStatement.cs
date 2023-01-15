using System.Linq.Expressions;
using SurrealDB.QueryBuilder.Enums;

namespace SurrealDB.QueryBuilder.Linq.Statements;

public interface IOrderByStatement<TRecord> : ILimitByStatement<TRecord>
{
    ILimitByStatement<TRecord> OrderByRand();

    IOrderByStatement<TRecord> OrderBy(Expression<Func<TRecord, object>> field, SortOrder sortOrder = SortOrder.ASC, TextSortMethod textSortMethod = TextSortMethod.None);
}
