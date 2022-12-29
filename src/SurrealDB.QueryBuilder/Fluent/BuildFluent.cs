using System.Text;

namespace SurrealDB.QueryBuilder.Fluent;

public class BuildFluent : IBuildFluent
{
    protected readonly StringBuilder Query;

    internal BuildFluent(StringBuilder currentQuery)
        => Query = currentQuery;

    public string Build()
        => Query.Append(';').ToString();
}