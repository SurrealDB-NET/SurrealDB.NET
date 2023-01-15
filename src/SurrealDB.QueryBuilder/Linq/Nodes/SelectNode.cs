using System.Linq.Expressions;
using SurrealDB.QueryBuilder.Linq.Statements;
using SurrealDB.QueryBuilder.Linq.Translators;

namespace SurrealDB.QueryBuilder.Linq.Nodes;

internal class SelectNode<TSource> : SelectWhereNode<TSource>, ISelectStatement<TSource>
{
    internal SelectNode(Expression<Func<TSource, object>> selector)
        : base(new("SELECT"))
        => _query.Append($" {LambdaExpressionTranslator.Translate(selector)} FROM {typeof(TSource).Name}");

    public ISelectWhereStatement<TSource> From(params string[] sources)
    {
        if (sources.Length is 0)
            return new SelectWhereNode<TSource>(_query);

        _query.Remove(_query.Length - typeof(TSource).Name.Length - 1, typeof(TSource).Name.Length + 1);

       return new SelectWhereNode<TSource>(_query.Append($" {string.Join(", ", sources)}"));
    }
}
