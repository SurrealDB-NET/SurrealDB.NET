namespace SurrealDB.QueryBuilder.Linq.Statements;

using System.Linq.Expressions;

public interface ISplitAtStatement<TRecord> : IGroupByStatement<TRecord>
{
    IGroupByStatement<TRecord> SplitAt(params Expression<Func<TRecord, object>>[] fields);
}
