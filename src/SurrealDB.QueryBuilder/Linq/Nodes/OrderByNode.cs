namespace SurrealDB.QueryBuilder.Linq.Nodes;

using System.Linq.Expressions;
using System.Text;
using Enums;
using Statements;
using Translators;

internal class OrderByNode<TRecord> : LimitByNode<TRecord>, IOrderByStatement<TRecord>
{
    private bool _isFirstOrderBy = true;

    internal OrderByNode(StringBuilder query)
        : base(query) { }

    public ILimitByStatement<TRecord> OrderByRand()
        => new LimitByNode<TRecord>(Query.Append(" ORDER RAND()"));

    public IOrderByStatement<TRecord> OrderBy(Expression<Func<TRecord, object>> field, SortOrder sortOrder = SortOrder.Asc, TextSortMethod textSortMethod = TextSortMethod.None)
    {
        if (_isFirstOrderBy)
        {
            Query.Append(" ORDER");
            _isFirstOrderBy = false;
        }
        else
        {
            Query.Append(',');
        }

        Query.Append($" {LambdaExpressionTranslator.Translate(field)}");
        if (textSortMethod is not TextSortMethod.None)
            Query.Append($" {textSortMethod}");
        Query.Append($" {sortOrder}");

        return this;
    }
}
