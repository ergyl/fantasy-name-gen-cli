namespace FantasyNameGenerator.Domain.Primitives;

public record Result<T>(
    bool IsValid,
    T? Value,
    string? ErrorMessage)
{
    public static Result<T> Success(T value)
        => new(true, value, null);

    public static Result<T> Failure(string message)
        => new(false, default, message);
}