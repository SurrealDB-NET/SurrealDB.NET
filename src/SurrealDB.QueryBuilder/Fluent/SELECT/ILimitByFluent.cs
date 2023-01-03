namespace SurrealDB.QueryBuilder.Fluent.Select;

public interface ILimitByFluent : IStartAtFluent
{
    IStartAtFluent StartAt(uint startAt);
}
