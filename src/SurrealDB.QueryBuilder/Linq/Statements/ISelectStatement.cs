namespace SurrealDB.QueryBuilder.Linq.Statements;

public interface ISelectStatement<TSource> : ISelectWhereStatement<TSource>
{
	ISelectWhereStatement<TSource> From(params string[] sources);
}
