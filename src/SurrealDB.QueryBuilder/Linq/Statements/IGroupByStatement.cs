namespace SurrealDB.QueryBuilder.Linq.Statements;

using System.Linq.Expressions;

public interface IGroupByStatement<TRecord> : IOrderByStatement<TRecord>
{
    IOrderByStatement<TRecord> GroupBy(params Expression<Func<TRecord, object>>[] fields);
}
