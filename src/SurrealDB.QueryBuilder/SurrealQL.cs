using System.Linq.Expressions;
using System.Text;
using SurrealDB.QueryBuilder.Fluent.Select;
using SurrealDB.QueryBuilder.Fluent.Select.Implementation;
using SurrealDB.QueryBuilder.Linq;
using SurrealDB.QueryBuilder.Linq.Create;

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

    public static ISelectNode<TSource> Select<TSource>(Expression<Func<TSource, object?>> selector, object recordId = default!)
        => new SelectNode<TSource>(new StringBuilder(), selector, recordId);

    public static ICreateNode<TRecord> Create<TRecord>(TRecord record)
        => new CreateNode<TRecord>(new StringBuilder(), record);
}
