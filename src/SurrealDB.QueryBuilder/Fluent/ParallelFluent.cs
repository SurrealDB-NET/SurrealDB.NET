using System.Text;

namespace SurrealDB.QueryBuilder.Fluent;

using IFluent;

internal class ParallelFluent : BuildFluent, IParallelFluent
{
    internal ParallelFluent(StringBuilder currentQuery)
        : base(currentQuery) { }
}