using System.Text;
using SurrealDB.QueryBuilder.Fluent.IFluent;

namespace SurrealDB.QueryBuilder.Fluent;

internal class ParallelFluent : BuildFluent, IParallelFluent
{
	internal ParallelFluent(StringBuilder currentQuery)
		: base(currentQuery) { }
}
