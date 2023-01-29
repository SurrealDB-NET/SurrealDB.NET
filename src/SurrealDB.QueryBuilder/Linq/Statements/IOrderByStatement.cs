namespace SurrealDB.QueryBuilder.Linq.Statements;

using System.Linq.Expressions;
using Enums;

public interface IOrderByStatement<TRecord> : ILimitByStatement<TRecord>
{
    ILimitByStatement<TRecord> OrderByRand();

    IOrderByStatement<TRecord> OrderBy(Expression<Func<TRecord, object>> field, SortOrder sortOrder = SortOrder.Asc, TextSortMethod textSortMethod = TextSortMethod.None);
}
