namespace SurrealDB.Client.Exceptions;

public class SurrealDeserializationException<TSource, TTarget> : SurrealException
{
	internal SurrealDeserializationException()
		: base($"Failed to deserialize {typeof(TSource).Name} to {typeof(TTarget).Name}.") { }
}
