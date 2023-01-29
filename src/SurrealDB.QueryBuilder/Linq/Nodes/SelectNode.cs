namespace SurrealDB.QueryBuilder.Linq.Nodes;

using System.Linq.Expressions;
using System.Text;
using Statements;
using Translators;

internal class SelectNode<TSource> : SelectWhereNode<TSource>, ISelectStatement<TSource>
{
    internal SelectNode(Expression<Func<TSource, object>> selector)
        : base(new StringBuilder("SELECT"))
        => Query.Append($" {LambdaExpressionTranslator.Translate(selector)} FROM {typeof(TSource).Name}");

    public ISelectWhereStatement<TSource> From(params string[] sources)
    {
        if (sources.Length is 0)
            return new SelectWhereNode<TSource>(Query);

        Query.Remove(Query.Length - typeof(TSource).Name.Length - 1, typeof(TSource).Name.Length + 1);

        return new SelectWhereNode<TSource>(Query.Append($" {string.Join(", ", sources)}"));
    }
}
