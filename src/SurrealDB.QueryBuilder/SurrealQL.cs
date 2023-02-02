using System.Linq.Expressions;
using System.Text;
using SurrealDB.QueryBuilder.Fluent;
using SurrealDB.QueryBuilder.Fluent.IFluent;
using SurrealDB.QueryBuilder.Linq.Nodes;
using SurrealDB.QueryBuilder.Linq.Statements;

namespace SurrealDB.QueryBuilder;

public static class SurrealQL
{
	public static ISelectFluent Select()
		=> new SelectFluent(new StringBuilder("SELECT *"));

	public static ISelectFluent Select(params string[] fields)
		=> new SelectFluent(new StringBuilder($"SELECT {string.Join(", ", fields)}"));

	public static ISelectStatement<TSource> Select<TSource>(Expression<Func<TSource, object>> selector)
		=> new SelectNode<TSource>(selector);

	public static ICreateStatement<TSource> Create<TSource>()
		=> new CreateNode<TSource>(new string?[] { null });

	public static ICreateStatement<TSource> Create<TSource>(params string?[] recordIds)
		=> new CreateNode<TSource>(recordIds);
}
