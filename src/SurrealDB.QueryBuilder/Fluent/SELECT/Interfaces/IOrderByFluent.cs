namespace SurrealDB.QueryBuilder.Fluent.Select;

public interface IOrderByFluent : ILimitByFluent
{
    ILimitByFluent LimitBy(uint limit);
}
