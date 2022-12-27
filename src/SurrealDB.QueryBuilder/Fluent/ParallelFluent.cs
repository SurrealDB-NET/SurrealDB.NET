using System.Text;
using SurrealDB.QueryBuilder.IFluent;

namespace SurrealDB.QueryBuilder.Fluent;

internal class ParallelFluent : BuildFluent, IParallelFluent
{
    internal ParallelFluent(StringBuilder currentQuery)
        : base(currentQuery) { }
}