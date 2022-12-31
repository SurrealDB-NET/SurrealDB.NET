using System.Text;
using SurrealDB.QueryBuilder.Fluent;

namespace SurrealDB.QueryBuilder;

public static class SurrealQL
{
    public static ISelectFluent Select()
        => new SelectFluent(new StringBuilder("SELECT *"));

    public static ISelectFluent Select(params string[] fields)
        => new SelectFluent(new StringBuilder($"SELECT {string.Join(", ", fields)}"));
}