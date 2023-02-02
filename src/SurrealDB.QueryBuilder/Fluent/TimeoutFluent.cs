using System.Text;
using SurrealDB.QueryBuilder.Fluent.IFluent;

namespace SurrealDB.QueryBuilder.Fluent;

internal class TimeoutFluent : ParallelFluent, ITimeoutFluent
{
	internal TimeoutFluent(StringBuilder currentQuery)
		: base(currentQuery) { }

	public IParallelFluent Parallel()
	{
		Query.Append(" PARALLEL");

		return new ParallelFluent(Query);
	}
}
