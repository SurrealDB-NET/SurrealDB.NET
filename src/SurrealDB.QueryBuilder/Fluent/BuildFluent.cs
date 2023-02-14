using System.Text;
using SurrealDB.QueryBuilder.Fluent.IFluent;

namespace SurrealDB.QueryBuilder.Fluent;

public class BuildFluent : IBuildFluent
{
	protected readonly StringBuilder Query;

	internal BuildFluent(StringBuilder currentQuery)
	{
		Query = currentQuery;
	}

	public string Build()
	{
		return Query.Append(';').ToString();
	}
}
