using System.Linq.Expressions;
using System.Text;
using SurrealDB.QueryBuilder.DataModels;
using SurrealDB.QueryBuilder.Enums;
using SurrealDB.QueryBuilder.Linq.Shared;
using SurrealDB.QueryBuilder.Linq.Shared.Nodes;

namespace SurrealDB.QueryBuilder.Linq.Create;

internal class CreateNode<TRecord> : ReturnNode, ICreateNode<TRecord>
    where TRecord : SurrealRecord
{
    private readonly StringBuilder _query;

    internal CreateNode(StringBuilder query, TRecord record)
    {
        _query = query;
        _query.Append("CREATE ");
        _query.Append($"{typeof(TRecord).Name}");
        if (record.Id is not null)
            _query.Append($":{record.Id}");
    }

    public IReturnNode Return(ReturnClause returnClause)
        => new ReturnNode(_query, returnClause);

    public IReturnNode Return(Expression<Func<TRecord, object>> projections) => throw new NotImplementedException();
}
