namespace SurrealDB.QueryBuilder.Fluent;

using System.Text;
using IFluent;

internal class ParallelFluent : BuildFluent, IParallelFluent
{
    internal ParallelFluent(StringBuilder currentQuery)
        : base(currentQuery) { }
}
