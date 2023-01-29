namespace SurrealDB.QueryBuilder.Linq.Nodes;

using System.Linq.Expressions;
using System.Text;
using QueryBuilder.Translators;
using Statements;
using Translators;

public class CreateNode<TRecord> : ICreateStatement<TRecord>
{
    private readonly StringBuilder _query = new("CREATE");

    internal CreateNode(params string?[] recordIds)
        => _query.Append($" {string.Join(", ", recordIds.Select(recordId => recordId is null ? typeof(TRecord).Name : $"{typeof(TRecord).Name}:{recordId}"))}");

    public IReturnStatement<TRecord> Set(Expression<Func<TRecord, TRecord>> setter)
        => new ReturnNode<TRecord>(_query.Append($" SET {LambdaExpressionTranslator.Translate(setter)}"));

    public IReturnStatement<TRecord> Content(TRecord record)
        => new ReturnNode<TRecord>(_query.Append($" CONTENT {ObjectTranslator.Translate(record)}"));

    public override string ToString()
        => _query.ToString();
}
