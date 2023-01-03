using System.Text;
using SurrealDB.QueryBuilder.Fluent.Select.Implementation;

namespace SurrealDB.QueryBuilder.Fluent.Shared.Implementation;

internal class ParallelFluent : BuildFluent, IParallelFluent
{
    internal ParallelFluent(StringBuilder currentQuery)
        : base(currentQuery)
    {
    }
}
