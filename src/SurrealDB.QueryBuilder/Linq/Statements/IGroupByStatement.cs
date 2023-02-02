using System.Linq.Expressions;

namespace SurrealDB.QueryBuilder.Linq.Statements;

public interface IGroupByStatement<TRecord> : IOrderByStatement<TRecord>
{
	IOrderByStatement<TRecord> GroupBy(params Expression<Func<TRecord, object>>[] fields);
}
