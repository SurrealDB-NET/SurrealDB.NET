using System.Linq.Expressions;

namespace SurrealDB.QueryBuilder.Linq.Statements;

public interface ISelectWhereStatement<TRecord> : ISplitAtStatement<TRecord>
{
    ISplitAtStatement<TRecord> Where(Expression<Func<TRecord, bool>> predicate);
}
