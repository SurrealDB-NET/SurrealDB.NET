using System.Text;

namespace SurrealDB.QueryBuilder.Fluent;

using IFluent;

public class BuildFluent : IBuildFluent
{
    protected readonly StringBuilder query;

    internal BuildFluent(StringBuilder currentQuery)
        => query = currentQuery;

    public string Build()
        => query.Append(';').ToString();
}