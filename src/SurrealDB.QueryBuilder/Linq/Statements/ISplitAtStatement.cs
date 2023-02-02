using System.Linq.Expressions;

namespace SurrealDB.QueryBuilder.Linq.Statements;

public interface ISplitAtStatement<TRecord> : IGroupByStatement<TRecord>
{
	IGroupByStatement<TRecord> SplitAt(params Expression<Func<TRecord, object>>[] fields);
}
