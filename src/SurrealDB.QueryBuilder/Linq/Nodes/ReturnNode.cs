namespace SurrealDB.QueryBuilder.Linq.Nodes;

using System.Linq.Expressions;
using System.Text;
using Enums;
using Statements;
using Translators;

internal class ReturnNode<TRecord> : TimeoutNode, IReturnStatement<TRecord>
{
    internal ReturnNode(StringBuilder query)
        : base(query) { }

    public ITimeoutStatement Return(ReturnClause returnClause)
        => new TimeoutNode(Query.Append($" RETURN {returnClause}"));

    public ITimeoutStatement Return(Expression<Func<TRecord, object>> projection)
        => new TimeoutNode(Query.Append($" RETURN {LambdaExpressionTranslator.Translate(projection)}"));
}
