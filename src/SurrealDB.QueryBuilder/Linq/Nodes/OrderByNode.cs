using System.Linq.Expressions;
using System.Text;
using SurrealDB.QueryBuilder.Enums;
using SurrealDB.QueryBuilder.Linq.Statements;
using SurrealDB.QueryBuilder.Linq.Translators;

namespace SurrealDB.QueryBuilder.Linq.Nodes;

internal class OrderByNode<TRecord> : LimitByNode<TRecord>, IOrderByStatement<TRecord>
{
    private bool _isFirstOrderBy = true;

    internal OrderByNode(StringBuilder query)
        : base(query) { }

    public ILimitByStatement<TRecord> OrderByRand()
        => new LimitByNode<TRecord>(_query.Append(" ORDER RAND()"));

    public IOrderByStatement<TRecord> OrderBy(Expression<Func<TRecord, object>> field, SortOrder sortOrder = SortOrder.ASC, TextSortMethod textSortMethod = TextSortMethod.None)
    {
        if (_isFirstOrderBy)
        {
            _query.Append(" ORDER");
            _isFirstOrderBy = false;
        }
        else
            _query.Append(",");

        _query.Append($" {LambdaExpressionTranslator.Translate(field)}");
        if (textSortMethod is not TextSortMethod.None)
            _query.Append($" {textSortMethod}");
        _query.Append($" {sortOrder}");

        return this;
    }
}
