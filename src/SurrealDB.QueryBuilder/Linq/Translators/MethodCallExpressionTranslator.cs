using System.Collections;
using System.Linq.Expressions;
using System.Reflection;
using SurrealDB.QueryBuilder.Attributes;
using SurrealDB.QueryBuilder.Translators;

namespace SurrealDB.QueryBuilder.Linq.Translators;

internal static class MethodCallExpressionTranslator
{
    internal static string Translate(MethodCallExpression methodCallExpression)
    {
        var surrealFunction = methodCallExpression.Method.GetCustomAttribute<SurrealFunctionAttribute>();
        if (surrealFunction is not null)
            return $"{surrealFunction.Function}({string.Join(", ", methodCallExpression.Arguments.Select(a => ExpressionTranslator.Translate(a)))})";

        var surrealOperator = methodCallExpression.Method.GetCustomAttribute<SurrealOperatorAttribute>();
        if (surrealOperator is not null)
        {
            var left = ExpressionTranslator.Translate(methodCallExpression.Arguments[0]);
            var right = ExpressionTranslator.Translate(methodCallExpression.Arguments[1]);
            return $"({left} {surrealOperator.Operator} {right})";
        }

        var isFromEnumerable = methodCallExpression.Method.DeclaringType == typeof(Enumerable)
            || (methodCallExpression.Method.DeclaringType?.GetInterfaces().Any(i => i == typeof(IEnumerable)) ?? false);
        if (isFromEnumerable)
            return TranslateEnumerableMethod(methodCallExpression);

        var result = Expression.Lambda(methodCallExpression).Compile().DynamicInvoke();

        return ObjectTranslator.Translate(result);
    }

    private static string TranslateEnumerableMethod(MethodCallExpression methodCallExpression)
    {
        var enumerable = ExpressionTranslator.Translate(methodCallExpression.Arguments[0]);

        var methodName = methodCallExpression.Method.Name;

        switch (methodName)
        {
            case "Select":
                return $"{enumerable}.{ExpressionTranslator.Translate((methodCallExpression.Arguments[1] as LambdaExpression)!.Body)}";

            case "Where":
                return $"{enumerable}[WHERE {ExpressionTranslator.Translate((methodCallExpression.Arguments[1] as LambdaExpression)!.Body)}]";

            case "Append":
            case "Concat":
                return $"{enumerable} += {ExpressionTranslator.Translate(methodCallExpression.Arguments[1])}";

            case "Remove":
                return $"{enumerable} -= {ExpressionTranslator.Translate(methodCallExpression.Arguments[0])}";
            case "RemoveAll":
                return $"{enumerable} -= {ExpressionTranslator.Translate((methodCallExpression.Arguments[0] as LambdaExpression)!.Body)}";

            case "First":
                return $"{enumerable}";
            default:
                throw new NotSupportedException($"Method {methodName} is not supported.");
        }
    }
}
