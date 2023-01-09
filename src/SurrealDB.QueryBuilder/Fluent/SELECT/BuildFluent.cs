using System.Text;
using SurrealDB.QueryBuilder.Fluent.Shared;

namespace SurrealDB.QueryBuilder.Fluent.Select.Implementation;

public class BuildFluent : IBuildFluent
{
    protected readonly StringBuilder query;

    internal BuildFluent(StringBuilder currentQuery)
        => query = currentQuery;

    public string Build()
        => query.Append(';').ToString();
}
