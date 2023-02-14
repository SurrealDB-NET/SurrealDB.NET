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
	{
		return new SelectFluent(new StringBuilder("SELECT *"));
	}

	public static ISelectFluent Select(params string[] fields)
	{
		return new SelectFluent(new StringBuilder($"SELECT {string.Join(", ", fields)}"));
	}

	public static ISelectStatement<TSource> Select<TSource>(Expression<Func<TSource, object>> selector)
	{
		return new SelectNode<TSource>(selector);
	}

	public static ICreateStatement<TSource> Create<TSource>()
	{
		return new CreateNode<TSource>(new string?[] { null });
	}

	public static ICreateStatement<TSource> Create<TSource>(params string?[] recordIds)
	{
		return new CreateNode<TSource>(recordIds);
	}
}
