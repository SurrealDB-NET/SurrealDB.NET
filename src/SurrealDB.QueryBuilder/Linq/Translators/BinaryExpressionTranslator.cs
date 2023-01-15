using System.Linq.Expressions;

namespace SurrealDB.QueryBuilder.Linq.Translators;

internal static class BinaryExpressionTranslator
{
    internal static string Translate(BinaryExpression binaryExpression)
        => binaryExpression.NodeType switch
        {
            ExpressionType.Equal => $"({ExpressionTranslator.Translate(binaryExpression.Left)} == {ExpressionTranslator.Translate(binaryExpression.Right)})",
            ExpressionType.NotEqual => $"({ExpressionTranslator.Translate(binaryExpression.Left)} != {ExpressionTranslator.Translate(binaryExpression.Right)})",
            ExpressionType.GreaterThan => $"({ExpressionTranslator.Translate(binaryExpression.Left)} > {ExpressionTranslator.Translate(binaryExpression.Right)})",
            ExpressionType.GreaterThanOrEqual => $"({ExpressionTranslator.Translate(binaryExpression.Left)} >= {ExpressionTranslator.Translate(binaryExpression.Right)})",
            ExpressionType.LessThan => $"({ExpressionTranslator.Translate(binaryExpression.Left)} < {ExpressionTranslator.Translate(binaryExpression.Right)})",
            ExpressionType.LessThanOrEqual => $"({ExpressionTranslator.Translate(binaryExpression.Left)} <= {ExpressionTranslator.Translate(binaryExpression.Right)})",
            ExpressionType.AndAlso => $"({ExpressionTranslator.Translate(binaryExpression.Left)} && {ExpressionTranslator.Translate(binaryExpression.Right)})",
            ExpressionType.OrElse => $"({ExpressionTranslator.Translate(binaryExpression.Left)} || {ExpressionTranslator.Translate(binaryExpression.Right)})",
            ExpressionType.Add => $"({ExpressionTranslator.Translate(binaryExpression.Left)} + {ExpressionTranslator.Translate(binaryExpression.Right)})",
            ExpressionType.Subtract => $"({ExpressionTranslator.Translate(binaryExpression.Left)} - {ExpressionTranslator.Translate(binaryExpression.Right)})",
            ExpressionType.Multiply => $"({ExpressionTranslator.Translate(binaryExpression.Left)} * {ExpressionTranslator.Translate(binaryExpression.Right)})",
            ExpressionType.Divide => $"({ExpressionTranslator.Translate(binaryExpression.Left)} / {ExpressionTranslator.Translate(binaryExpression.Right)})",
            ExpressionType.PreIncrementAssign => $"{ExpressionTranslator.Translate(binaryExpression.Left)} += 1",
            ExpressionType.PostIncrementAssign => $"{ExpressionTranslator.Translate(binaryExpression.Left)} += 1",
            ExpressionType.PreDecrementAssign => $"{ExpressionTranslator.Translate(binaryExpression.Left)} -= 1",
            ExpressionType.PostDecrementAssign => $"{ExpressionTranslator.Translate(binaryExpression.Left)} -= 1",
            ExpressionType.ArrayIndex => $"{ExpressionTranslator.Translate(binaryExpression.Left)}[{ExpressionTranslator.Translate(binaryExpression.Right)}]",
            ExpressionType.Assign => $"{ExpressionTranslator.Translate(binaryExpression.Left)} = {ExpressionTranslator.Translate(binaryExpression.Right)}",
            ExpressionType.AddAssign => $"{ExpressionTranslator.Translate(binaryExpression.Left)} += {ExpressionTranslator.Translate(binaryExpression.Right)}",
            ExpressionType.SubtractAssign => $"{ExpressionTranslator.Translate(binaryExpression.Left)} -= {ExpressionTranslator.Translate(binaryExpression.Right)}",
            ExpressionType.MultiplyAssign => $"{ExpressionTranslator.Translate(binaryExpression.Left)} *= {ExpressionTranslator.Translate(binaryExpression.Right)}",
            ExpressionType.DivideAssign => $"{ExpressionTranslator.Translate(binaryExpression.Left)} /= {ExpressionTranslator.Translate(binaryExpression.Right)}",
            _ => throw new NotImplementedException()
        };
}
