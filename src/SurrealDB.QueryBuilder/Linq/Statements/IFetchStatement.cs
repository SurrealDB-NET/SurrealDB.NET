using System.Linq.Expressions;

namespace SurrealDB.QueryBuilder.Linq.Statements;

public interface IFetchStatement<TRecord> : ITimeoutStatement
{
    ITimeoutStatement Fetch(params Expression<Func<TRecord, object>>[] fields);
}
