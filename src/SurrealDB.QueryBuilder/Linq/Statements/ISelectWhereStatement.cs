namespace SurrealDB.QueryBuilder.Linq.Statements;

using System.Linq.Expressions;

public interface ISelectWhereStatement<TRecord> : ISplitAtStatement<TRecord>
{
    ISplitAtStatement<TRecord> Where(Expression<Func<TRecord, bool>> predicate);
}
