namespace SurrealDB.QueryBuilder.Linq.Nodes;

using System.Linq.Expressions;
using System.Text;
using Statements;
using Translators;

internal class FetchNode<TRecord> : TimeoutNode, IFetchStatement<TRecord>
{
    internal FetchNode(StringBuilder query)
        : base(query) { }

    public ITimeoutStatement Fetch(Expression<Func<TRecord, object>>[] fields)
        => new TimeoutNode(Query.Append($" FETCH {string.Join(", ", fields.Select(LambdaExpressionTranslator.Translate))}"));
}
