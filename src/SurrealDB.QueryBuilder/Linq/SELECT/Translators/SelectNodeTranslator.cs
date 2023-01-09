using System.Linq.Expressions;
using System.Text;

namespace SurrealDB.QueryBuilder.Linq;

internal class SelectNodeTranslator<TSource> : ExpressionVisitor
{
    private StringBuilder _query;
    private object _recordId;

    public SelectNodeTranslator(StringBuilder query, Expression<Func<TSource, object?>> selector, object recordId = default!)
    {
        _query = query;
        _recordId = recordId;
        Visit(selector);
    }

    protected override Expression VisitLambda<T>(Expression<T> node)
    {
        _query.Append("SELECT ");
        var result = base.VisitLambda(node);

        _query.Append(" FROM ");
        _query.Append($"{typeof(TSource).Name}");
        if (_recordId is not null)
            _query.Append($":{_recordId}");
        _query.Append(';');

        return result;
    }

    protected override Expression VisitNew(NewExpression node)
    {
        for (var i = 0; i < node.Arguments.Count; i++)
        {
            var argument = node.Arguments[i];
            var member = node.Members![i];

            if (argument is ParameterExpression)
                _query.Append('*');
            else if (argument is NewExpression subObject)
                TranslateSubObject(subObject);
            else
                Visit(argument);

            if (argument is not ParameterExpression)
                _query.Append($" AS {member.Name}, ");
            else
                _query.Append(", ");
        }

        _query.Remove(_query.Length - 2, 2);

        return node;
    }

    protected override Expression VisitMember(MemberExpression node)
    {
        _query.Append(node.Member.Name);
        return node;
    }

    protected override Expression VisitBinary(BinaryExpression node)
    {
        Visit(node.Left);
        _query.Append(node.NodeType switch
        {
            ExpressionType.Equal => " == ",
            ExpressionType.GreaterThan => " > ",
            ExpressionType.GreaterThanOrEqual => " >= ",
            ExpressionType.LessThan => " < ",
            ExpressionType.LessThanOrEqual => " <= ",
            ExpressionType.NotEqual => " != ",
            ExpressionType.AndAlso => " AND ",
            ExpressionType.OrElse => " OR ",
            ExpressionType.Add => " + ",
            ExpressionType.Subtract => " - ",
            ExpressionType.Multiply => " * ",
            ExpressionType.Divide => " / ",
            _ => throw new NotImplementedException(),
        });
        Visit(node.Right);

        return node;
    }

    protected override Expression VisitConstant(ConstantExpression node)
    {
        _query.Append(node.Value);
        return node;
    }

    protected override Expression VisitMethodCall(MethodCallExpression node)
    {
        if (node.Method.DeclaringType == typeof(Enumerable))
        {
            switch (node.Method.Name)
            {
                case nameof(Enumerable.Select):
                    var member = (((LambdaExpression)node.Arguments[1]).Body as MemberExpression)!.Member.Name;
                    Visit(node.Arguments[0]);
                    _query.Append($".{member}");
                    return node;

                case nameof(Enumerable.Where):
                    var predicate = ((LambdaExpression)node.Arguments[1]).Body;
                    Visit(node.Arguments[0]);
                    _query.Append("[WHERE ");
                    Visit(predicate);
                    _query.Append("]");
                    return node;

                default:
                    throw new NotImplementedException("Enumerable method not implemented");
            }
        }

        throw new NotImplementedException();
    }

    private void TranslateSubObject(NewExpression node)
    {
        _query.Append("{ ");
        for (var i = 0; i < node.Arguments.Count; i++)
        {
            _query.Append($"{node.Members![i].Name}: ");
            if (node.Arguments[i] is NewExpression subObject)
                TranslateSubObject(subObject);
            else
                Visit(node.Arguments[i]);
            _query.Append(", ");
        }

        _query.Remove(_query.Length - 2, 2);
        _query.Append(" }");
    }
}
