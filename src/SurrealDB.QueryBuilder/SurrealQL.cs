using System.Text;
using SurrealDB.QueryBuilder.Fluent.Select;
using SurrealDB.QueryBuilder.Fluent.Select.Implementation;

namespace SurrealDB.QueryBuilder;

public static class SurrealQL
{
    public static ISelectFluent Select()
        => new SelectFluent(new StringBuilder("SELECT *"));

    public static ISelectFluent Select(params string[] projections)
        => new SelectFluent(new StringBuilder($"SELECT {string.Join(',', projections)}"));

    // public static ICreateFluent Create(params string[] targets)
    //     => new CreateFluent(new StringBuilder($"CREATE {string.Join(',', targets)}"));

    // public static IUpdateFluent Update(params string[] targets)
    //     => new UpdateFluent(new StringBuilder($"UPDATE {string.Join(',', targets)}"));
}
