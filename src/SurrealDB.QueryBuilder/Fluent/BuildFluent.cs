namespace SurrealDB.QueryBuilder.Fluent;

using System.Text;
using IFluent;

public class BuildFluent : IBuildFluent
{
    protected readonly StringBuilder Query;

    internal BuildFluent(StringBuilder currentQuery)
        => Query = currentQuery;

    public string Build()
        => Query.Append(';').ToString();
}
