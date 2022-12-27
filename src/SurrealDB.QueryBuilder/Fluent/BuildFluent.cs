using System.Text;
using SurrealDB.QueryBuilder.IFluent;

namespace SurrealDB.QueryBuilder.Fluent;

public class BuildFluent : IBuildFluent
{
    protected StringBuilder _query;

    internal BuildFluent(StringBuilder currentQuery)
        => _query = currentQuery;

    public string Build()
        => _query.Append(";").ToString();
}