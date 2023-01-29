namespace SurrealDB.QueryBuilder.Linq.Statements;

using System.Linq.Expressions;

public interface IFetchStatement<TRecord> : ITimeoutStatement
{
    ITimeoutStatement Fetch(params Expression<Func<TRecord, object>>[] fields);
}
